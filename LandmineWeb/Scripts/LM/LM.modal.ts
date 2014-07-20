/// <reference path="../jquery.d.ts" />

interface JQuery {
    modal(command: string): JQuery
    modal(any): JQuery;   
    modal(): JQuery
}
module LM {
    export module Modal {
        export interface ModalSuccessCallback { (JQuery): void }
        export interface ModalClosedCallback { (JQuery): void }

        var $modal: JQuery;
        var successCallback: ModalSuccessCallback;
        var closedCallback: ModalClosedCallback;

        export interface ModalOptions {
            success?: ModalSuccessCallback;
            title?: string;
            closed?: ModalClosedCallback;
        }

        function createModal() : void {
            $modal = $('.modal').first();
                $modal.modal({
                show: false
            });

                $modal.on("hidden.bs.modal", () => {
                if (closedCallback) {
                    closedCallback($modal);
                }
            });
        }

        export function show(options?: ModalOptions): JQuery {
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

        export function close(): void {
            $modal.modal('hide');
            $modal = null;
            successCallback = null;
        }

        var modalSuccess = function () {
            if (successCallback) successCallback($modal);

            close();
        };

        $('.modal .btn-primary').click(modalSuccess);
    }
}
