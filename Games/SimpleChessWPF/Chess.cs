using System.Windows.Controls;

namespace SimpleChessWPF
{
    /// <summary>
    /// 棋子类
    /// </summary>
    public class Chess
    {
        private Chesspoint inChessPoint;
        private Grid chessGrid;

        /// <summary>
        /// 棋子所在的棋盘点
        /// </summary>
        public Chesspoint InChessPoint
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

        public bool setGridPosition()
        {
            if(this.ChessGrid == null || this.InChessPoint == null)
            {
                return false;
            }
            //InChessPoint.ChessPoint
            this.ChessGrid.Margin = InChessPoint.ChessThickness;
            return true;
        }

    }
}
