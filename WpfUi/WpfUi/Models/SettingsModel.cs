﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUi.Models
{
    public class SettingsModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Setting1 { get; set; } = 1;
        public int Setting2 { get; set; } = 2;
        public int Setting3 { get; set; } = 3;
        public bool DarkMode { get; set; } = false;
    }
}
