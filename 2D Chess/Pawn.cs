using System.Drawing;
using System.Windows.Forms;

namespace _2D_Chess
{
    class Pawn : ChessPiece
    {
        BoardCell currentCell;
        public override Player Player { get; }

        public Pawn(BoardCell cell, Player player)
        {
            this.currentCell = cell;
            currentCell.PlaceChessPiece(this);
            this.Player = player;

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

        public override bool Move(BoardCell destinationCell)
        {
            int spacesToMoveUp = currentCell.YLoc - destinationCell.YLoc;
            int spacesToMoveDown = destinationCell.YLoc - currentCell.YLoc;
            int spacesToMoveRight = currentCell.XLoc - destinationCell.XLoc;
            int spacesToMoveLeft = destinationCell.XLoc - currentCell.XLoc;
            if (Player.colour == Player.Colour.White)
            {
                if (destinationCell.YLoc >= currentCell.YLoc && spacesToMoveUp <= 67 && spacesToMoveRight <= 67 && spacesToMoveLeft <= 67 && (spacesToMoveDown + spacesToMoveRight) < 67 && (spacesToMoveDown + spacesToMoveLeft) < 67)
                {
                    currentCell.RemoveChessPiece();
                    destinationCell.PlaceChessPiece(this);
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else // Player is black
            {
                if (destinationCell.YLoc <= currentCell.YLoc && spacesToMoveDown <= 67 && spacesToMoveLeft <= 67 && spacesToMoveRight <= 67 && (spacesToMoveUp + spacesToMoveRight) < 67 && (spacesToMoveUp + spacesToMoveLeft) < 67)
                {
                    currentCell.RemoveChessPiece();
                    destinationCell.PlaceChessPiece(this);
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
        }

        public override bool Take(BoardCell destinationCell)
        {
            int spacesToMoveUp = currentCell.YLoc - destinationCell.YLoc;
            int spacesToMoveDown = destinationCell.YLoc - currentCell.YLoc;
            int spacesToMoveRight = currentCell.XLoc - destinationCell.XLoc;
            int spacesToMoveLeft = destinationCell.XLoc - currentCell.XLoc;

            if (Player.colour == Player.Colour.White && destinationCell.ChessPiece.Player.colour == Player.Colour.Black)
            {
                if (destinationCell.YLoc >= currentCell.YLoc && spacesToMoveUp <= 67 && spacesToMoveRight <= 67 && spacesToMoveLeft <= 67)
                {
                    destinationCell.ChessPiece.Pb.Visible = false;
                    destinationCell.RemoveChessPiece();
                    currentCell.RemoveChessPiece();
                    destinationCell.PlaceChessPiece(this);
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else if (Player.colour == Player.Colour.Black && destinationCell.ChessPiece.Player.colour == Player.Colour.White)
            {
                if (destinationCell.YLoc <= currentCell.YLoc && spacesToMoveDown <= 67 && spacesToMoveLeft <= 67 && spacesToMoveRight <= 67)
                {
                    destinationCell.ChessPiece.Pb.Visible = false;
                    destinationCell.RemoveChessPiece();
                    currentCell.RemoveChessPiece();
                    destinationCell.PlaceChessPiece(this);
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
