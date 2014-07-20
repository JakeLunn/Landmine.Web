/// <reference path="../jquery.d.ts" />
var LM;
(function (LM) {
    (function (Modal) {
        var $modal;
        var successCallback;
        var closedCallback;

        function createModal() {
            $modal = $('.modal').first();
            $modal.modal({
                show: false
            });

            $modal.on("hidden.bs.modal", function () {
                if (closedCallback) {
                    closedCallback($modal);
                }
            });
        }

        function show(options) {
            if (!options) {
                options = {};
            }

            if (!$modal) {
                createModal();
            }

            if (options.title) {
                $modal.find('.modal-title').html(options.title);
            }

            if (options.success) {
                successCallback = options.success;
            }

            if (options.closed) {
                closedCallback = options.closed;
            }

            $modal.modal('show');

            return $modal;
        }
        Modal.show = show;

        function close() {
            $modal.modal('hide');
            $modal = null;
            successCallback = null;
        }
        Modal.close = close;

        var modalSuccess = function () {
            if (successCallback)
                successCallback($modal);

            close();
        };

        $('.modal .btn-primary').click(modalSuccess);
    })(LM.Modal || (LM.Modal = {}));
    var Modal = LM.Modal;
})(LM || (LM = {}));
//# sourceMappingURL=LM.modal.js.map
