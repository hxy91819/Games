using System.Windows.Controls;

namespace SimpleChessWPF
{
    /// <summary>
    /// 棋子类
    /// </summary>
    public class Chess
    {
        private ChessPoint inChessPoint;
        private Grid chessGrid;
        private bool selected;
        private int camp;
        public Chess()
        {
            selected = false;
        }
        /// <summary>
        /// 棋子所在的棋盘点
        /// </summary>
        public ChessPoint InChessPoint
        {
            get
            {
                return inChessPoint;
            }

            set
            {
                inChessPoint = value;
            }
        }
        /// <summary>
        /// 棋子所对应的展示对象Grid
        /// </summary>
        public Grid ChessGrid
        {
            get
            {
                return chessGrid;
            }

            set
            {
                chessGrid = value;
            }
        }
        /// <summary>
        /// 棋子是否被选中
        /// </summary>
        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
            }
        }
        /// <summary>
        /// 棋子阵营 0 红， 1 黑
        /// </summary>
        public int Camp
        {
            get
            {
                return camp;
            }

            set
            {
                camp = value;
            }
        }
    }
}
