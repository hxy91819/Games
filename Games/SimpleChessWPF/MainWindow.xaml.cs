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
        private Point[] points = new Point[5];
        private Thickness[] thicknesses = new Thickness[5];
        private Chesspoint[] chessPoints = new Chesspoint[5];
        private Chess[] chesses = new Chess[5];
        private bool isLocated = false;//是否已经为棋盘的点、棋子进行定位
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 绘制一个棋盘
        /// </summary>
        private void drawChessBoard()
        {
            iniLocation();
            //设定Point的轨迹，完成一个一笔画
            // Create a figure that describes a   
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = points[3];
            myPathFigure.Segments.Add(new LineSegment(points[0], true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(points[4], true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(points[1], true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(points[3], true /* IsStroked */ ));
            myPathFigure.Segments.Add(new LineSegment(points[4], true /* IsStroked */ ));

            /// Create a PathGeometry to contain the figure.  
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry.   
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;

            grdChess.Children.Add(myPath);
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="logInfo"></param>
        private void writeLog(string logInfo)
        {
            rtbLog.AppendText(logInfo + "\r\n");
        }
        /// <summary>
        /// 初始化定位点
        /// </summary>
        private bool iniLocation()
        {
            //从上至下，从左至右，依次顺序
            points[0] = new Point(INDEX_X, INDEX_Y);//左上
            points[1] = new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y);//右上
            points[2] = new Point(INDEX_X + CHESS_BOARD_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH / 2);//中间
            points[3] = new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH);//左下
            points[4] = new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH);//右下

            thicknesses[0] = new Thickness(INDEX_X, INDEX_Y, 0, 0);//左上
            thicknesses[1] = new Thickness(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y, 0, 0);//右上
            thicknesses[2] = new Thickness(INDEX_X + CHESS_BOARD_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH / 2, 0, 0);//中间
            thicknesses[3] = new Thickness(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH, 0, 0);//左下
            thicknesses[4] = new Thickness(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH, 0, 0);//右下
            return true;
        }
        /// <summary>
        /// 创建/初始化棋盘（给棋盘上每个点赋值定义）
        /// </summary>
        private void createChessPoints()
        {
            #region 初始化棋盘可行走的点的属性，并配置各个点之间的关联性
            //绑定棋盘上的点到此类中
            //这将决定了每个点可以走向的点
            //1
            //chessPoints[0].DownChesspoint = chessPoints[3];
            //chessPoints[0].RightDownChesspoint = chessPoints[2];
            chessPoints[0].ChessThickness = thicknesses[0];

            /*
            //2
            chessPoints[1].LeftDownChesspoint = chessPoints[2];
            chessPoints[1].DownChesspoint = chessPoints[4];
            chessPoints[1].ChessThickness = thicknesses[1];

            //3
            chessPoints[2].LeftUpChesspoint = chessPoints[0];
            chessPoints[2].RightUpChesspoint = chessPoints[1];
            chessPoints[2].LeftDownChesspoint = chessPoints[3];
            chessPoints[2].RightDownChesspoint = chessPoints[4];
            chessPoints[2].ChessThickness = thicknesses[2];
            //4
            chessPoints[3].UpChesspoint = chessPoints[0];
            chessPoints[3].RightUpChesspoint = chessPoints[2];
            chessPoints[3].RightChesspoint = chessPoints[4];
            chessPoints[3].ChessThickness = thicknesses[3];
            //5
            chessPoints[4].UpChesspoint = chessPoints[1];
            chessPoints[4].LeftUpChesspoint = chessPoints[2];
            chessPoints[4].LeftChesspoint = chessPoints[3];
            chessPoints[4].ChessThickness = thicknesses[4];
            */
            #endregion
        }
        /// <summary>
        /// 创建棋子，并绘制到棋盘上
        /// </summary>
        private void createChess()
        {
            //End Here!!!
            //棋子一共有四颗，初始位置为四个角。序号从上至下，从左至右。颜色上红，下黑。
            chesses[0].InChessPoint = chessPoints[0];
            chesses[0].ChessGrid = new Grid();
            chesses[0].ChessGrid.Width = CHESS_WIDTH;
            chesses[0].ChessGrid.Height = CHESS_HEIGHT;
            chesses[0].ChessGrid.Background = Brushes.Red;
            grdChess.Children.Add(chesses[0].ChessGrid);
            chesses[0].setGridPosition();
        }
        /// <summary>
        /// 不连续线条绘画测试
        /// </summary>
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

            grdChess.Children.Add(myPath);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            writeLog("Game starts!");
        }

        private void FrmMain_Loaded(object sender, RoutedEventArgs e)
        {
            isLocated = iniLocation();
            if(!isLocated)
            {
                writeLog("Load failed! Sorry!");
            }
            drawChessBoard();
            createChessPoints();
            createChess();
            writeLog("Thank you for playing SimpleChess, have fun!");
        }
    }
}
