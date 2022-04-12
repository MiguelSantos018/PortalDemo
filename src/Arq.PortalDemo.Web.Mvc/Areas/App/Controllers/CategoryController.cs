using Abp.AspNetCore.Mvc.Authorization;
using Arq.PortalDemo.Authorization;
using Arq.PortalDemo.Categories;
using Arq.PortalDemo.Web.Areas.App.Models.Category;
using Arq.PortalDemo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arq.PortalDemo.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class CategoryController : PortalDemoControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Categories)]
        public IActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(
            AppPermissions.Pages_Categories_Create,
            AppPermissions.Pages_Categories_Edit
        )]
        public async Task<PartialViewResult> CreateOrUpdateModal(int? id)
        {
            CreateOrUpdateViewModel viewModel = ObjectMapper.Map<CreateOrUpdateViewModel>(await _categoryAppService.GetById(id));
            return PartialView("_CreateOrUpdateModal", viewModel);
        }
    }
}
