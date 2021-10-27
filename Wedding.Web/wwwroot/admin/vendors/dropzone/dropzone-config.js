Dropzone.autoDiscover = false;
$('.dropzone').each(function (index) {
    $(this).dropzone({
        url: '/apanel/Home/UploadImage',
        init: function () {
            this.on("complete",
                function (file) {
                    this.removeFile(file);
                });
        },
        dictDefaultMessage: "برای ارسال فایل را اینجا بکشید یا کلیک کنید",
        dictFallbackMessage: "مرورگر شما از کشیدن و رها سازی برای ارسال فایل پشتیبانی نمی کند.",
        dictFallbackText: "لطفا از فرم زیر برای ارسال فایل های خود مانند گذشته استفاده کنید.",
        dictFileTooBig: "فایل خیلی بزرگ است ({{filesize}}MiB). حداکثر اندازه مجاز: {{maxFilesize}}MiB.",
        dictInvalidFileType: "شما مجاز به ارسال این نوع فایل نیستید.",
        dictResponseError: "سرور با کد {{statusCode}} پاسخ داد.",
        dictCancelUpload: "لغو ارسال",
        dictUploadCanceled: "ارسال لغو شد.",
        dictCancelUploadConfirmation: "آیا از لغو این ارسال اطمینان دارید؟",
        dictRemoveFile: "حذف فایل",
        dictRemoveFileConfirmation: "آیا از حذف این فایل اطمینان دارید؟",
        dictMaxFilesExceeded: "شما نمی توانید فایل دیگری ارسال کنید.",
        success: function (file, response) {
            var currentDropzone = $(this.element);
            var input = currentDropzone.data('input');
            var container = currentDropzone.data('container');
            if (input != undefined) {
                $("#" + input).val(response);
            }
            if (container != undefined) {
                $("#" + container).show();
                var image = $("#" + container).find("img");
                image.attr("src", "/UploadedFiles/Images/" + response);
            }
        },
        transformFile: function (file, done) {

            var myDropZone = this;

            // Create the image editor overlay
            var editor = document.createElement('div');
            editor.style.position = 'fixed';
            editor.style.left = 0;
            editor.style.right = 0;
            editor.style.top = 0;
            editor.style.bottom = 0;
            editor.style.zIndex = 9999;
            editor.style.backgroundColor = '#000';

            // Create the confirm button
            var confirm = document.createElement('button');
            confirm.style.position = 'absolute';
            confirm.style.left = '10px';
            confirm.style.top = '10px';
            confirm.style.zIndex = 9999;
            confirm.textContent = 'برش تصویر';
            confirm.classList.add("btn");
            confirm.classList.add("btn-primary");
            confirm.addEventListener('click',
                function () {

                    // Get the canvas with image data from Cropper.js
                    var canvas = cropper.getCroppedCanvas({
                        minWidth: 256,
                        minHeight: 256,
                        maxWidth: 4096,
                        maxHeight: 4096,
                        fillColor: '#fff',
                        imageSmoothingEnabled: true,
                        imageSmoothingQuality: 'high',
                    });

                    // Turn the canvas into a Blob (file object without a name)
                    canvas.toBlob(function (blob) {

                        // Update the image thumbnail with the new image data
                        myDropZone.createThumbnail(
                            blob,
                            myDropZone.options.thumbnailWidth,
                            myDropZone.options.thumbnailHeight,
                            myDropZone.options.thumbnailMethod,
                            false,
                            function (dataURL) {

                                // Update the Dropzone file thumbnail
                                myDropZone.emit('thumbnail', file, dataURL);

                                // Return modified file to dropzone
                                done(blob);
                            }
                        );

                    });

                    // Remove the editor from view
                    editor.parentNode.removeChild(editor);

                });
            editor.appendChild(confirm);
            // Load the image
            var image = new Image();
            image.src = URL.createObjectURL(file);
            editor.appendChild(image);

            // Append the editor to the page
            document.body.appendChild(editor);
            var currentDropzone = $(this.element);
            var xAxis = parseInt(currentDropzone.data("x"));
            var yAxis = parseInt(currentDropzone.data("y"));
            if (xAxis == undefined || isNaN(xAxis)) {
                xAxis = 1;
            }
            if (yAxis == undefined || isNaN(yAxis)) {
                yAxis = 1;
            }
            // Create Cropper.js and pass image
            var cropper = new Cropper(image,
                {
                    aspectRatio: xAxis / yAxis,
                    cropBoxResizable: true,
                });

        }
    });
});
//Dropzone.options.dropzone = {
//    url: '/apanel/Home/UploadImage',
//    init: function () {
//        this.on("complete",
//            function (file) {
//                this.removeFile(file);
//            });
//    },
//    dictDefaultMessage: "برای ارسال فایل را اینجا بکشید یا کلیک کنید",
//    dictFallbackMessage: "مرورگر شما از کشیدن و رها سازی برای ارسال فایل پشتیبانی نمی کند.",
//    dictFallbackText: "لطفا از فرم زیر برای ارسال فایل های خود مانند گذشته استفاده کنید.",
//    dictFileTooBig: "فایل خیلی بزرگ است ({{filesize}}MiB). حداکثر اندازه مجاز: {{maxFilesize}}MiB.",
//    dictInvalidFileType: "شما مجاز به ارسال این نوع فایل نیستید.",
//    dictResponseError: "سرور با کد {{statusCode}} پاسخ داد.",
//    dictCancelUpload: "لغو ارسال",
//    dictUploadCanceled: "ارسال لغو شد.",
//    dictCancelUploadConfirmation: "آیا از لغو این ارسال اطمینان دارید؟",
//    dictRemoveFile: "حذف فایل",
//    dictRemoveFileConfirmation: "آیا از حذف این فایل اطمینان دارید؟",
//    dictMaxFilesExceeded: "شما نمی توانید فایل دیگری ارسال کنید.",
//    success: function (file, response) {
//        var currentDropzone = $(this.element);
//        var input = currentDropzone.data('input');
//        var container = currentDropzone.data('container');
//        if (input != undefined) {
//            $("#" + input).val(response);
//        }
//        if (container != undefined) {
//            $("#" + container).show();
//            var image = $("#" + container).find("img");
//            image.attr("src", "/UploadedFiles/Images/" + response);
//        }
//    },
//    transformFile: function (file, done) {

