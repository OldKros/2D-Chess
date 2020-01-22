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
            currentCell = cell;
            currentCell.PlaceChessPiece(this);
            Player = player;

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
            int spacesToMoveLeft = currentCell.XLoc - destinationCell.XLoc;
            int spacesToMoveRight = destinationCell.XLoc - currentCell.XLoc;

            if (Player.colour == Player.Colour.White)
            {
                // The difference between cells is 66px so this makes sure the pawn can only move left one cell, right one cell and down one cell
                if (destinationCell.YLoc >= currentCell.YLoc && spacesToMoveDown <= 67 && spacesToMoveLeft <= 67 && spacesToMoveRight <= 67 && 
                    (spacesToMoveDown + spacesToMoveLeft) < 67 && (spacesToMoveDown + spacesToMoveRight) < 67)
                {
                    currentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else // Player is black
            {
                // The difference between cells is 66px so this makes sure the pawn can only move left one cell, right one cell and up one cell
                if (destinationCell.YLoc <= currentCell.YLoc && spacesToMoveUp <= 67 && spacesToMoveRight <= 67 && spacesToMoveLeft <= 67 && 
                    (spacesToMoveUp + spacesToMoveLeft) < 67 && (spacesToMoveUp + spacesToMoveRight) < 67)
                {
                    currentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
        }

        public override bool Take(BoardCell destinationCell)
        {
            if (Player.colour == destinationCell.ChessPiece.Player.colour) { return false; } // Make sure we aren't trying to take ourselves.

            int spacesToMoveUp = currentCell.YLoc - destinationCell.YLoc;
            int spacesToMoveDown = destinationCell.YLoc - currentCell.YLoc;
            int spacesToMoveLeft = currentCell.XLoc - destinationCell.XLoc;
            int spacesToMoveRight = destinationCell.XLoc - currentCell.XLoc;

            if (Player.colour is Player.Colour.White)
            {
                if (destinationCell.YLoc >= currentCell.YLoc && spacesToMoveDown <= 67 && spacesToMoveLeft <= 67 && spacesToMoveRight <= 67)
                {
                    destinationCell.ChessPiece.Pb.Visible = false; // makes the PictureBox invisible
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
                    currentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    Pb.Location = new Point(destinationCell.XLoc + 15, destinationCell.YLoc + 15);
                    currentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else if (Player.colour is Player.Colour.Black)
            {
                if (destinationCell.YLoc <= currentCell.YLoc && spacesToMoveUp <= 67 && spacesToMoveRight <= 67 && spacesToMoveLeft <= 67)
                {
                    destinationCell.ChessPiece.Pb.Visible = false; // makes the PictureBox invisible
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
                    currentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
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
