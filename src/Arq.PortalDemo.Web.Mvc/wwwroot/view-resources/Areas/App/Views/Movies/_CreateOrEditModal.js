(function ($) {
    app.modals.CreateOrEditMovieModal = function () {
        var _movieService = abp.services.app.movies;
        var _$movieInformationForm;
        var _$moviePicture;
        var _modalManager;
        var uploadedFileToken;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$movieInformationForm = _modalManager.getModal().find('form[name=MovieInformationsForm]');
            _$movieInformationForm.validate();
            _$moviePicture = _modalManager.getModal().find('form[id=MovieInformationsForm]');
            _$moviePicture.validate();
        };

        // In your Javascript (external .js resource or <script> tag)
        $(document).ready(function () {
            $('.js-example-basic-single').select2();
            $('.background').select2();
        });

        function encodeImageFileAsURL(element) {
            var reader = new FileReader();
            reader.onloadend = function () {
                console.log('RESULT', reader.result);

                $('#Picture').attr('src', reader.result);
            }
            reader.readAsDataURL(element);
        }

        $('#MoviePicture').change(function () {
            $('#MovieInformationsForm').submit();
        });

        $('#MovieInformationsForm').ajaxForm({
            beforeSubmit: function (formData, jqForm, options) {
                var $fileInput = $('#MovieInformationsForm input[name=MoviePicture]');
                var files = $fileInput.get()[0].files;

                if (!files.length) {
                    return false;
                }

                var file = files[0];

                //File type check
                var type = '|' + file.type.slice(file.type.lastIndexOf('/') + 1) + '|';
                if ('|jpg|jpeg|png|gif|'.indexOf(type) === -1) {
                    abp.message.warn(app.localize('ProfilePicture_Warn_FileType'));
                    return false;
                }

                //File size check
                if (file.size > 5242880) {
                    //5MB
                    abp.message.warn(app.localize('ProfilePicture_Warn_SizeLimit', app.maxProfilePictureBytesUserFriendlyValue));
                    return false;
                }

                var mimeType = _.filter(formData, { name: 'MoviePicture' })[0].value.type;

                formData.push({ name: 'FileType', value: mimeType });
                formData.push({ name: 'FileName', value: 'MoviePicture' });
                formData.push({ name: 'FileToken', value: app.guid() });

                console.log(encodeImageFileAsURL(file));

                return true;
            },
            success: function (response) {
                if (response.success) {
                    uploadedFileToken = response;
                } else {
                    abp.message.error(response.error.message);
                }
            },
        });

        this.save = function () {
            if (!_$movieInformationForm.valid()) {
                return;
            }

            var movie = _$movieInformationForm.serializeFormToObject();
            movie.Options = null;
            var categoryChosen = $('#CategoryCombobox').val();
            var categoryChosenId = parseInt(categoryChosen);
            if (isNaN(categoryChosenId)) {
                abp.message.warn(app.localize('MissingCategory'));
                return;
            }
            else
                movie.CategoryId = categoryChosenId;
            if (uploadedFileToken != null) {
                movie.ImageToken = uploadedFileToken.result;
            }
            _modalManager.setBusy(true);
            _movieService
                .createOrEdit(movie)
                .done(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    _modalManager.close();
                    abp.event.trigger('app.createOrEditMovieModalSaved');
                })
                .always(function () {
                    _modalManager.setBusy(false);
                });
        };

        $('.test-btn-datetime-picker').click(function () {
            var $datetimeInput = $(this).closest('.input-group').find('input');

            demoUiComponentsService
                .sendAndGetDateTime($datetimeInput.data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ssZ'))
                .done(function (result) {
                    abp.message.info(result.dateString, app.localize('PostedValue'));
                    abp.notify.info(app.localize('SavedSuccessfully'));
                });
        });

        $('.datetime-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L LT',
        });
    };
})(jQuery);