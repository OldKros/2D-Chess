using System;

namespace _2D_Chess
{
    class Bishop : ChessPiece
    {
        public Bishop(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhiteBishop;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackBishop;
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
                if (cellsToMoveUp == cellsToMoveRight || cellsToMoveUp == cellsToMoveRight || 
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight)
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
                if (cellsToMoveUp == cellsToMoveRight || cellsToMoveUp == cellsToMoveRight ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight)
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
                if (cellsToMoveUp == cellsToMoveRight || cellsToMoveUp == cellsToMoveRight ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight)
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
                if (cellsToMoveUp == cellsToMoveRight || cellsToMoveUp == cellsToMoveRight ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight)
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
