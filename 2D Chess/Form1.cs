using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Chess
{
    public partial class Form1 : Form
    {
        ChessBoard chessBoard;
        Player playerWhite;
        Player playerBlack;
        bool pieceSelected;
        ChessPiece chessPieceSelected;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
            btnStartGame.Enabled = false;
        }

        private void StartGame()
        {
            pieceSelected = false;
            chessBoard = new ChessBoard(CreateChessBoard());
            playerWhite = new Player(Player.Colour.White);
            playerBlack = new Player(Player.Colour.Black);
            playerWhite.ChessPieces = chessBoard.SpawnWhiteChessPieces(playerWhite);
            foreach (ChessPiece piece in playerWhite.ChessPieces)
            {
                Controls.Add(piece.Pb);
                piece.Pb.BringToFront();
                piece.Pb.Enabled = false;
            }
            playerBlack.ChessPieces = chessBoard.SpawnBlackChessPieces(playerBlack);
            foreach (ChessPiece piece in playerBlack.ChessPieces)
            {
                Controls.Add(piece.Pb);
                piece.Pb.BringToFront();
                piece.Pb.Enabled = false;
            }
        }

        private List<List<BoardCell>> CreateChessBoard()
        {
            List<List<BoardCell>> boardCells = new List<List<BoardCell>>();

            List<BoardCell> y0Cells = new List<BoardCell>
            {
                new BoardCell(pos00),
                new BoardCell(pos10),
                new BoardCell(pos20),
                new BoardCell(pos30),
                new BoardCell(pos40),
                new BoardCell(pos50),
                new BoardCell(pos60),
                new BoardCell(pos70)
            };
            boardCells.Add(y0Cells);

            List<BoardCell> y1Cells = new List<BoardCell>
            {
                new BoardCell(pos01),
                new BoardCell(pos11),
                new BoardCell(pos21),
                new BoardCell(pos31),
                new BoardCell(pos41),
                new BoardCell(pos51),
                new BoardCell(pos61),
                new BoardCell(pos71)
            };
            boardCells.Add(y1Cells);

            List<BoardCell> y2Cells = new List<BoardCell>
            {
                new BoardCell(pos02),
                new BoardCell(pos12),
                new BoardCell(pos22),
                new BoardCell(pos32),
                new BoardCell(pos42),
                new BoardCell(pos52),
                new BoardCell(pos62),
                new BoardCell(pos72)
            };
            boardCells.Add(y2Cells);

            List<BoardCell> y3Cells = new List<BoardCell>
            {
                new BoardCell(pos03),
                new BoardCell(pos13),
                new BoardCell(pos23),
                new BoardCell(pos33),
                new BoardCell(pos43),
                new BoardCell(pos53),
                new BoardCell(pos63),
                new BoardCell(pos73)
            };
            boardCells.Add(y3Cells);

            List<BoardCell> y4Cells = new List<BoardCell>
            {
                new BoardCell(pos04),
                new BoardCell(pos14),
                new BoardCell(pos24),
                new BoardCell(pos34),
                new BoardCell(pos44),
                new BoardCell(pos54),
                new BoardCell(pos64),
                new BoardCell(pos74)
            };
            boardCells.Add(y4Cells);

            List<BoardCell> y5Cells = new List<BoardCell>
            {
                new BoardCell(pos05),
                new BoardCell(pos15),
                new BoardCell(pos25),
                new BoardCell(pos35),
                new BoardCell(pos45),
                new BoardCell(pos55),
                new BoardCell(pos65),
                new BoardCell(pos75)
            };
            boardCells.Add(y5Cells);

            List<BoardCell> y6Cells = new List<BoardCell>
            {
                new BoardCell(pos06),
                new BoardCell(pos16),
                new BoardCell(pos26),
                new BoardCell(pos36),
                new BoardCell(pos46),
                new BoardCell(pos56),
                new BoardCell(pos66),
                new BoardCell(pos76)
            };
            boardCells.Add(y6Cells);

            List<BoardCell> y7Cells = new List<BoardCell>
            {
                new BoardCell(pos07),
                new BoardCell(pos17),
                new BoardCell(pos27),
                new BoardCell(pos37),
                new BoardCell(pos47),
                new BoardCell(pos57),
                new BoardCell(pos67),
                new BoardCell(pos77)
            };
            boardCells.Add(y7Cells);

            return boardCells;
        }

        private void BoardCell_Click(object sender, EventArgs e)
        {
            Button btnClicked = (sender as Button);

            // We need to find the cell that was clicked by iterating through a list of lists of BoardCells
            foreach (List<BoardCell> cellList in chessBoard.BoardCells)
            {
                foreach (BoardCell cell in cellList)
                {
                    if (btnClicked.Name == cell.Button.Name)
                    {
                        if (!pieceSelected) 
                        {
                            if (cell.Occupied)
                            {
                                chessPieceSelected = cell.ChessPiece;
                                label1.Text = btnClicked.Name;
                                label2.Text = $"{btnClicked.Location.X}, {btnClicked.Location.Y}";
                                pieceSelected = true;
                            }
                        }
                        else // A chess piece is already selected
                        {
                            if (!cell.Occupied) // Target cell is not occupied so we are free to try to move in
                            {
                                if (chessPieceSelected.Move(cell)) // returns false is the piece cannot move to the target cell
                                {
                                    label2.Text = $"{btnClicked.Location.X}, {btnClicked.Location.Y}";
                                }
                                chessPieceSelected = null;
                                pieceSelected = false;
                                label1.Text = " ";
                            }
                            else // Target cell is occupied so we try to take the target in the cell
                            {
                                if (chessPieceSelected.Take(cell)) // Attempt to take the target in the cell, returns false if the colour of the pieces are the same.
                                {
                                    label2.Text = $"{btnClicked.Location.X}, {btnClicked.Location.Y}";
                                }
                                chessPieceSelected = null;
                                pieceSelected = false;
                                label1.Text = " ";
                            }
                        }
                    }
                }
            }
        }

    }
}