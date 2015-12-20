using System;
using System.Collections.Generic;
using System.Linq;

namespace LandmineWeb.Models
{
    public class InstructionsViewModel
    {
        public IEnumerable<KeyBindingDescription> KeyDescriptions { get; set; }
    }

    public class KeyBindingDescription
    {
        public bool IsWide { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
    }
}