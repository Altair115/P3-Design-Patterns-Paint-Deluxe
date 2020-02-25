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
using PaintApp4Scrubs.Classes.Shapes;

namespace PaintApp4Scrubs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum TheShape
        {
            Line, Ellipse, Rectangle
        }

        private TheShape currShape = TheShape.Line;

        public MainWindow()
        {
            InitializeComponent();
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

        private Point startPoint;
        private Point endPoint;

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this);
        }

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
            Canvas.Children.Add(square);
        }
    }
}
