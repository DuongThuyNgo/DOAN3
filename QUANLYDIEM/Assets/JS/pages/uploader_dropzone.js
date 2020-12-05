/* ------------------------------------------------------------------------------
*
*  # Dropzone multiple file uploader
*
*  Specific JS code additions for uploader_dropzone.html page
*
*  Version: 1.0
*  Latest update: Aug 1, 2015
*
* ---------------------------------------------------------------------------- */

$(function() {

    // Defaults
    Dropzone.autoDiscover = false;

    // Single file
    $("#dropzone_single").dropzone({
        paramName: "file", // The name that will be used to transfer the file
        maxFilesize: 100, // MB
        maxFiles: 1,
        dictDefaultMessage: 'Lựa chọn file database cần khôi phục',
        autoProcessQueue: true,
        init: function() {
            this.on('addedfile', function(file){
                if (this.fileTracker) {
                this.removeFile(this.fileTracker);
            }
                this.fileTracker = file;
                AjaxLoader();
            });
            this.on("complete", function (data) {
                UnAjaxLoader();
                window.location.replace("/Admin/Index");
            });
        }
    }); 
    
});
