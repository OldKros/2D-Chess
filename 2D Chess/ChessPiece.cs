using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    abstract class ChessPiece
    {
        public System.Windows.Forms.PictureBox Pb { get; set; }
        public abstract Player Player { get; }

        public abstract bool Move(BoardCell destinationCell);
        public abstract bool Take(BoardCell destinationCell);
    }
}
