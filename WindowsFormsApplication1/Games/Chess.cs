using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleChess
{
    /// <summary>
    /// 棋子类
    /// </summary>
    public class Chess
    {
        private Chessponit inChessPoint;
        private Panel chessPanel;

        /// <summary>
        /// 棋子所在的棋盘点
        /// </summary>
        public Chessponit InChessPoint
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
        /// 棋子所对应的显示棋子（panel）
        /// </summary>
        public Panel ChessPanel
        {
            get
            {
                return chessPanel;
            }

            set
            {
                chessPanel = value;
            }
        }
    }
}
