﻿using System.Windows;
using System.Windows.Media;
using PaintApp4Scrubs.Classes.Strategies;
using PaintApp4Scrubs.Interfaces;

namespace PaintApp4Scrubs.Classes.Shapes
{
    /// <summary>
    /// The Base Shape where all shapes are equal ("hail communism" ) https://www.youtube.com/watch?v=BulFwGSi8bc
    /// </summary>
    public class BaseShape : GodShape, IAccept
    {
        public IStrategy Strategy;
        /// </summary>
        /// set and gets the Strategy related Width
        /// <summary>
        public override double StrategyWidth
        {
            get => Strategy.Width;
            set => Strategy.Width = value;
        }
        /// </summary>
        /// set and gets the Strategy related Height
        /// <summary>
        public override double StrategyHeight
        {
            get => Strategy.Height;
            set => Strategy.Height = value;
        }

        /// <summary>
        /// set and gets the Strategy related StartPoint
        /// </summary>
        public Point StartPoint
        {
            get => Strategy.StartPoint;
            set => Strategy.StartPoint = value;
        }

        /// <summary>
        /// set and gets the Strategy related EndPoint
        /// </summary>
        public Point EndPoint
        {
            get => Strategy.EndPoint;
            set => Strategy.EndPoint = value;
        }
        /// <summary>
        /// the constructor of BaseShape
        /// </summary>
        /// <param name="s">the selected Strategy </param>
        public BaseShape(IStrategy s)
        {
            Strategy = s;
        }
        /// <param name="visitor">the selected visitor</param>
        /// </summary>
        /// The Visitor Accept Method for the selected strategy
        /// <summary>
        public override GodShape GetBaseShape()
        {
            return this;
        }

        public override void Accept(IVisitor visitor)
        {
            Strategy.Accept(visitor,this);
        }

        /// <summary>
        /// defines the geometry of the shape with the strategy 
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get { return Strategy.GetGeometry(); }

        }
        /// <summary>
        /// the string of the strategy 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Strategy.GetString(this);
        }

        public override Vector GetCenter()
        {
            return Strategy.GetCenter(this);
        }
    }
}