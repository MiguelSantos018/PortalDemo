(function ($) {
    app.modals.CreateOrUpdateModal = function () {
        var _categoryService = abp.services.app.category;
        var _$categoryInformationForm;
        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$categoryInformationForm = _modalManager.getModal().find('form[name=CategoryInformationsForm]');
            _$categoryInformationForm.validate();
        }

        this.save = function () {
            if (!_$categoryInformationForm.valid()) {
                return;
            }
            var category = _$categoryInformationForm.serializeFormToObject();

            debugger;

            _modalManager.setBusy(true);
            _categoryService
                .createOrEdit(category)
                .done(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditModalSaved');
                })
                .always(function () {
                    _modalManager.setBusy(false);
                });
        };
    };
})(jQuery);