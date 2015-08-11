using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SimpleChess
{
    /// <summary>
    /// 棋盘可以行动的点
    /// </summary>
    public class Chessponit
    {
        /// <summary>
        /// 棋盘此点上棋子的ID：无，0；红1，1；红2，2；黑1，1；黑2，2。
        /// </summary>
        private int chessIDInt;
        #region 设置棋子八象限关联棋子属性
        private Chessponit leftUpChesspoint;
        private Chessponit upChesspoint;
        private Chessponit rightUpChesspoint;
        private Chessponit leftChesspoint;
        private Chessponit rightChesspoint;
        private Chessponit leftDownChesspoint;
        private Chessponit downChesspoint;
        private Chessponit rightDownChesspoint;
        #endregion
        /// <summary>
        /// 棋盘此点的给panel放置的位置
        /// </summary>
        private Point chessPoint; 
        public Chessponit()
        {
            chessIDInt = 0;
            leftUpChesspoint = null;
            upChesspoint = null;
            rightChesspoint = null;
            leftChesspoint = null;
            rightChesspoint = null;
            leftDownChesspoint = null;
            downChesspoint = null;
            rightDownChesspoint = null;
        }
        public int ChessIDInt
        {
            get
            {
                return chessIDInt;
            }

            set
            {
                chessIDInt = value;
            }
        }

        public Chessponit LeftUpChesspoint
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

        public Chessponit UpChesspoint
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

        public Chessponit RightUpChesspoint
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

        public Chessponit LeftChesspoint
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

        public Chessponit RightChesspoint
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

        public Chessponit LeftDownChesspoint
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

        public Chessponit DownChesspoint
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

        public Chessponit RightDownChesspoint
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

        public Point ChessPoint
        {
            get
            {
                return chessPoint;
            }

            set
            {
                chessPoint = value;
            }
        }
    }
}
