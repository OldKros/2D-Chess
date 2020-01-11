using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2D_Chess
{
    class Pawn : ChessPiece
    {
        BoardCell currentCell;
        Player player;
        
        public Pawn(BoardCell cell, Player player)
        {
            this.currentCell = cell;
            currentCell.PlaceChessPiece(this);
            this.player = player;

            if (player.colour == Player.Colour.White)
            {
                Pb = new PictureBox
                {
                    Size = new Size(30, 30),
                    Location = new Point(currentCell.XLoc + 15, currentCell.YLoc + 15),
                    BackColor = Color.Blue
                };
            }
            else if (player.colour == Player.Colour.Black)
            {
                Pb = new PictureBox
                {
                    Size = new Size(30, 30),
                    Location = new Point(currentCell.XLoc + 15, currentCell.YLoc + 15),
                    BackColor = Color.Red
                };
            }
        }

        public override void Move(BoardCell destinationCell)
        {
            currentCell.RemoveChessPiece();
            destinationCell.PlaceChessPiece(this);
            Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
            currentCell = destinationCell;
        }

        
    }
}
