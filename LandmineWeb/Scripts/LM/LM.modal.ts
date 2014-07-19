/// <reference path="../jquery.d.ts" />

interface JQuery {
    modal(command: string): JQuery
    modal(any): JQuery;   
    modal(): JQuery
}
module LM {
    export module Modal {
        export interface ModalSuccessCallback { (JQuery) : void  }

        var $modal: JQuery;
        var successCallback: ModalSuccessCallback;

        export interface ModalOptions {
            success?: ModalSuccessCallback;
            title?: string;
        }

        export function show(options?: ModalOptions): JQuery {
            if (!options) {
                options = {};
            }

            $modal = $('.modal').first();

            if (options.title) {
                $modal.find('.modal-title').html(options.title);
            }

            if (options.success) {
                successCallback = options.success;
            }

            $modal.modal();

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
