using System;

namespace _2D_Chess
{
    class Queen : ChessPiece
    {
        public Queen(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhiteQueen;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackQueen;
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
                if (cellsToMoveUp == cellsToMoveLeft || cellsToMoveUp == cellsToMoveRight || (cellsToMoveUp == 1 && cellsToMoveLeft ==0 && cellsToMoveRight ==0) ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight || (cellsToMoveDown == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveLeft == cellsToMoveUp || cellsToMoveLeft == cellsToMoveDown || (cellsToMoveLeft == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0) ||
                    cellsToMoveRight == cellsToMoveUp || cellsToMoveRight == cellsToMoveDown || (cellsToMoveRight == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0))
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
                if (cellsToMoveUp == cellsToMoveLeft || cellsToMoveUp == cellsToMoveRight || (cellsToMoveUp == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight || (cellsToMoveDown == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveLeft == cellsToMoveUp || cellsToMoveLeft == cellsToMoveDown || (cellsToMoveLeft == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0) ||
                    cellsToMoveRight == cellsToMoveUp || cellsToMoveRight == cellsToMoveDown || (cellsToMoveRight == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0))
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
                if (cellsToMoveUp == cellsToMoveLeft || cellsToMoveUp == cellsToMoveRight || (cellsToMoveUp == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight || (cellsToMoveDown == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveLeft == cellsToMoveUp || cellsToMoveLeft == cellsToMoveDown || (cellsToMoveLeft == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0) ||
                    cellsToMoveRight == cellsToMoveUp || cellsToMoveRight == cellsToMoveDown || (cellsToMoveRight == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0))
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
                if (cellsToMoveUp == cellsToMoveLeft || cellsToMoveUp == cellsToMoveRight || (cellsToMoveUp == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveDown == cellsToMoveLeft || cellsToMoveDown == cellsToMoveRight || (cellsToMoveDown == 1 && cellsToMoveLeft == 0 && cellsToMoveRight == 0) ||
                    cellsToMoveLeft == cellsToMoveUp || cellsToMoveLeft == cellsToMoveDown || (cellsToMoveLeft == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0) ||
                    cellsToMoveRight == cellsToMoveUp || cellsToMoveRight == cellsToMoveDown || (cellsToMoveRight == 1 && cellsToMoveUp == 0 && cellsToMoveDown == 0))
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