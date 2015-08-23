using System;
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
        /// <summary>
        /// 用于绘制棋盘所使用的Points
        /// </summary>
        private Point[] points = new Point[5];
        /// <summary>
        /// 棋子在棋盘上可以走的位置
        /// </summary>
        private ChessPoint[] chessPoints = new ChessPoint[5];
        /// <summary>
        /// 棋子
        /// </summary>
        private Chess[] chesses = new Chess[4];
        /// <summary>
        /// 棋子位置类
        /// </summary>
        private ChessPosition[] chessPos = new ChessPosition[5];
        private bool isLocated = false;//是否已经为棋盘的点、棋子进行定位
        private int selectedChessID;//选中的棋子ID
        private Border[] chessBorders = new Border[4];//棋子的边框
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 绘制一个棋盘
        /// </summary>
        private void drawChessBoard()
        {
            //iniLocation();
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

            cvsChess.Children.Add(myPath);
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

            //设置棋子位置，需要考虑棋子本身的宽高
            chessPos[0] = new ChessPosition(INDEX_X - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);
            chessPos[1] = new ChessPosition(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);
            chessPos[2] = new ChessPosition(INDEX_X + CHESS_BOARD_WIDTH / 2 - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH / 2 - CHESS_HEIGHT / 2);
            chessPos[3] = new ChessPosition(INDEX_X - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2);
            chessPos[4] = new ChessPosition(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2);
            return true;
        }
        /// <summary>
        /// 创建/初始化棋盘（给棋盘上每个点赋值定义）
        /// </summary>
        private void createChessPoints()
        {
            //必须为每个数组对象创建实例。
            for (int i = 0; i < 5; i++)
            {
                chessPoints[i] = new ChessPoint();
            }
            #region 初始化棋盘可行走的点的属性，并配置各个点之间的关联性
            //绑定棋盘上的点到此类中
            //这将决定了每个点可以走向的点
            //1
            chessPoints[0].DownChesspoint = chessPoints[3];
            chessPoints[0].RightDownChesspoint = chessPoints[2];
            chessPoints[0].ChessPos = chessPos[0];

            //2
            chessPoints[1].LeftDownChesspoint = chessPoints[2];
            chessPoints[1].DownChesspoint = chessPoints[4];
            chessPoints[1].ChessPos = chessPos[1];

            //3
            chessPoints[2].LeftUpChesspoint = chessPoints[0];
            chessPoints[2].RightUpChesspoint = chessPoints[1];
            chessPoints[2].LeftDownChesspoint = chessPoints[3];
            chessPoints[2].RightDownChesspoint = chessPoints[4];
            chessPoints[2].ChessPos = chessPos[2];
            //4
            chessPoints[3].UpChesspoint = chessPoints[0];
            chessPoints[3].RightUpChesspoint = chessPoints[2];
            chessPoints[3].RightChesspoint = chessPoints[4];
            chessPoints[3].ChessPos = chessPos[3];
            //5
            chessPoints[4].UpChesspoint = chessPoints[1];
            chessPoints[4].LeftUpChesspoint = chessPoints[2];
            chessPoints[4].LeftChesspoint = chessPoints[3];
            chessPoints[4].ChessPos = chessPos[4];
            #endregion
        }
        /// <summary>
        /// 创建棋子，并绘制到棋盘上
        /// </summary>
        private void createChess()
        {
            //End Here!!!
            //棋子一共有四颗，初始位置为四个角。序号从上至下，从左至右。颜色上红，下黑。
            int chessCount = 0;//棋子的数量，棋子应该只有4颗
            for (int i = 0; i < 5; i++)
            {
                //如果操作的棋子数，大于4了，则应该跳出
                if (chessCount >= 4)
                {
                    break;
                }
                //初始状态i == 2处没有棋子
                if (i == 2)
                {
                    continue;
                }
                chesses[chessCount] = new Chess();
                chesses[chessCount].InChessPoint = chessPoints[i];//设置棋子在棋盘上的点
                chesses[chessCount].ChessGrid = new Grid();
                chesses[chessCount].ChessGrid.Width = CHESS_WIDTH;
                chesses[chessCount].ChessGrid.Height = CHESS_HEIGHT;
                chessPoints[i].OnChess = chesses[chessCount];//设置棋盘上的点上的棋子
                if (i == 0 || i == 1)
                {
                    chesses[chessCount].Camp = 0;
                    //    chesses[chessCount].ChessGrid.Background = Brushes.Red;
                }
                else
                {
                    chesses[chessCount].Camp = 1;
                    //    chesses[chessCount].ChessGrid.Background = Brushes.Black;
                }
                cvsChess.Children.Add(chesses[chessCount].ChessGrid);
                Canvas.SetTop(chesses[chessCount].ChessGrid, chesses[chessCount].InChessPoint.ChessPos.Top);
                Canvas.SetLeft(chesses[chessCount].ChessGrid, chesses[chessCount].InChessPoint.ChessPos.Left);
                chessCount++;
            }
            //选中第一个棋子
            chesses[0].Selected = true;
            setChessGridStyle();
        }
        /// <summary>
        /// 根据棋子的属性，设置棋子的展示体(Grid的颜色、选中状态）
        /// </summary>
        /// <param name="chess"></param>
        private void setChessGridStyle(int chessID = -1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (chessID != -1)
                {
                    i = chessID;
                }

                if (chesses[i].Selected)
                {
                    selectedChessID = i;
                    //给棋子设置一个边框
                    chesses[i].ChessGrid.ShowGridLines = true;

                    chesses[i].ChessGrid.Children.Add(chessBorders[i]);
                    //为选中的棋子设置CtrlPanel
                    setCtrlPanel(i);
                }
                else
                {
                    //没选中则取消边框
                    chesses[i].ChessGrid.ShowGridLines = false;
                    chesses[i].ChessGrid.Children.Remove(chessBorders[i]);
                }
                //设置棋子的颜色
                if (chesses[i].Camp == 0)
                {
                    chesses[i].ChessGrid.Background = Brushes.Red;
                }
                else
                {
                    chesses[i].ChessGrid.Background = Brushes.Blue;
                }

                if (chessID != -1)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 根据当前选中的棋子设置控制面板（仅使可操作的按钮能够使用）
        /// </summary>
        private void setCtrlPanel(int chessID)
        {
            //根据棋子的属性，来设置按钮的可用性
            if (chesses[chessID].InChessPoint.LeftUpChesspoint == null || chesses[chessID].InChessPoint.LeftUpChesspoint.OnChess != null)
            {
                btnLeftUp.IsEnabled = false;
            }
            else
            {
                btnLeftUp.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.UpChesspoint == null || chesses[chessID].InChessPoint.UpChesspoint.OnChess != null)
            {
                btnUp.IsEnabled = false;
            }
            else
            {
                btnUp.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.RightUpChesspoint == null || chesses[chessID].InChessPoint.RightUpChesspoint.OnChess != null)
            {
                btnRightUp.IsEnabled = false;
            }
            else
            {
                btnRightUp.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.LeftChesspoint == null || chesses[chessID].InChessPoint.LeftChesspoint.OnChess != null)
            {
                btnLeft.IsEnabled = false;
            }
            else
            {
                btnLeft.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.RightChesspoint == null || chesses[chessID].InChessPoint.RightChesspoint.OnChess != null)
            {
                btnRight.IsEnabled = false;
            }
            else
            {
                btnRight.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.LeftDownChesspoint == null || chesses[chessID].InChessPoint.LeftDownChesspoint.OnChess != null)
            {
                btnLeftDown.IsEnabled = false;
            }
            else
            {
                btnLeftDown.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.DownChesspoint == null || chesses[chessID].InChessPoint.DownChesspoint.OnChess != null)
            {
                btnDown.IsEnabled = false;
            }
            else
            {
                btnDown.IsEnabled = true;
            }

            if (chesses[chessID].InChessPoint.RightDownChesspoint == null || chesses[chessID].InChessPoint.RightDownChesspoint.OnChess != null)
            {
                btnRightDown.IsEnabled = false;
            }
            else
            {
                btnRightDown.IsEnabled = true;
            }
        }
        /// <summary>
        /// 移动棋子
        /// </summary>
        private void moveChess(int btnTagVal, int chessID)
        {
            if (!chesses[chessID].Selected)
            {
                writeLog("移动棋子发生错误，使用了错误的棋子ID chessID = " + chessID);
                return;
            }
            //移动前需要取消原来棋盘上的点
            chesses[chessID].InChessPoint.OnChess = null;
            //根据控制按钮的tag值来判断是做了什么移动，然后将棋子移动到指定位置（无需判断移动位置是否合法）
            switch (btnTagVal)
            {
                case 1:
                    //重新设置棋子在棋盘上的位置，并重绘，
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.LeftUpChesspoint;
                    break;
                case 2:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.UpChesspoint;
                    break;
                case 3:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.RightUpChesspoint;
                    break;
                case 4:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.LeftChesspoint;
                    break;
                case 5:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.RightChesspoint;
                    break;
                case 6:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.LeftDownChesspoint;
                    break;
                case 7:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.DownChesspoint;
                    break;
                case 8:
                    chesses[chessID].InChessPoint = chesses[chessID].InChessPoint.RightDownChesspoint;
                    break;
                default:
                    break;
            }
            //移动后需要重新配置棋盘上的点
            chesses[chessID].InChessPoint.OnChess = chesses[chessID];
            //重绘
            Canvas.SetTop(chesses[chessID].ChessGrid, chesses[chessID].InChessPoint.ChessPos.Top);
            Canvas.SetLeft(chesses[chessID].ChessGrid, chesses[chessID].InChessPoint.ChessPos.Left);
            //选中另一阵营的棋子
            chesses[chessID].Selected = false;
            int campType = chesses[chessID].Camp;
            for (int i = 0; i < 4; i++)
            {
                if (i == chessID)
                {
                    continue;
                }
                if (chesses[i].Camp != campType)
                {
                    selectedChessID = i;
                    chesses[i].Selected = true;
                    break;
                }
            }
            //重新绘制棋子
            setChessGridStyle();
        }
        #region 测试代码
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

            cvsChess.Children.Add(myPath);
        }
        #endregion

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            writeLog("Game starts!");
        }

        private void FrmMain_Loaded(object sender, RoutedEventArgs e)
        {
            isLocated = iniLocation();
            if (!isLocated)
            {
                writeLog("Load failed! Sorry!");
            }

            for (int i = 0; i < 4; i++)
            {
                chessBorders[i] = new Border() { BorderBrush = new SolidColorBrush(Colors.Yellow), BorderThickness = new Thickness(3) };
                Grid.SetRow(chessBorders[i], 0);
                Grid.SetColumn(chessBorders[i], 0);
            }
            drawChessBoard();
            createChessPoints();
            createChess();
            writeLog("Thank you for playing SimpleChess, have fun!");
        }

        private void btnCtrl_Click(object sender, RoutedEventArgs e)
        {
            Button btnCtrl = (Button)sender;
            moveChess(Convert.ToInt32(btnCtrl.Tag.ToString()), selectedChessID);
        }
        /// <summary>
        /// 切换棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwith_Click(object sender, RoutedEventArgs e)
        {
            //选中另一阵营的棋子
            chesses[selectedChessID].Selected = false;
            int campType = chesses[selectedChessID].Camp;
            for (int i = 0; i < 4; i++)
            {
                if (i == selectedChessID)
                {
                    continue;
                }
                if (chesses[i].Camp == campType)
                {
                    selectedChessID = i;
                    chesses[i].Selected = true;
                    break;
                }
            }
            //重新绘制棋子
            setChessGridStyle();
        }
    }
}
