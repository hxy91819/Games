using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleChessWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 棋盘参数定义
        /// <summary>
        /// X轴缩进
        /// </summary>
        const int INDEX_X = 35;
        /// <summary>
        /// Y轴缩进
        /// </summary>
        const int INDEX_Y = 35;
        /// <summary>
        /// 棋盘宽度
        /// </summary>
        const int CHESS_BOARD_WIDTH = 300;
        /// <summary>
        /// 棋子宽度
        /// </summary>
        const int CHESS_WIDTH = 54;
        /// <summary>
        /// 棋子高度
        /// </summary>
        const int CHESS_HEIGHT = 28;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 绘制一个棋盘
        /// </summary>
        private void drawChessBoard()
        {
            // Create a figure that describes a   
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH);
            myPathFigure.Segments.Add(new LineSegment(new Point(INDEX_X, INDEX_Y), true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH), true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y), true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH), true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH), true /* IsStroked */ ));

            /// Create a PathGeometry to contain the figure.  
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry.   
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;

            pnlChess.Children.Add(myPath);
        }

        private void drawTest()
        {
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 10);
            myPathFigure.Segments.Add(new LineSegment(new Point(100, 10), true));

            PathFigure myPathFigure2 = new PathFigure();
            myPathFigure2.StartPoint = new Point(10, 20);
            myPathFigure2.Segments.Add(new LineSegment(new Point(100, 20), true));

            /// Create a PathGeometry to contain the figure.  
            PathGeometry myPathGeometry = new PathGeometry();//可以组合不同的figure
            myPathGeometry.Figures.Add(myPathFigure);
            myPathGeometry.Figures.Add(myPathFigure2);

            // Display the PathGeometry.   
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;

            pnlChess.Children.Add(myPath);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            drawChessBoard();

            //drawTest();
        }
    }
}
