using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PaintApp4Scrubs.Classes;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs.Interfaces
{
    public interface IVisitor
    {
        /// <summary>
        /// Visitor Function for godShape
        /// </summary>
        /// <param name="godShape">Selected Shape</param>
        public void Visit(GodShape godShape);
        /// <summary>
        /// Visitor Function for boxer
        /// </summary>
        /// <param name="boxer">Selected Box</param>
        public void Visit(Boxer boxer);
        /// <summary>
        /// Visitor Function for square
        /// </summary>
        /// <param name="square">Selected Shape</param>
        public void VisitSquare(BaseShape square);
        /// <summary>
        /// Visitor Function for line
        /// </summary>
        /// <param name="line">Selected Shape</param>
        public void VisitLine(BaseShape line);
        /// <summary>
        /// Visitor Function for triangle
        /// </summary>
        /// <param name="triangle">Selected Shape</param>
        public void VisitTriangle(BaseShape triangle);
        /// <summary>
        /// Visitor Function for ellipse
        /// </summary>
        /// <param name="ellipse">Selected Shape</param>
        public void VisitEllipse(BaseShape ellipse);
    }
}
