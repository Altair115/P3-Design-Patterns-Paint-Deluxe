using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
        private readonly Broker _broker;
        public static MainWindow AppWindow;
        private GodShape _selectedShape;
        private readonly List<IComponent> _boxList = new List<IComponent>();
        private readonly Boxer _box;

        private enum ModeSwitch
        {
            Line,
            Ellipse,
            Rectangle,
            Triangle,
            Delete,
            Move,
            Resize,
            Selector,
            Display
        }

        private ModeSwitch _currentMode = ModeSwitch.Line;

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            _broker = new Broker();
            _box = new Boxer(true);
        }

        #region Button Calls

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            _broker.UndoCommand();
        }

        private void RedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            _broker.RedoCommand();
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

        private void SelectorButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Selector;
        }

        private void GroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddToGroup(_boxList);
        }

        private void DisplayButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentMode = ModeSwitch.Display;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFile saveFile = new SaveFile(_box);
            _broker.DoCommand(saveFile);

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
            _selectedShape = result.VisualHit as GodShape;
        }

        /// <summary>
        /// this function ditermens witch method to call based on te mode witch the user has selected 
        /// </summary>
        /// <param name="sender">the mouse</param>
        /// <param name="e">the date for the selected mouse events</param>
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
                    if (_selectedShape != null)
                    {
                        ResizeShape(_selectedShape);
                        _selectedShape = null;
                    }

                    break;
                case ModeSwitch.Move:
                    if (_selectedShape != null)
                    {
                        MoveShape(_selectedShape);
                        _selectedShape = null;
                    }

                    break;
                case ModeSwitch.Delete:
                    if (_selectedShape != null)
                    {
                        DeleteShape(_selectedShape);
                        _selectedShape = null;
                    }

                    break;
                case ModeSwitch.Selector:
                    AddToBoxList(_selectedShape);
                    break;
                case ModeSwitch.Display:
                    if (_selectedShape != null)
                    {
                        DisplayGroup(_selectedShape);
                        _selectedShape = null;
                    }

                    break;
                default:
                    return;
            }
        }

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            _currentPoint = e.GetPosition(Canvas);
            LabelCoords.Content = "Current X:" + _currentPoint.X.ToString() + System.Environment.NewLine +
                                  "Current Y:" + _currentPoint.Y.ToString();
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
                StrokeThickness = 4,
                X1 = _startPoint.X,
                Y1 = _startPoint.Y - 50,
                X2 = _endPoint.X,
                Y2 = _endPoint.Y - 50
            };
            DrawShape(newLine);
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
                newEllipse.XRadius = _endPoint.X - _startPoint.X;

            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, _endPoint.X);
                newEllipse.XRadius = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                newEllipse.YRadius = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                newEllipse.YRadius = _startPoint.Y - _endPoint.Y;
            }

            DrawShape(newEllipse);
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

            DrawShape(square);
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

            DrawShape(triangle);
        }

        #endregion

        public IComponent BoxFinder(IComponent shape)
        {
            IComponent component = _box.FindBox(shape as GodShape);
            if (component != null)
                shape = component;
            return shape;
        }

        #region Command calls

        private void DrawShape(GodShape shape)
        {
            Draw draw = new Draw(shape);
            _broker.DoCommand(draw);
            _box.Add(shape);

        }

        /// <summary>
        /// picks the selected shape and uses the command pattern to call the Move command 
        /// </summary>
        /// <param name="selectedShape">selected shape </param>
        public void MoveShape(GodShape selectedShape)
        {
            int distanceFix = 50;
            Vector endPoint = (Vector)_endPoint;
            Vector startPoint = (Vector)_startPoint;
            endPoint.Y -= distanceFix;
            startPoint.Y -= distanceFix;
            Move move = new Move(BoxFinder(selectedShape), endPoint, startPoint);
            _broker.DoCommand(move);
        }

        /// <summary>
        /// puts the shape on the canvas
        /// </summary>
        /// <param name="shape">the selected </param>
        public void PutOnScreen(GodShape shape)
        {
            Canvas.Children.Add(shape);
        }

        /// <summary>
        /// creates the command to delete the selected shape
        /// </summary>
        /// <param name="selectedShape">The selected shape</param>
        public void DeleteShape(IComponent selectedShape)
        {
            if (selectedShape == null)
                return;

            Delete delete = new Delete(BoxFinder(selectedShape));
            _broker.DoCommand(delete);
            _box.Detach(selectedShape);
        }

        /// <summary>
        /// Removes the shape of the canvas given by the delete command 
        /// </summary>
        /// <param name="shape">the shape from the delete command </param>
        public void RemoveShape(GodShape shape)
        {
            Canvas.Children.Remove(shape);
        }

        /// <summary>
        /// picks the selected and creates an resize command to resize the selected shape 
        /// </summary>
        /// <param name="selectedShape">The selected shape</param>
        public void ResizeShape(IComponent selectedShape)
        {
            if (selectedShape == null)
                return;

            Vector distance = _startPoint - _endPoint;
            Resize resize = new Resize(BoxFinder(selectedShape), distance);
            _broker.DoCommand(resize);
        }
        
        public void AddToBoxList(IComponent selectedComponent)
        {
            if (selectedComponent == null)
                return;

            IComponent component = _box.FindBox(selectedComponent as GodShape);
            if (component == null)
            {
                _boxList.Add(selectedComponent);
            }
            else
            {
                if (!_boxList.Contains(component))
                {
                    _boxList.Add(component);
                }
            }
        }

        public void AddToGroup(List<IComponent> components)
        {
            MakeGroup makeGroup = new MakeGroup(components, _box);
            _broker.DoCommand(makeGroup);
            _boxList.Clear();
        }

        public void DisplayGroup(IComponent shape)
        {
            if (shape == null)
                return;

            DisplayGroup displayGroup = new DisplayGroup(BoxFinder(shape));
            _broker.DoCommand(displayGroup);
        }
    }
    #endregion

};

