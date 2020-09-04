/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.languages = 'vi';
    //<script src="~/Scripts/ckeditor/ckeditor.js"></script>
   // <script src="~/Assets/Admin/js/plugins/ckeditor/ckeditor.js"></script>
    config.filebrowserBrowseUrl = '/Assets/Admin/js/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/Admin/js/plugins/ckfinder.html?Types=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/Admin/js/plugins/ckfinder.html?Types=Flash';
    config.filebrowserUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File';
    config.filebrowserImageUploadUrl = '/Assets/Admin/js/plugins/Data';
    config.filebrowserFlashUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Assets/Admin/js/plugins/ckfinder/');
};
