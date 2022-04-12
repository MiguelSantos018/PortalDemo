(function () {
    $(function () {
        var _$categoriesTable = $('#CategoriesTable');
        var _categoryService = abp.services.app.category;

        var _permissions = {
            edit: abp.auth.hasPermission('Pages.Categories.Edit'),
            delete: abp.auth.hasPermission('Pages.Categories.Delete'),
            deleteMovies: abp.auth.hasPermission('Pages.Movies.Delete'),
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Category/CreateOrUpdateModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Category/_CreateOrUpdateModal.js',
            modalClass: 'CreateOrUpdateModal',
        });

        var dataTable = _$categoriesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _categoryService.getAll,
                inputFilter: function () {
                    return {
                        filter: $('#CategoriesTableFilter').val(),
                    };
                },
            },
            columnDefs: [
                {
                    targets: 0,
                    data: 'name',
                    //render: function (_data, _type, row) {
                    //    return '<a class="mr-2" href="/App/Category/Details/' + row.id + '">' + row.name + '</a>';
                    //},
                },
                {
                    targets: 1,
                    data: 'description',
                },
                {
                    targets: 2,
                    render: function (_data, _type, row) {
                        var edit = "";
                        var del = "";
                        if (_permissions.edit) {
                            edit = '<a role="button" class="btn" onclick="editCategory(' + row.id + ')"><i class="icon-xl flaticon2-pen"></i></a>';
                        }
                        if (_permissions.delete && _permissions.deleteMovies) {
                            del = '<a role="button" class="btn" onclick ="deleteCategory(' + row.id + ')"><i class="icon-xl fa fa-trash"></i></a>';
                        }
                        return (edit + del);
                    },
                },
            ],
        });

        abp.event.on('app.createOrEditModalSaved', function () {
            getCategories();
        });

        $('#CreateNewCategoriesButton').click(function () {
            _createOrEditModal.open();
        });

        function getCategories() {
            dataTable.ajax.reload();
        }

        abp.event.on('app.createOrEditMovieModalSaved', function () {
            getCategories();
        });

        $('#CategoriesTableFilter').on('keydown', function (e) {
            if (e.keyCode !== 13) {
                return;
            }

            e.preventDefault();
            getCategories();
        });

        $('#GetCategoriesButton, #RefreshCategoriesListButton').click(function (e) {
            e.preventDefault();
            getCategories();
        });

        window.editCategory = function (_Id) {
            _createOrEditModal.open({ id: _Id });
        }

        window.deleteCategory = function (id) {
            abp.message.confirm(
                app.localize('CategoryDeleteWarningMessage'),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService
                            .delete(id)
                            .done(function () {
                                getCategories();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                    }
                }
            );
        }
    });
})();