﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmineWeb.HtmlHelpers
{
    public class Modal : IDisposable
    {
        

        private HtmlHelper helper;
        private string title;
        private string closeText;
        private string okText;

        public Modal(HtmlHelper helper, string title, string closeText, string okText)
        {
            this.title = title;
            this.closeText = closeText;
            this.okText = okText;
            this.helper = helper;

            helper.ViewContext.Writer.Write(
                @"<div class='modal fade'>
                  <div class='modal-dialog'>
                    <div class='modal-content'>
                      <div class='modal-header'>
                        <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button>
                        <h4 class='modal-title'>{0}</h4>
                      </div>
                      <div class='modal-body'>", title);
        }
        public void Dispose()
        {
            helper.ViewContext.Writer.Write(
                @"</div>
                  <div class='modal-footer'>
                    <button type='button' class='btn btn-default' data-dismiss='modal'>{0}</button>
                    <button type='button' class='btn btn-primary'>{1}</button>
                  </div>
                </div>
              </div>
            </div>", closeText, okText);
        }
    }

    public static class ModalExtension
    {
        public static Modal BeginModal(this HtmlHelper html, string title = "Alert", string closeText = "Close", string okText = "OK")
        {
            return new Modal(html, title, closeText, okText);
        }
    }
}