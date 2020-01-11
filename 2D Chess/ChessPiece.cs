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

        public abstract void Move(BoardCell destinationCell);
    }
}
