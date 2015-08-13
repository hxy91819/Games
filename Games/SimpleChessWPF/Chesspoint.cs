using System.Windows;

namespace SimpleChessWPF
{
    /// <summary>
    /// 棋盘可以行动的点
    /// </summary>
    public class Chesspoint
    {
        /// <summary>
        /// 棋盘此点上棋子的ID：无，0；红1，1；红2，2；黑1，1；黑2，2。
        /// </summary>
        private Chess onChess;
        #region 设置棋子八象限关联棋子属性
        private Chesspoint leftUpChesspoint;
        private Chesspoint upChesspoint;
        private Chesspoint rightUpChesspoint;
        private Chesspoint leftChesspoint;
        private Chesspoint rightChesspoint;
        private Chesspoint leftDownChesspoint;
        private Chesspoint downChesspoint;
        private Chesspoint rightDownChesspoint;
        #endregion
        /// <summary>
        /// 棋盘此点的给panel放置的位置
        /// </summary>
        private Thickness chessThickness; 
        public Chesspoint()
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

        public Chesspoint LeftUpChesspoint
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

        public Chesspoint UpChesspoint
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

        public Chesspoint RightUpChesspoint
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

        public Chesspoint LeftChesspoint
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

        public Chesspoint RightChesspoint
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

        public Chesspoint LeftDownChesspoint
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

        public Chesspoint DownChesspoint
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

        public Chesspoint RightDownChesspoint
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

        public Thickness ChessThickness
        {
            get
            {
                return chessThickness;
            }

            set
            {
                chessThickness = value;
            }
        }
    }
}
