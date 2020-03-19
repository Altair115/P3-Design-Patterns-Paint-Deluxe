using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using PaintApp4Scrubs.Classes;
using PaintApp4Scrubs.Classes.Commands;
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
        private GodShape selectedShape;
        private enum ModeSwitch
        {
            Line,
            Ellipse,
            Rectangle,
            Triangle,
            Delete,
            Move,
            Resize
        }

        private ModeSwitch _currentMode = ModeSwitch.Line;

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            broker = new Broker();
        }

        #region Button Calls
        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void RedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void LineButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Line;
        }

        private void EllipseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Ellipse;
        }

        private void RectangleButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Rectangle;
        }
        private void TriangleButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Triangle;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Delete;
        }
        private void ResizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Resize;
        }

        private void MoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Move;
        }
        #endregion

        private Point _currentPoint; //the current mouse
        private Point _startPoint;
        private Point _endPoint;

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(this);
            HitTestResult result =
                VisualTreeHelper.HitTest(Canvas, Mouse.GetPosition(Canvas));
            selectedShape = result.VisualHit as GodShape;
            if (_currentMode == ModeSwitch.Delete)
            {
                DeleteShape(result.VisualHit as GodShape);
            }
        }

        private void Canvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (_currentMode)
            {
                case ModeSwitch.Line:
                    DrawLine();
                    break;
                case ModeSwitch.Ellipse:
                    DrawEllipse();
                    break;
                case ModeSwitch.Rectangle:
                    DrawRectangle();
                    break;
                case ModeSwitch.Triangle:
                    DrawTriangle();
                    break;
                case ModeSwitch.Resize:
                    ResizeShape(selectedShape);
                    selectedShape = null;
                    break;
                default:
                    return;
            }
        }

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            _currentPoint = e.GetPosition(Canvas);
            LabelCoords.Content = "Current X:" + _currentPoint.X.ToString() + System.Environment.NewLine + "Current Y:" + _currentPoint.Y.ToString();
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _endPoint = e.GetPosition(this);
            }
        }

        #region DrawStrategies
        // Sets and draws line after mouse is released
        private void DrawLine()
        {
            Line newLine = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = _startPoint.X,
                Y1 = _startPoint.Y - 50,
                X2 = _endPoint.X,
                Y2 = _endPoint.Y - 50
            };
            Draw draw = new Draw(newLine);
            broker.DoCommand(draw);
        }

        // Sets and draws ellipse after mouse is released
        private void DrawEllipse()
        {
            Ellipse newEllipse =
                new Ellipse()
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

            if (_endPoint.X >= _startPoint.X)
            {
                // Defines the left part of the ellipse
                newEllipse.SetValue(Canvas.LeftProperty, _startPoint.X);
                newEllipse.Width = _endPoint.X - _startPoint.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, _endPoint.X);
                newEllipse.Width = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                newEllipse.Height = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                newEllipse.Height = _startPoint.Y - _endPoint.Y;
            }
            Draw draw = new Draw(newEllipse);
            broker.DoCommand(draw);
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
            if (_endPoint.X >= _startPoint.X)
            {
                // Defines the left part of the ellipse
                square.SetValue(Canvas.LeftProperty, _startPoint.X);
                square.Width = _endPoint.X - _startPoint.X;
            }
            else
            {
                square.SetValue(Canvas.LeftProperty, _endPoint.X);
                square.Width = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                square.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                square.Height = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                square.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                square.Height = _startPoint.Y - _endPoint.Y;
            }
            Draw draw = new Draw(square);
            broker.DoCommand(draw);
        }

        private void DrawTriangle()
        {
            Triangle triangle =
                new Triangle()
                {
                    Stroke = Brushes.Blue,
                    Fill = Brushes.White,
                    StrokeThickness = 4,
                    Height = 10,
                    Width = 10
                };
            if (_endPoint.X >= _startPoint.X)
            {
                // Defines the left part of the ellipse
                triangle.SetValue(Canvas.LeftProperty, _startPoint.X);
                triangle.Width = _endPoint.X - _startPoint.X;
            }
            else
            {
                triangle.SetValue(Canvas.LeftProperty, _endPoint.X);
                triangle.Width = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                triangle.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                triangle.Height = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                triangle.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                triangle.Height = _startPoint.Y - _endPoint.Y;
            }
            Draw draw = new Draw(triangle);
            broker.DoCommand(draw);
        }
        #endregion

        public void PutOnScreen(GodShape shape)
        {
            Canvas.Children.Add(shape);
        }
        public void DeleteShape(GodShape shape)
        {
            if (shape == null)
                return;
            Delete delete = new Delete(shape);
            broker.DoCommand(delete);
        }
        public void RemoveShape(GodShape shape)
        {
            Canvas.Children.Remove(shape);
        }

        public void ResizeShape(GodShape shape)
        {
            if (shape == null)
            {
                return;
            }
            Vector distance = _startPoint - _endPoint;
            Resize resize = new Resize(shape, distance);
            broker.DoCommand(resize);
        }
    }
}
