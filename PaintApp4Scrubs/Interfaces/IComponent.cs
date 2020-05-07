using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    public interface IComponent
    {
        public  void Resize(Vector distance);
        public void Move(Vector newPosition);
        public void Remove();
    }
}
