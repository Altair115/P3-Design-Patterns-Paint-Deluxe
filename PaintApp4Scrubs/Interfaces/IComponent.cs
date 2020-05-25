using PaintApp4Scrubs.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    public interface IComponent : IAccept
    {
        /// <summary>
        /// Gets & Sets the depth of the component for printing
        /// </summary>
        public string Depth { get; set; }
    }
}
