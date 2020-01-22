using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    class ChessBoard
    {
        public List<List<BoardCell>> BoardCells { get; set; }
         
        public ChessBoard(List<List<BoardCell>> boardCells)
        {
            BoardCells = new List<List<BoardCell>>();
            BoardCells = boardCells;
        }

        public List<ChessPiece> SpawnWhiteChessPieces(Player playerWhite)
        {
            List<ChessPiece> pieces = new List<ChessPiece>
            {
                new Pawn(BoardCells[1][0], playerWhite),
                new Pawn(BoardCells[1][1], playerWhite),
                new Pawn(BoardCells[1][2], playerWhite),
                new Pawn(BoardCells[1][3], playerWhite),
                new Pawn(BoardCells[1][4], playerWhite),
                new Pawn(BoardCells[1][5], playerWhite),
                new Pawn(BoardCells[1][6], playerWhite),
                new Pawn(BoardCells[1][7], playerWhite)
            };
            return pieces;
        }

        public List<ChessPiece> SpawnBlackChessPieces(Player playerBlack)
        {
            List<ChessPiece> pieces = new List<ChessPiece>
            {
                new Pawn(BoardCells[6][0], playerBlack),
                new Pawn(BoardCells[6][1], playerBlack),
                new Pawn(BoardCells[6][2], playerBlack),
                new Pawn(BoardCells[6][3], playerBlack),
                new Pawn(BoardCells[6][4], playerBlack),
                new Pawn(BoardCells[6][5], playerBlack),
                new Pawn(BoardCells[6][6], playerBlack),
                new Pawn(BoardCells[6][7], playerBlack)
            };
            return pieces;
        }
    }
}
