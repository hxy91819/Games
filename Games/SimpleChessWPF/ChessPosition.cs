using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChessWPF
{
    /// <summary>
    /// 棋子位置
    /// </summary>
    public class ChessPosition
    {
        private double left;
        private double top;

        public ChessPosition(double dleft, double dtop)
        {
            this.Left = dleft;
            this.Top = dtop;
        }

        public double Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public double Top
        {
            get
            {
                return top;
            }

            set
            {
                top = value;
            }
        }
    }
}
