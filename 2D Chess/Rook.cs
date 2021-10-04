using System;

namespace _2D_Chess
{
    class Rook : ChessPiece
    {
        public Rook(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhiteRook;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackRook;
            }
            CurrentCell.Button.BackgroundImage = PieceImage;
        }


        public override bool Move(BoardCell destinationCell)
        {
            int cellsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int cellsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int cellsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int cellsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;

            if (IsPathToDestObstructed(destinationCell))
                return false;

            if (destinationCell.Occupied)
                return Take(destinationCell);


            if (Player.Colour == Game.PlayerColour.White)
            {
                if ((cellsToMoveDown == 0 && (cellsToMoveLeft >= 0 || cellsToMoveRight >= 0) // move left or right
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveDown >= 0) // move down
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveUp >= 0))) // move up
                {
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else // Player is black
            {
                if ((cellsToMoveUp == 0 && (cellsToMoveLeft >= 0 || cellsToMoveRight >= 0) // move left or right
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveDown >= 0) // move down
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveUp >= 0))) // move up
                {
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    return true;
                }
                return false;
            }
        }

        public override bool Take(BoardCell destinationCell)
        {
            if (Player.Colour == destinationCell.ChessPiece.Player.Colour) { return false; } // Make sure we aren't trying to take ourselves.

            int cellsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int cellsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int cellsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int cellsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;

            if (Player.Colour is Game.PlayerColour.White)
            {
                if ((cellsToMoveDown == 0 && (cellsToMoveLeft >= 0 || cellsToMoveRight >= 0) // move left or right
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveDown >= 0) // move down
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveUp >= 0))) // move up
                {
                    //destinationCell.ChessPiece.Pb.Visible = false; // makes the PictureBox invisible
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    //Place(CurrentCell);
                    //Pb.BackColor = CurrentCell.Button.BackColor;
                    return true;
                }
                return false;
            }
            else // Player is Black
            {
                if ((cellsToMoveUp == 0 && (cellsToMoveLeft >= 0 || cellsToMoveRight >= 0) // move left or right
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveDown >= 0) // move down
                    || (cellsToMoveLeft == 0 && cellsToMoveRight == 0 && cellsToMoveUp >= 0))) // move up
                {
                    //destinationCell.ChessPiece.Pb.Visible = false; // makes the PictureBox invisible
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    //Place(CurrentCell);
                    //Pb.BackColor = CurrentCell.Button.BackColor;
                    return true;
                }
                return false;
            }
        }
    }
}