//        var myDropZone = this;

//        // Create the image editor overlay
//        var editor = document.createElement('div');
//        editor.style.position = 'fixed';
//        editor.style.left = 0;
//        editor.style.right = 0;
//        editor.style.top = 0;
//        editor.style.bottom = 0;
//        editor.style.zIndex = 9999;
//        editor.style.backgroundColor = '#000';

//        // Create the confirm button
//        var confirm = document.createElement('button');
//        confirm.style.position = 'absolute';
//        confirm.style.left = '10px';
//        confirm.style.top = '10px';
//        confirm.style.zIndex = 9999;
//        confirm.textContent = 'برش تصویر';
//        confirm.classList.add("btn");
//        confirm.classList.add("btn-primary");
//        confirm.addEventListener('click', function () {

//            // Get the canvas with image data from Cropper.js
//            var canvas = cropper.getCroppedCanvas({
//                minWidth: 256,
//                minHeight: 256,
//                maxWidth: 4096,
//                maxHeight: 4096,
//                fillColor: '#fff',
//                imageSmoothingEnabled: true,
//                imageSmoothingQuality: 'high',
//            });

//            // Turn the canvas into a Blob (file object without a name)
//            canvas.toBlob(function (blob) {

//                // Update the image thumbnail with the new image data
//                myDropZone.createThumbnail(
//                    blob,
//                    myDropZone.options.thumbnailWidth,
//                    myDropZone.options.thumbnailHeight,
//                    myDropZone.options.thumbnailMethod,
//                    false,
//                    function (dataURL) {

//                        // Update the Dropzone file thumbnail
//                        myDropZone.emit('thumbnail', file, dataURL);

//                        // Return modified file to dropzone
//                        done(blob);
//                    }
//                );

//            });

//            // Remove the editor from view
//            editor.parentNode.removeChild(editor);

//        });
//        editor.appendChild(confirm);
//        // Load the image
//        var image = new Image();
//        image.src = URL.createObjectURL(file);
//        editor.appendChild(image);

//        // Append the editor to the page
//        document.body.appendChild(editor);
//        var currentDropzone = $(this);
//        var xAxis = parseInt(currentDropzone.data("x"));
//        var yAxis = parseInt(currentDropzone.data("y"));
//        if (xAxis == undefined || isNaN(xAxis)) {
//            xAxis = 1;
//        }
//        if (yAxis == undefined || isNaN(yAxis)) {
//            yAxis = 1;
//        }
//        // Create Cropper.js and pass image
//        var cropper = new Cropper(image, {
//            aspectRatio: xAxis / yAxis,
//            cropBoxResizable: true,
//        });

//    }
//};
