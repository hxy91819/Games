using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleChess
{
    public partial class FrmChess : Form
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

        private Chessponit leftUpChesspoint;
        private Chessponit rightUpChesspoint;
        private Chessponit MiddleChesspoint;
        private Chessponit leftDownChesspoint;
        private Chessponit rightDownChesspoint;

        public FrmChess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制棋盘
        /// </summary>
        private void drawChessBoard()
        {
            Graphics g = pnlChessBoard.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //画出左侧竖线
            g.DrawLine(Pens.Blue, new Point(INDEX_X, INDEX_Y), new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH));
            //画出底部横线
            g.DrawLine(Pens.Blue, new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH), new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH));
            //画出右侧竖线
            g.DrawLine(Pens.Blue, new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y), new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH));
            //画出交叉线
            g.DrawLine(Pens.Blue, new Point(INDEX_X, INDEX_Y), new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y + CHESS_BOARD_WIDTH));
            g.DrawLine(Pens.Blue, new Point(INDEX_X, INDEX_Y + CHESS_BOARD_WIDTH), new Point(INDEX_X + CHESS_BOARD_WIDTH, INDEX_Y));
        }
        /// <summary>
        /// 创建棋子
        /// </summary>
        private void createChess()
        {
            //使用panel作为chess
            Panel pnlChessRed1 = new Panel();
            pnlChessBoard.Controls.Add(pnlChessRed1);
            pnlChessRed1.Size = new System.Drawing.Size(CHESS_WIDTH, CHESS_HEIGHT);//设置棋子宽度
            pnlChessRed1.Location = new System.Drawing.Point(INDEX_X - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);//设置棋子初始位置
            pnlChessRed1.BackColor = Color.Red;

            Panel pnlChessRed2 = new Panel();
            pnlChessBoard.Controls.Add(pnlChessRed2);
            pnlChessRed2.Size = new System.Drawing.Size(CHESS_WIDTH, CHESS_HEIGHT);//设置棋子宽度
            pnlChessRed2.Location = new System.Drawing.Point(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);//设置棋子初始位置
            pnlChessRed2.BackColor = Color.Red;

            Panel pnlChessBlack1 = new Panel();
            pnlChessBoard.Controls.Add(pnlChessBlack1);
            pnlChessBlack1.Size = new System.Drawing.Size(CHESS_WIDTH, CHESS_HEIGHT);//设置棋子宽度
            pnlChessBlack1.Location = new System.Drawing.Point(INDEX_X - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2);//设置棋子初始位置
            pnlChessBlack1.BackColor = Color.Black;

            Panel pnlChessBlack2 = new Panel();
            pnlChessBoard.Controls.Add(pnlChessBlack2);
            pnlChessBlack2.Size = new System.Drawing.Size(CHESS_WIDTH, CHESS_HEIGHT);//设置棋子宽度
            pnlChessBlack2.Location = new System.Drawing.Point(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2);//设置棋子初始位置
            pnlChessBlack2.BackColor = Color.Black;

        }

        /// <summary>
        /// 在日志框中写入日志
        /// </summary>
        /// <param name="forWrite"></param>
        private void wirteLog(string forWrite)
        {
            richTextBoxLog.AppendText(forWrite + "\n");
        }

        private void frmChess_Load(object sender, EventArgs e)
        {
            this.wirteLog("欢迎进入" + this.Text);
            this.wirteLog("版本：" + ProjectConst.VERSION);
            #region 初始化棋盘可行走的点的属性，并配置各个点之间的关联性
            //绑定棋盘上的点到此类中
            this.leftUpChesspoint = new Chessponit();
            this.rightUpChesspoint = new Chessponit();
            this.MiddleChesspoint = new Chessponit();
            this.leftDownChesspoint = new Chessponit();
            this.rightDownChesspoint = new Chessponit();

            //1
            this.leftUpChesspoint.ChessIDInt = 1;
            this.leftUpChesspoint.DownChesspoint = this.leftDownChesspoint;
            this.leftUpChesspoint.RightDownChesspoint = this.MiddleChesspoint;
            this.leftUpChesspoint.ChessPoint = new Point(INDEX_X - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);

            //2
            this.rightUpChesspoint.ChessIDInt = 2;
            this.rightUpChesspoint.LeftDownChesspoint = this.MiddleChesspoint;
            this.rightUpChesspoint.DownChesspoint = this.rightDownChesspoint;
            this.rightUpChesspoint.ChessPoint = new Point(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y - CHESS_HEIGHT / 2);

            //3
            this.MiddleChesspoint.LeftUpChesspoint = this.leftUpChesspoint;
            this.MiddleChesspoint.RightUpChesspoint = this.rightUpChesspoint;
            this.MiddleChesspoint.LeftDownChesspoint = this.leftDownChesspoint;
            this.MiddleChesspoint.RightDownChesspoint = this.rightDownChesspoint;
            this.MiddleChesspoint.ChessPoint = new Point(INDEX_X + CHESS_BOARD_WIDTH / 2 - CHESS_WIDTH / 2,
                INDEX_Y + CHESS_BOARD_WIDTH / 2 - CHESS_HEIGHT / 2);
            //4
            this.leftDownChesspoint.ChessIDInt = 3;
            this.leftDownChesspoint.UpChesspoint = this.leftUpChesspoint;
            this.leftDownChesspoint.RightUpChesspoint = this.MiddleChesspoint;
            this.leftDownChesspoint.RightChesspoint = this.rightDownChesspoint;
            this.leftDownChesspoint.ChessPoint = new Point(INDEX_X - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2);
            //5
            this.rightDownChesspoint.ChessIDInt = 4;
            this.rightDownChesspoint.UpChesspoint = this.rightUpChesspoint;
            this.rightDownChesspoint.LeftUpChesspoint = this.MiddleChesspoint;
            this.rightDownChesspoint.LeftChesspoint = this.leftDownChesspoint;
            this.rightDownChesspoint.ChessPoint = new Point(INDEX_X + CHESS_BOARD_WIDTH - CHESS_WIDTH / 2, INDEX_Y + CHESS_BOARD_WIDTH - CHESS_HEIGHT / 2); 
            #endregion

            tmrLazyLoad.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.wirteLog("开始游戏...");
            this.createChess();
        }

        /// <summary>
        /// 加载窗体时，延迟做的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLazyLoad_Tick(object sender, EventArgs e)
        {
            //需要延迟绘画，否则会被windows绘制窗体所覆盖
            this.drawChessBoard();
        }
    }
}
