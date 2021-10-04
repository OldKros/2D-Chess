using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2D_Chess
{
    class Pawn : ChessPiece
    {
        private bool FirstMove = true;

        public Pawn(BoardCell cell, Player player, string id)
        : base(cell, player, id)
        {
            if (player.Colour == Game.PlayerColour.White)
            {
                PieceImage = Properties.Resources.WhitePawn;
            }
            else if (player.Colour == Game.PlayerColour.Black)
            {
                PieceImage = Properties.Resources.BlackPawn;
            }

            CurrentCell.Button.BackgroundImage = PieceImage;
        }

        public override bool Move(BoardCell destinationCell)
        {
            int cellsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int cellsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int cellsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int cellsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;
            // can only move two spaces down on the first move.
            int maxCellsToMove = FirstMove ? ChessBoard.CellSpace * 2 : ChessBoard.CellSpace;

            if (IsPathToDestObstructed(destinationCell))
                return false;

            if (destinationCell.Occupied)
            {
                return Take(destinationCell);
            }

            if (Player.Colour == Game.PlayerColour.White)
            {
                if ((cellsToMoveDown > 0 && cellsToMoveDown <= maxCellsToMove
                    && (cellsToMoveLeft == 0 && cellsToMoveRight == 0))
                    || (cellsToMoveDown == 0 && cellsToMoveLeft == ChessBoard.CellSpace) 
                    || (cellsToMoveDown == 0 && cellsToMoveRight == ChessBoard.CellSpace))
                {
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    FirstMove = false;
                    return true;
                }
                return false;
            }
            else // Player is black
            {
                if ((cellsToMoveUp > 0 && cellsToMoveUp <= maxCellsToMove
                    && (cellsToMoveLeft == 0 && cellsToMoveRight == 0))
                    || (cellsToMoveDown == 0 && cellsToMoveLeft == ChessBoard.CellSpace)
                    || (cellsToMoveDown == 0 && cellsToMoveRight == ChessBoard.CellSpace))
                {
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    FirstMove = false;
                    return true;
                }
                return false;
            }
        }

        public override bool Take(BoardCell destinationCell)
        {
            if (Player.Colour == destinationCell.ChessPiece.Player.Colour) { return false; } // Make sure we aren't trying to take ourselves.

            int pixelsToMoveUp = CurrentCell.YLoc - destinationCell.YLoc;
            int pixelsToMoveDown = destinationCell.YLoc - CurrentCell.YLoc;
            int pixelsToMoveLeft = CurrentCell.XLoc - destinationCell.XLoc;
            int pixelsToMoveRight = destinationCell.XLoc - CurrentCell.XLoc;

            if (Player.Colour is Game.PlayerColour.White)
            {
                if (pixelsToMoveDown == ChessBoard.CellSpace 
                    && (pixelsToMoveRight > 0 && pixelsToMoveRight <= ChessBoard.CellSpace 
                    || pixelsToMoveLeft > 0 && pixelsToMoveLeft <= ChessBoard.CellSpace ))
                {
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
                    CurrentCell.RemoveChessPiece(); // Remove this piece from this cell
                    destinationCell.PlaceChessPiece(this); // Add this piece to dest cell
                    CurrentCell = destinationCell;
                    return true;
                }
                return false;
            }
            else // Player is Black
            {
                if (pixelsToMoveUp == ChessBoard.CellSpace 
                    && (pixelsToMoveRight > 0 && pixelsToMoveRight <= ChessBoard.CellSpace
                    || pixelsToMoveLeft > 0 && pixelsToMoveLeft <= ChessBoard.CellSpace))
                {
                    destinationCell.RemoveChessPiece(); // Remove the piece from the dest cell. This and the previous line should make the peice being took unselectable and unseeable.
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
