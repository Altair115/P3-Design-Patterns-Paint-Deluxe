using PaintApp4Scrubs.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace PaintApp4Scrubs.Classes
{
    public interface IComponent : IAccept
    {
        public  void Resize(Vector distance);
        public void Move(Vector newPosition);
        public void Remove();
        public void Display(){}
        public void Display(List<IComponent> children = null, string indent = "", bool head = true){}
        public void ClearFile();

        public Vector GetCenter();
    }
}
