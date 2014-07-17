(function () {
    var LM = window.LM || (window.LM = {});
    LM.Modal = {};

    var callback = null,
        $modal = null;

    var modalSuccess = function () {
        if (callback) callback($modal);

        LM.Modal.close();
    };

    LM.Modal.show = function (options) {
        if (!options) options = {};

        if (options.success) {
            callback = options.success;
        }

        $modal = $('.modal').first();

        if (options.title) $modal.find('.modal-title').html(options.title);

        $modal.modal();

        return $modal;
    };

    LM.Modal.close = function () {
        $modal.modal('hide');
        $modal = null;
        callback = null;
    }

    $('.modal .btn-primary').click(modalSuccess);
})();