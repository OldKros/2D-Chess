using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Chess
{
    class BoardCell
    {
        public Button Button { get; private set; }
        public int XLoc { get; private set; }
        public int YLoc { get; private set; }
        public ChessPiece ChessPiece { get; private set; }
        public bool Occupied { get; private set; }

        public BoardCell(Button button)
        {
            Button = button;
            ChessPiece = null;
            Occupied = false;
            XLoc = button.Location.X;
            YLoc = button.Location.Y;
        }

        public void PlaceChessPiece(ChessPiece chessPiece)
        {
            ChessPiece = chessPiece;
            Occupied = true;
        }

        public void RemoveChessPiece()
        {
            ChessPiece = null;
            Occupied = false;
        }
    }
}
