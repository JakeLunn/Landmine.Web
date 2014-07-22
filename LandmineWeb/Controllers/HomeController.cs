using LandmineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmineWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Instructions()
        {
            var instructions = new InstructionsViewModel
            {
                KeyDescriptions = new KeyBindingDescription[] {
                    new KeyBindingDescription { Key = "Enter",  Description = "Confirm dialogs, start the game.", IsWide = true},
                    new KeyBindingDescription { Key = "&rarr;", Description = "Move the cursor one space to the right."},
                    new KeyBindingDescription { Key = "&larr;", Description = "Move the cursor one space to the left."},
                    new KeyBindingDescription { Key = "&uarr;", Description = "Move the cursor one space to up."},
                    new KeyBindingDescription { Key = "&darr;", Description = "Move the cursor one space down."},
                    new KeyBindingDescription { Key = "Shift",  Description = "Dig the space under the cursor.", IsWide = true},
                    new KeyBindingDescription { Key = "Z",      Description = "Plant a flag at the cursor."}
                }
            };
            return View(instructions);
        }
    }
}