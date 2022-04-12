(function () {
    $(function () {
        var _$moviesTable = $('#MoviesTable');
        var _movieService = abp.services.app.movies;

        var _permissions = {
            edit: abp.auth.hasPermission('Pages.Movies.Edit'),
            delete: abp.auth.hasPermission('Pages.Movies.Delete'),
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Movies/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Movies/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditMovieModal',
        });

        var dataTable = _$moviesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _movieService.getAll,
                inputFilter: function () {
                    return {
                        filter: $('#MoviesTableFilter').val(),
                        title: $('#TitleTableFilter').val(),
                        description: $('#DescriptionTableFilter').val(),
                    };
                },
            },
            columnDefs: [
                {
                    targets: 0,
                    data: 'title',
                    render: function (_data, _type, row) {
                        return '<a class="text-gray-900 text-hover-primary me-1" href="/App/Movies/Details/' + row.id + '">' + row.title + '</a>';
                    },
                },
                {
                    targets: 1,
                    data: 'description',
                },
                {
                    targets: 2,
                    data: 'categoryName',
                },
                {
                    targets: 3,
                    render: function (_data, _type, row) {
                        var edit = "";
                        var del = "";
                        if (_permissions.edit) {
                            edit = '<a role="button" class="btn" onclick="editMovie(' + row.id + ')"><i class="icon-xl flaticon2-pen"></i></a>';
                        }
                        if (_permissions.delete) {
                            del = '<a role="button" class="btn" onclick ="deleteMovie(' + row.id + ')"><i class="icon-xl fa fa-trash"></i></a>';
                        }
                        return (edit + del);
                    },
                },
            ],
        });

        $('#CreateNewMovieButton').click(function () {
            _createOrEditModal.open();
        });

        function getMovies() {
            dataTable.ajax.reload();
        }

        abp.event.on('app.createOrEditMovieModalSaved', function () {
            getMovies();
        });

        window.editMovie = function (_Id) {
            _createOrEditModal.open({ id: _Id });
        }

        $('#MoviesTableFilter, #DescriptionTableFilter, #TitleTableFilter').on('keydown', function (e) {
            if (e.keyCode !== 13) {
                return;
            }

            e.preventDefault();
            getMovies();
        });

        $('#GetMoviesButton, #RefreshMovieListButton').click(function (e) {
            e.preventDefault();
            getMovies();
        });

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        window.deleteMovie = function (id) {
            abp.message.confirm(
                app.localize('MovieDeleteWarningMessage'),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _movieService
                            .delete(id)
                            .done(function () {
                                getMovies();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                    }
                }
            );
        }
    });
})();