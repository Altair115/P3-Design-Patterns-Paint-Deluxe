using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaintApp4Scrubs.Classes;
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Broker broker;
        public static MainWindow AppWindow;
        private enum TheShape
        {
            Line, Ellipse, Rectangle, Triangle, Move
        }

        private TheShape currShape = TheShape.Line;

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            broker = new Broker();
        }

        private void LineButton_OnClick(object sender, RoutedEventArgs e)
        {
            currShape = TheShape.Line;
        }

        private void EllipseButton_OnClick(object sender, RoutedEventArgs e)
        {
            currShape = TheShape.Ellipse;
        }

        private void RectangleButton_OnClick(object sender, RoutedEventArgs e)
        {
            currShape = TheShape.Rectangle;
        }
        private void TriangleButton_OnClick(object sender, RoutedEventArgs e)
        {
            currShape = TheShape.Triangle;
        }
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            currShape = TheShape.Move;
        }

        private Point startPoint;
        private Point endPoint;

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            startPoint = e.GetPosition(this);
            HitTestResult result = VisualTreeHelper.HitTest(Canvas, Mouse.GetPosition(Canvas));
            if (currShape == TheShape.Move)
            {
                if (result!= null)
                {
                    Canvas.Children.Remove(result.VisualHit as GodShape);
                }

            }
        }

        //private void GodShape_MouseMove(object sender, MouseEventArgs e)
        //{
        //    var rect = (GodShape)sender;
        //    var canvas = sender as Canvas;

        //    if (!rect.IsMouseCaptured) return;

        //    // get the position of the mouse relative to the Canvas
        //    var mousePos = e.GetPosition(canvas);

        //    // center the rect on the mouse
        //    double left = mousePos.X - (rect.ActualWidth / 2);
        //    double top = mousePos.Y - (rect.ActualHeight / 2);
        //    Canvas.SetLeft(rect, left);
        //    Canvas.SetTop(rect, top);
        //}


        private void Canvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (currShape)
            {
                case TheShape.Line :
                    DrawLine();
                    break;
                case TheShape.Ellipse:
                    DrawEllipse();
                    break;
                case TheShape.Rectangle:
                    DrawRectangle();
                    break;
                case TheShape.Triangle:
                    DrawTriangle();
                    break;
                case TheShape.Move:
                    break;
                default:
                    return;
            }
        }

        

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                endPoint = e.GetPosition(this);
            }
        }

        // Sets and draws line after mouse is released
        private void DrawLine()
        {
            Line newLine = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = startPoint.X,
                Y1 = startPoint.Y - 50,
                X2 = endPoint.X,
                Y2 = endPoint.Y - 50
            };
            Canvas.Children.Add(newLine);
        }

        // Sets and draws ellipse after mouse is released
        private void DrawEllipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.White,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            // If the user the user tries to draw from
            // any direction then down and to the right
            // you'll get an error unless you use if
            // to change Left & TopProperty and Height
            // and Width accordingly

            if (endPoint.X >= startPoint.X)
            {
                // Defines the left part of the ellipse
                newEllipse.SetValue(Canvas.LeftProperty, startPoint.X);
                newEllipse.Width = endPoint.X - startPoint.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, endPoint.X);
                newEllipse.Width = startPoint.X - endPoint.X;
            }

            if (endPoint.Y >= startPoint.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, startPoint.Y - 50);
                newEllipse.Height = endPoint.Y - startPoint.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, endPoint.Y - 50);
                newEllipse.Height = startPoint.Y - endPoint.Y;
            }

            Canvas.Children.Add(newEllipse);
        }

        // Sets and draws rectangle after mouse is released
        private void DrawRectangle()
        {
            Square square = new Square()
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.White,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };
            if (endPoint.X >= startPoint.X)
            {
                // Defines the left part of the ellipse
                square.SetValue(Canvas.LeftProperty, startPoint.X);
                square.Width = endPoint.X - startPoint.X;
            }
            else
            {
                square.SetValue(Canvas.LeftProperty, endPoint.X);
                square.Width = startPoint.X - endPoint.X;
            }

            if (endPoint.Y >= startPoint.Y)
            {
                // Defines the top part of the ellipse
                square.SetValue(Canvas.TopProperty, startPoint.Y - 50);
                square.Height = endPoint.Y - startPoint.Y;
            }
            else
            {
                square.SetValue(Canvas.TopProperty, endPoint.Y - 50);
                square.Height = startPoint.Y - endPoint.Y;
            }
            Draw draw = new Draw(square);
            broker.DoCommand(draw);

        }
        public void PutOnScreen(GodShape shape)
        {
            Canvas.Children.Add(shape);
        }

        private void DrawTriangle()
        {
            Triangle triangle = new Triangle() 
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.White,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };
            if (endPoint.X >= startPoint.X)
            {
                // Defines the left part of the ellipse
                triangle.SetValue(Canvas.LeftProperty, startPoint.X);
                triangle.Width = endPoint.X - startPoint.X;
            }
            else
            {
                triangle.SetValue(Canvas.LeftProperty, endPoint.X);
                triangle.Width = startPoint.X - endPoint.X;
            }

            if (endPoint.Y >= startPoint.Y)
            {
                // Defines the top part of the ellipse
                triangle.SetValue(Canvas.TopProperty, startPoint.Y - 50);
                triangle.Height = endPoint.Y - startPoint.Y;
            }
            else
            {
                triangle.SetValue(Canvas.TopProperty, endPoint.Y - 50);
                triangle.Height = startPoint.Y - endPoint.Y;
            }
            Canvas.Children.Add(triangle);
        }
    }
}
