using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    public class ChessBoard
    {
        public List<List<BoardCell>> BoardCells { get; set; }
        public static int CellSpace { get; private set; } = 1;
         
        public ChessBoard(List<List<BoardCell>> boardCells)
        {
            BoardCells = boardCells;
        }

        public List<ChessPiece> SpawnWhiteChessPieces(Player playerWhite)
        {
            return new List<ChessPiece>
            {
                new Rook(BoardCells[0][0], playerWhite, "Rook 1"),
                new Knight(BoardCells[1][0], playerWhite, "Knight 1"),
                new Bishop(BoardCells[2][0], playerWhite, "Bishop 1"),
                new Queen(BoardCells[3][0], playerWhite, "Queen"),
                new King(BoardCells[4][0], playerWhite, "King"),
                new Bishop(BoardCells[5][0], playerWhite, "Bishop 2"),
                new Knight(BoardCells[6][0], playerWhite, "Knight 2"),
                new Rook(BoardCells[7][0], playerWhite, "Rook 1"),
                new Pawn(BoardCells[0][1], playerWhite, "Pawn 1"),
                new Pawn(BoardCells[1][1], playerWhite, "Pawn 2"),
                new Pawn(BoardCells[2][1], playerWhite, "Pawn 3"),
                new Pawn(BoardCells[3][1], playerWhite, "Pawn 4"),
                new Pawn(BoardCells[4][1], playerWhite, "Pawn 5"),
                new Pawn(BoardCells[5][1], playerWhite, "Pawn 6"),
                new Pawn(BoardCells[6][1], playerWhite, "Pawn 7"),
                new Pawn(BoardCells[7][1], playerWhite, "Pawn 8")
            };
        }

        public List<ChessPiece> SpawnBlackChessPieces(Player playerBlack)
        {
            return new List<ChessPiece>
            {
                
                new Pawn(BoardCells[0][6], playerBlack, "Pawn 1"),
                new Pawn(BoardCells[1][6], playerBlack, "Pawn 2"),
                new Pawn(BoardCells[2][6], playerBlack, "Pawn 3"),
                new Pawn(BoardCells[3][6], playerBlack, "Pawn 4"),
                new Pawn(BoardCells[4][6], playerBlack, "Pawn 5"),
                new Pawn(BoardCells[5][6], playerBlack, "Pawn 6"),
                new Pawn(BoardCells[6][6], playerBlack, "Pawn 7"),
                new Pawn(BoardCells[7][6], playerBlack, "Pawn 8"),
                new Rook(BoardCells[0][7], playerBlack, "Rook 1"),
                new Knight(BoardCells[1][7], playerBlack, "Rook 1"),
                new Bishop(BoardCells[2][7], playerBlack, "Bishop 1"),
                new Queen(BoardCells[3][7], playerBlack, "Queen 1"),
                new King(BoardCells[4][7], playerBlack, "King 1"),
                new Bishop(BoardCells[5][7], playerBlack, "Bishop 1"),
                new Knight(BoardCells[6][7], playerBlack, "Knight 1"),
                new Rook(BoardCells[7][7], playerBlack, "Rook 1")
            };
        }

        public BoardCell FindBoardCellByID(string id)
        {
            throw new NotImplementedException();
        }

        public List<BoardCell> CellsInPath(BoardCell start, BoardCell end)
        {
            List<BoardCell> cellsInPath = new List<BoardCell>();
            int cellsToMoveUp = start.YLoc - end.YLoc;
            int cellsToMoveDown = end.YLoc - start.YLoc;
            int cellsToMoveLeft = start.XLoc - end.XLoc;
            int cellsToMoveRight = end.XLoc - start.XLoc;


            if (start != BoardCells[start.XLoc][start.YLoc])
            {
                Logger.Error("Cannot find the start position");
            }

            // straight up
            if (cellsToMoveUp > 0 && cellsToMoveLeft == 0 && cellsToMoveRight == 0)
            {
                for (int i = 1; i <= cellsToMoveUp; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc][start.YLoc - i]);
                }
            }

            // straight down
            else if (cellsToMoveDown > 0 && cellsToMoveLeft == 0 && cellsToMoveRight == 0)
            {
                for (int i = 1; i <= cellsToMoveDown; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc][start.YLoc + i]);
                }
            }
            // straight left
            else if (cellsToMoveLeft > 0 && cellsToMoveUp == 0 && cellsToMoveDown == 0)
            {
                for (int i = 1; i <= cellsToMoveLeft; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc - i][start.YLoc]);
                }
            }

            // straight right
            else if (cellsToMoveRight > 0 && cellsToMoveUp == 0 && cellsToMoveDown == 0)
            {
                for (int i = 1; i <= cellsToMoveLeft; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc + i][start.YLoc]);
                }
            }
            // diagonal up left
            else if (cellsToMoveUp > 0 && cellsToMoveLeft > 0 && cellsToMoveLeft == cellsToMoveUp)
            {
                for (int i = 1; i <= cellsToMoveUp; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc - i][start.YLoc - i]);
                }
            }
            // diagonal up right
            else if (cellsToMoveUp > 0 && cellsToMoveRight > 0 && cellsToMoveRight == cellsToMoveUp)
            {
                for (int i = 1; i <= cellsToMoveUp; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc + i][start.YLoc - i]);
                }
            }
            // diagonal down left
            else if (cellsToMoveDown > 0 && cellsToMoveLeft > 0 && cellsToMoveLeft == cellsToMoveDown)
            {
                for (int i = 1; i <= cellsToMoveDown; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc - i][start.YLoc + i]);
                }
            }
            // diagonal down right
            else if (cellsToMoveDown > 0 && cellsToMoveLeft > 0 && cellsToMoveLeft == cellsToMoveDown)
            {
                for (int i = 1; i <= cellsToMoveDown; i++)
                {
                    cellsInPath.Add(BoardCells[start.XLoc + i][start.YLoc - i]);
                }
            }

            return cellsInPath;
        }
    }
}
