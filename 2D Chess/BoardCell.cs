using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Chess
{
    public class BoardCell
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
            XLoc = GetXLoc();
            YLoc = GetYLoc();
        }

        public void PlaceChessPiece(ChessPiece chessPiece)
        {
            ChessPiece = chessPiece;
            Occupied = true;
            Button.BackgroundImage = chessPiece.PieceImage;
        }

        public void RemoveChessPiece()
        {
            ChessPiece = null;
            Occupied = false;
            Button.BackgroundImage = null;
        }

        private int GetXLoc()
        {

            string temp = Button.Name;
            return Convert.ToInt32(temp[3]) - 65; //'A' is 65
        }
        private int GetYLoc()
        {
            string temp = Button.Name;
            return Convert.ToInt32(temp[4]) - 48; // '0' is 48
        }
    }
}
