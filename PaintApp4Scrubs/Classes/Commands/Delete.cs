using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaintApp4Scrubs.Classes.Commands
{
class Delete : ICommand
{
    private GodShape shape;
    public Delete(GodShape _shape)
    {
        shape = _shape;
    }
    public void Execute()
    {
        shape.Remove();
    }

    public void UnExecute()
    {
        shape.Draw();
    }
}
}
