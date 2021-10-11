ClassicEditor
    .create(document.querySelector('.ckEditor'), {
        toolbar: {
            items: [
                'heading',
                '|',
                'alignment',
                'bold',
                'italic',
                'bulletedList',
                'numberedList',
                '|',
                'outdent',
                'indent',
                'blockQuote',
                'insertTable',
                'horizontalLine',
                'undo',
                'redo'
            ]
        },
        ckfinder: {
            uploadUrl: '/Home/CkUploadImage'
        },
        language: 'fa',
        image: {
            toolbar: [
                'imageTextAlternative',
                'imageStyle:full',
                'imageStyle:side'
            ]
        },
        table: {
            contentToolbar: [
                'tableColumn',
                'tableRow',
                'mergeTableCells'
            ]
        },

    })
    .then(editor => {
        editor.isReadOnly = editor.sourceElement.disabled;
        window.editor = editor;
    })
    .catch(error => {
        console.error('Oops, something went wrong!');
        console.error(error);
    });