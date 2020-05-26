using System.Collections.Generic;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PaintApp4Scrubs.Classes;
using PaintApp4Scrubs.Classes.Commands;
using PaintApp4Scrubs.Classes.Shapes;
using PaintApp4Scrubs.Classes.Stratagies;
using PaintApp4Scrubs.Classes.Strategies;
using Decorator = PaintApp4Scrubs.Classes.Decorator;

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
        private readonly List<GodShape> _boxList = new List<GodShape>();
        private readonly Boxer _box;
        private readonly List<ComboBoxLinker> _comboBoxLinkers = new List<ComboBoxLinker>();

        private int _comboBoxIndex = 0;

        /// <summary>
        /// Enums for modes 
        /// </summary>
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
        /// <summary>
        /// constructor for the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            _broker = new Broker();
            _box = new Boxer();
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

        private void SetNames_OnClick(object sender, RoutedEventArgs e)
        {
            if (OrnamentBox != null && OrnamentName != null)
            {
                fixi();
            }
        }

        #endregion

        private Point _currentPoint; //the current mouse position
        private Point _startPoint;
        private Point _endPoint;

        private void OrnamentBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (OrnamentBox != null && OrnamentName != null)
            {
                fixi();
                foreach (var itemBoxLinker in _comboBoxLinkers)
                {
                    if (OrnamentBox.Items[OrnamentBox.SelectedIndex].ToString().Split(" ")[1] == itemBoxLinker.PositionString)
                    {
                        OrnamentName.Text = itemBoxLinker.TextBoxName;
                    }
                }
                _comboBoxIndex = OrnamentBox.SelectedIndex;
            }
        }

        private void fixi()
        {
            ComboBoxLinker comboBoxLinker = new ComboBoxLinker {TextBoxName = OrnamentName.Text, PositionString = OrnamentBox.SelectionBoxItem.ToString() };
            foreach (var item in _comboBoxLinkers)
            {
                if (item.PositionString == comboBoxLinker.PositionString && item.TextBoxName != comboBoxLinker.TextBoxName)
                {
                    _comboBoxLinkers.Remove(item);
                    _comboBoxLinkers.Add(comboBoxLinker);
                    return;
                }

                if (item.PositionString == comboBoxLinker.PositionString && item.TextBoxName == comboBoxLinker.TextBoxName)
                    return;
            }
            _comboBoxLinkers.Add(comboBoxLinker);
        }

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(this);
            HitTestResult result =
                VisualTreeHelper.HitTest(Canvas, Mouse.GetPosition(Canvas));
            _selectedShape = result.VisualHit as GodShape;
        }

        /// <summary>
        /// this function determines witch method has to be called based on te mode which the user has selected 
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

        private GodShape MakeOrnaments(BaseShape shape)
        {
            List<Ornament> ornaments = new List<Ornament>();
            if (_comboBoxLinkers.Count != 0)
            {
                for (int i = 0; i < _comboBoxLinkers.Count; i++)
                {
                    if (i == 0)
                    {
                        Ornament ornament = new Ornament(shape);
                        ornaments.Add(ornament);
                    }
                    else
                    {
                        var x = ornaments[i - 1];
                        Ornament ornament = new Ornament(x);
                        ornaments.Add(ornament);
                    }
                    ornaments[i].Position = _comboBoxLinkers[i].PositionString;
                    ornaments[i].Name = _comboBoxLinkers[i].TextBoxName;
                }
                _comboBoxLinkers.Clear();
                return ornaments[^1];
            }
            return shape;
        }

        #region Draw Calls

        /// <summary>
        ///  Sets and draws line after mouse is released
        /// </summary>
        private void DrawLine()
        {
            BaseShape newLine = new BaseShape(new LineStrategies(_startPoint, _endPoint))
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 4
            };
            DrawShape(MakeOrnaments(newLine));
        }
        /// <summary>
        /// Sets and draws ellipse after mouse is released
        /// </summary>
        private void DrawEllipse()
        {
            BaseShape newEllipse =
                new BaseShape(new EllipseStrategies(10, 10))
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
                newEllipse.StrategyHeight = _endPoint.X - _startPoint.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, _endPoint.X);
                newEllipse.StrategyHeight = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                newEllipse.StrategyWidth = _endPoint.Y - _startPoint.Y;

            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                newEllipse.StrategyWidth = _startPoint.Y - _endPoint.Y;
            }

            DrawShape(MakeOrnaments(newEllipse));
        }

        /// <summary>
        ///  Sets and draws rectangle after mouse is released
        /// </summary>
        private void DrawRectangle()
        {
            BaseShape square = new BaseShape(new SquareStrategies(10, 10))
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.White,
                StrokeThickness = 4,
                StrategyHeight = 10,
                StrategyWidth = 10,
                Width = 10,
                Height = 10
            };
            if (_endPoint.X >= _startPoint.X)
            {
                // Defines the left part of the ellipse
                square.SetValue(Canvas.LeftProperty, _startPoint.X);
                square.StrategyWidth = _endPoint.X - _startPoint.X;
                square.Width = _endPoint.X - _startPoint.X;
            }
            else
            {
                square.SetValue(Canvas.LeftProperty, _endPoint.X);
                square.StrategyWidth = _startPoint.X - _endPoint.X;
                square.Width = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                square.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                square.StrategyHeight = _endPoint.Y - _startPoint.Y;
                square.Height = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                square.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                square.StrategyHeight = _startPoint.Y - _endPoint.Y;
                square.Height = _startPoint.Y - _endPoint.Y;
            }

            DrawShape(MakeOrnaments(square));
        }
        /// <summary>
        /// Sets and draws Triangle after mouse is released
        /// </summary>
        private void DrawTriangle()
        {
            BaseShape triangle =
                new BaseShape(new TriangleStrategies(10, 10))
                {
                    Stroke = Brushes.Blue,
                    Fill = Brushes.White,
                    StrokeThickness = 4,
                    StrategyHeight = 10,
                    StrategyWidth = 10,
                    Height = 10,
                    Width = 10
                };

            if (_endPoint.X >= _startPoint.X)
            {
                // Defines the left part of the ellipse
                triangle.SetValue(Canvas.LeftProperty, _startPoint.X);
                triangle.StrategyWidth = _endPoint.X - _startPoint.X;
                triangle.Width = _endPoint.X - _startPoint.X;
            }
            else
            {
                triangle.SetValue(Canvas.LeftProperty, _endPoint.X);
                triangle.StrategyWidth = _startPoint.X - _endPoint.X;
                triangle.Width = _startPoint.X - _endPoint.X;
            }

            if (_endPoint.Y >= _startPoint.Y)
            {
                // Defines the top part of the ellipse
                triangle.SetValue(Canvas.TopProperty, _startPoint.Y - 50);
                triangle.StrategyHeight = _endPoint.Y - _startPoint.Y;
                triangle.Height = _endPoint.Y - _startPoint.Y;
            }
            else
            {
                triangle.SetValue(Canvas.TopProperty, _endPoint.Y - 50);
                triangle.StrategyHeight = _startPoint.Y - _endPoint.Y;
                triangle.Height = _startPoint.Y - _endPoint.Y;
            }

            DrawShape(MakeOrnaments(triangle));
        }

        #endregion
        /// <summary>
        /// find the parent box of shape
        /// </summary>
        /// <param name="shape">the selected shape</param>
        /// <returns>box or a shape</returns>
        private GodShape BoxFinder(GodShape shape)
        {
            GodShape component = _box.FindBox(shape);
            if (component != null)
                shape = component;
            return shape;
        }

        #region Command calls
        /// <summary>
        /// makes a command call to draw a shape
        /// </summary>
        /// <param name="shape">the shape to be drawn</param>
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
        private void MoveShape(GodShape selectedShape)
        {
            int distanceFix = 50;
            Vector endPoint = (Vector)_endPoint;
            Vector startPoint = (Vector)_startPoint;
            endPoint.Y -= distanceFix;
            startPoint.Y -= distanceFix;

            Move move = new Move(BoxFinder(FindDecorator(selectedShape)), endPoint, startPoint);
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
        public void PutOnScreen(TextBlock decorator)
        {
            Canvas.Children.Add(decorator);
        }

        /// <summary>
        /// creates the command to delete the selected shape
        /// </summary>
        /// <param name="selectedShape">The selected shape</param>
        private void DeleteShape(GodShape selectedShape)
        {
            if (selectedShape == null)
                return;
            Delete delete = new Delete(BoxFinder(FindDecorator(selectedShape)));
            _broker.DoCommand(delete);
            _box.Detach(selectedShape);
        }
        private GodShape FindDecorator(GodShape selectedShape, Boxer boxer = null)
        {
            if (boxer == null)
                boxer = _box;

            foreach (var decorator in boxer.GetChildren())
            {
                if (decorator is Decorator deco && selectedShape == deco.GetBaseShape())
                {
                    return deco;
                }

                if (decorator is Boxer box)
                {
                    selectedShape = FindDecorator(selectedShape, box);
                }
            }
            return selectedShape;
        }

        /// <summary>
        /// Removes the shape of the canvas given by the delete command 
        /// </summary>
        /// <param name="shape">the shape from the delete command </param>
        public void RemoveShape(GodShape shape)
        {
            Canvas.Children.Remove(shape);
        }
        public void RemoveShape(TextBlock shape)
        {
            Canvas.Children.Remove(shape);
        }

        /// <summary>
        /// picks the selected and creates an resize command to resize the selected shape 
        /// </summary>
        /// <param name="selectedShape">The selected shape</param>
        private void ResizeShape(GodShape selectedShape)
        {
            if (selectedShape == null)
                return;

            Vector distance = _startPoint - _endPoint;
            Resize resize = new Resize(BoxFinder(FindDecorator(selectedShape)), distance);
            _broker.DoCommand(resize);
        }

        /// <summary>
        /// adds a box or a shape to the main list(box) of the canvas
        /// </summary>
        /// <param name="selectedComponent">the selected shape or box</param>
        private void AddToBoxList(GodShape selectedComponent)
        {
            if (selectedComponent == null)
                return;
            var x = FindDecorator(selectedComponent);
            GodShape component = _box.FindBox(x);
            if (component == null)
            {
                _boxList.Add(x);
            }
            else
            {
                if (!_boxList.Contains(component))
                {
                    _boxList.Add(component);
                }
            }
        }

        /// <summary>
        /// makes a command call to make a group of objects
        /// </summary>
        /// <param name="components">a list of boxes or shapes </param>
        private void AddToGroup(List<GodShape> components)
        {
            MakeGroup makeGroup = new MakeGroup(components, _box);
            _broker.DoCommand(makeGroup);
            _boxList.Clear();
        }
        /// <summary>
        /// makes a command call to print the hierarchy on the selected shape
        /// </summary>
        /// <param name="shape">the selected shape</param>
        private void DisplayGroup(GodShape shape)
        {
            if (shape == null)
                return;

            DisplayGroup displayGroup = new DisplayGroup(BoxFinder(shape));
            _broker.DoCommand(displayGroup);
        }


    }
    #endregion
};