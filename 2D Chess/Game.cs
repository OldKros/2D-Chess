using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Chess
{
    public static class Game
    {
        public static bool GameStarted { get; private set; } = false;
        public static Player PlayerWhite { get; private set; } = new Player(Game.PlayerColour.White);
        public static Player PlayerBlack { get; private set; } = new Player(Game.PlayerColour.Black);
        public static Player PlayerTurn { get; private set; } = PlayerWhite;

        public static ChessBoard ChessBoard { get; private set; }
        public enum PlayerColour
        {
            White,
            Black
        }

        public static void StartGame()
        {
            if (!GameStarted)
            {
                PlayerWhite.ChessPieces = ChessBoard.SpawnWhiteChessPieces(PlayerWhite);
                PlayerBlack.ChessPieces = ChessBoard.SpawnBlackChessPieces(PlayerBlack);
                GameStarted = true;
            }
        }

        public static void CreateChessBoard(List<List<Button>> buttons)
        {
            List<List<BoardCell>> cells = new List<List<BoardCell>>();
            
            
            List<BoardCell> cellsList = new List<BoardCell>();

            foreach (var list in buttons)
            {
                foreach (var button in list)
                {
                    cellsList.Add(new BoardCell(button));
                }
                cells.Add(cellsList);
                cellsList = new List<BoardCell>();
            }        

            ChessBoard = new ChessBoard(cells);
        }

        public static Player NextTurn()
        {
            if (PlayerTurn == PlayerWhite)
            {
                PlayerTurn = PlayerBlack;
            }
            else if (PlayerTurn == PlayerBlack)
            {
                PlayerTurn = PlayerWhite;
            }
            return PlayerTurn;
        }
    }
}
