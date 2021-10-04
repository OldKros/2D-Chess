using System;

namespace _2D_Chess
{
    class Knight : ChessPiece
    {
        public Knight(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhiteKnight;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackKnight;
            }
            CurrentCell.Button.BackgroundImage = PieceImage;
        }

        public override bool Move(BoardCell destinationCell)
        {
            int cellsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int cellsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int cellsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int cellsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;

            //if (IsPathToDestObstructed(destinationCell))
            //    return false;

            if (destinationCell.Occupied)
                return Take(destinationCell);


            if (Player.Colour == Game.PlayerColour.White)
            {
                if (cellsToMoveLeft == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveRight == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveDown == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1)
                    || cellsToMoveUp == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1))
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
                if (cellsToMoveLeft == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveRight == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveDown == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1)
                    || cellsToMoveUp == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1))
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

            //if (IsPathToDestObstructed(destinationCell))
            //    return false;

            if (destinationCell.Occupied)
                return Take(destinationCell);


            if (Player.Colour == Game.PlayerColour.White)
            {
                if (cellsToMoveLeft == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveRight == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveDown == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1)
                    || cellsToMoveUp == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1))
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
                if (cellsToMoveLeft == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveRight == 2 && (cellsToMoveDown == 1 || cellsToMoveUp == 1)
                    || cellsToMoveDown == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1)
                    || cellsToMoveUp == 2 && (cellsToMoveRight == 1 || cellsToMoveLeft == 1))
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
