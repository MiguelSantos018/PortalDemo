using Abp.AspNetCore.Mvc.Authorization;
using Abp.IO.Extensions;
using Abp.UI;
using Abp.Web.Models;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.Movies;
using Arq.PortalDemo.Storage;
using Arq.PortalDemo.Web.Areas.App.Models.Movies;
using Arq.PortalDemo.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class MoviesController : PortalDemoControllerBase
    {
        private readonly IMoviesAppService _moviesAppService;
        private readonly ITempFileCacheManager _tempFileCacheManager;
        private const int MaxProfilePictureSize = 5242880;

        public MoviesController(IMoviesAppService moviesAppService, ITempFileCacheManager tempFileCacheManager)
        {
            _moviesAppService = moviesAppService;
            _tempFileCacheManager = tempFileCacheManager;
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Movies)]
        public IActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(
            AppPermissions.Pages_Movies,
            AppPermissions.Pages_Movies_Create,
            AppPermissions.Pages_Movies_Edit
        )]
        public async Task<PartialViewResult> CreateOrEditModal(long? id)
        {
            CreateOrEditMovieModalViewModel viewModel = ObjectMapper.Map<CreateOrEditMovieModalViewModel>(await _moviesAppService.GetById(id));
            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<IActionResult> Details(long? id)
        {
            MovieViewModel viewModel = ObjectMapper.Map<MovieViewModel>(await _moviesAppService.GetById(id));
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> UploadImage()
        {
            var file = Request.Form.Files[0];
            byte[] fileBytes = null;
            //Check input
            if (file == null)
            {
                throw new UserFriendlyException(L("File_Empty_Error"));
            }

            if (file.Length > 1048576) //1MB
            {
                throw new UserFriendlyException(L("File_SizeLimit_Error"));
            }

            using (var stream = file.OpenReadStream())
            {
                fileBytes = stream.GetAllBytes();
            }
            
            var token = Guid.NewGuid();
            _tempFileCacheManager.SetFile(token.ToString(), new TempFileInfo(file.FileName, file.ContentType, fileBytes));

            return Json(new AjaxResponse(token.ToString()));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetFile(int Id)
        {
            var file = await _moviesAppService.GetImage(Id);
            if (file == null)
                return StatusCode((int)HttpStatusCode.NotFound);



            return File(file.ImageContent, file.ContentType);
        }
    }
}