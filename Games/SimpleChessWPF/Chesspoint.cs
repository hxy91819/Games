using System.Windows;

namespace SimpleChessWPF
{
    /// <summary>
    /// 棋盘可以行动的点
    /// </summary>
    public class ChessPoint
    {
        /// <summary>
        /// 棋盘此点上棋子的ID：无，0；红1，1；红2，2；黑1，1；黑2，2。
        /// </summary>
        private Chess onChess;
        #region 设置棋子八象限关联棋子属性
        private ChessPoint leftUpChesspoint;
        private ChessPoint upChesspoint;
        private ChessPoint rightUpChesspoint;
        private ChessPoint leftChesspoint;
        private ChessPoint rightChesspoint;
        private ChessPoint leftDownChesspoint;
        private ChessPoint downChesspoint;
        private ChessPoint rightDownChesspoint;
        #endregion
        /// <summary>
        /// 棋盘此点的给panel放置的位置
        /// </summary>
        private ChessPosition chessPos;
        public ChessPoint()
        {
            leftUpChesspoint = null;
            upChesspoint = null;
            rightChesspoint = null;
            leftChesspoint = null;
            rightChesspoint = null;
            leftDownChesspoint = null;
            downChesspoint = null;
            rightDownChesspoint = null;
        }

        public ChessPoint LeftUpChesspoint
        {
            get
            {
                return leftUpChesspoint;
            }

            set
            {
                leftUpChesspoint = value;
            }
        }

        public ChessPoint UpChesspoint
        {
            get
            {
                return upChesspoint;
            }

            set
            {
                upChesspoint = value;
            }
        }

        public ChessPoint RightUpChesspoint
        {
            get
            {
                return rightUpChesspoint;
            }

            set
            {
                rightUpChesspoint = value;
            }
        }

        public ChessPoint LeftChesspoint
        {
            get
            {
                return leftChesspoint;
            }

            set
            {
                leftChesspoint = value;
            }
        }

        public ChessPoint RightChesspoint
        {
            get
            {
                return rightChesspoint;
            }

            set
            {
                rightChesspoint = value;
            }
        }

        public ChessPoint LeftDownChesspoint
        {
            get
            {
                return leftDownChesspoint;
            }

            set
            {
                leftDownChesspoint = value;
            }
        }

        public ChessPoint DownChesspoint
        {
            get
            {
                return downChesspoint;
            }

            set
            {
                downChesspoint = value;
            }
        }

        public ChessPoint RightDownChesspoint
        {
            get
            {
                return rightDownChesspoint;
            }

            set
            {
                rightDownChesspoint = value;
            }
        }

        /// <summary>
        /// 棋盘上的棋子
        /// </summary>
        public Chess OnChess
        {
            get
            {
                return onChess;
            }

            set
            {
                onChess = value;
            }
        }

        public ChessPosition ChessPos
        {
            get
            {
                return chessPos;
            }

            set
            {
                chessPos = value;
            }
        }
    }
}
