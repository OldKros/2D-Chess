using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    class ChessBoard
    {
        public List<List<BoardCell>> boardCells = new List<List<BoardCell>>();
        
        public ChessBoard(List<List<BoardCell>> boardCells)
        {
            this.boardCells = boardCells;
        }

        public List<ChessPiece> SpawnWhiteChessPieces(Player playerWhite)
        {
            List<ChessPiece> pieces = new List<ChessPiece>();
            pieces.Add(new Pawn(boardCells[1][0], playerWhite));
            pieces.Add(new Pawn(boardCells[1][1], playerWhite));
            pieces.Add(new Pawn(boardCells[1][2], playerWhite));
            pieces.Add(new Pawn(boardCells[1][3], playerWhite));
            pieces.Add(new Pawn(boardCells[1][4], playerWhite));
            pieces.Add(new Pawn(boardCells[1][5], playerWhite));
            pieces.Add(new Pawn(boardCells[1][6], playerWhite));
            pieces.Add(new Pawn(boardCells[1][7], playerWhite));
            return pieces;
        }

        public List<ChessPiece> SpawnBlackChessPieces(Player playerBlack)
        {
            List<ChessPiece> pieces = new List<ChessPiece>();
            pieces.Add(new Pawn(boardCells[6][0], playerBlack));
            pieces.Add(new Pawn(boardCells[6][1], playerBlack));
            pieces.Add(new Pawn(boardCells[6][2], playerBlack));
            pieces.Add(new Pawn(boardCells[6][3], playerBlack));
            pieces.Add(new Pawn(boardCells[6][4], playerBlack));
            pieces.Add(new Pawn(boardCells[6][5], playerBlack));
            pieces.Add(new Pawn(boardCells[6][6], playerBlack));
            pieces.Add(new Pawn(boardCells[6][7], playerBlack));
            return pieces;
        }
    }
}
