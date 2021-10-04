using System;

namespace _2D_Chess
{
    class King : ChessPiece
    {
        public King(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhiteKing;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackKing;
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
            {
                return Take(destinationCell);
            }

            if (Player.Colour == Game.PlayerColour.White)
            {
                if (cellsToMoveUp == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveDown == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveLeft == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1) ||
                    cellsToMoveRight == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1))
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
                if (cellsToMoveUp == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveDown == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveLeft == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1) ||
                    cellsToMoveRight == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1))
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
            int cellsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int cellsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int cellsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int cellsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;

            if (Player.Colour == Game.PlayerColour.White)
            {
                if (cellsToMoveUp == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveDown == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveLeft == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1) ||
                    cellsToMoveRight == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1))
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
                if (cellsToMoveUp == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveDown == 1 && (cellsToMoveRight <= 1 || cellsToMoveLeft <= 1) ||
                    cellsToMoveLeft == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1) ||
                    cellsToMoveRight == 1 && (cellsToMoveDown <= 1 || cellsToMoveUp <= 1))
                {
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    return true;
                }
                return false;
            }
        }

    }
}
