﻿using PaintApp4Scrubs.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    public interface IComponent : IAccept
    {
        public string Depth { get; set; }
    }
}
