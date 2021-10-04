using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _2D_Chess
{
    public partial class Form1 : Form
    {
        bool pieceSelected;
        bool logShown = false;
        ChessPiece selectedChessPiece;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            Logger.logForm = new LogForm();
            CreateChessBoard();
            Game.StartGame();
            btnStartGame.Enabled = false;
            pieceSelected = false;
            lblCurrentTurn.Visible = true;

            //foreach (ChessPiece piece in Game.PlayerWhite.ChessPieces)
            //{
            //    Controls.Add(piece.Pb);
            //    piece.Pb.BringToFront();
            //    piece.Pb.Enabled = false;
            //}
            //foreach (ChessPiece piece in Game.PlayerBlack.ChessPieces)
            //{
            //    Controls.Add(piece.Pb);
            //    piece.Pb.BringToFront();
            //    piece.Pb.Enabled = false;
            //}
        }

        private void BoardCell_Click(object sender, EventArgs e)
        {
            Button btnClicked = (sender as Button);

            if (!Game.GameStarted) { return; }

            // We need to find the cell that was clicked by iterating through a list of lists of BoardCells
            foreach (List<BoardCell> cellList in Game.ChessBoard.BoardCells)
            {
                foreach (BoardCell cell in cellList)
                {
                    if (btnClicked.Name != cell.Button.Name)
                    {
                        continue;
                    }

                    if (!pieceSelected)
                    { 
                        if (cell.Occupied)
                        {
                            if (cell.ChessPiece.Player == Game.PlayerTurn)
                            {
                                selectedChessPiece = cell.ChessPiece;
                                Logger.Log($"Position {btnClicked.Name} selected");
                                Logger.Log($"{cell.ChessPiece.Player.Colour} Player {cell.ChessPiece} Selected");
                                pieceSelected = true;
                            }
                            else
                            {
                                Logger.Log($"Position {btnClicked.Name} selected");
                                Logger.Log($"It is not {cell.ChessPiece.Player.Colour} Player's turn");
                            }
                        }
                        else
                        {
                            Logger.Log($"Position {btnClicked.Name} selected but was empty");
                        }
                    }
                    else // A chess piece is already selected
                    {
                        if (cell.Occupied) // we have clicked a cell with a piece on
                        {
                            if (cell.ChessPiece.Player == Game.PlayerTurn) // if the piece selected is ours we can swap to it
                            {
                                Logger.Log($"{selectedChessPiece} was selected but {cell.ChessPiece} was clicked so swapping selected piece to {cell.ChessPiece}");
                                selectedChessPiece = cell.ChessPiece;
                                Logger.Log($"Position {btnClicked.Name} selected");
                                Logger.Log($"{cell.ChessPiece.Player.Colour} Player {cell.ChessPiece} Selected");
                                return;
                            }
                        }

                        if (selectedChessPiece.Move(cell)) // returns false is the piece cannot move to the target cell or take the targetted piece
                        {
                            Logger.Log($"{selectedChessPiece.ID} moved to {btnClicked.Name}");
                            selectedChessPiece = null;
                            pieceSelected = false;
                            lblCurrentTurn.Text = $"Current Turn: {Game.NextTurn().Colour}";
                        }
                    }
                    // once we have found the cell, we dont need to continue
                    return;
                    
                }
            }
        }

        private void btnShowHideLog_Click(object sender, EventArgs e)
        {
            if (!logShown)
            {
                ShowLog();
            }
            else
            {
                HideLog();
            }
        }

        private void ShowLog()
        {
            try
            {
                Logger.logForm.Toggle(true);
                btnShowHideLog.Text = "Hide Log";
            }
            catch (NullReferenceException ex)
            {
                Logger.logForm = new LogForm();
                Logger.Error(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Logger.logForm = new LogForm();
                Logger.Error(ex.Message);
            }
            finally
            {
                Logger.logForm.Toggle(true);
                btnShowHideLog.Text = "Hide Log";
            }
            logShown = true;
        }

        private void HideLog()
        {
            try
            {
                Logger.logForm.Toggle(false);
                btnShowHideLog.Text = "Show Log";
            }
            catch (NullReferenceException ex)
            {
                Logger.logForm = new LogForm();
                Logger.Error(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Logger.logForm = new LogForm();
                Logger.Error(ex.Message);
            }
            finally
            {
                Logger.logForm.Toggle(false);
                btnShowHideLog.Text = "Show Log";
            }
            logShown = false;
        }

        private void CreateChessBoard()
        {
            Game.CreateChessBoard(new List<List<Button>> {

                new List<Button>
                {
                    posA0, posA1, posA2, posA3, posA4, posA5, posA6, posA7
                },

                new List<Button>
                {
                    posB0, posB1, posB2, posB3, posB4, posB5, posB6, posB7
                },
                new List<Button>
                {
                    posC0, posC1, posC2, posC3, posC4, posC5, posC6, posC7
                },
                new List<Button>
                {
                    posD0, posD1, posD2, posD3, posD4, posD5, posD6, posD7
                },
                new List<Button>
                {
                    posE0, posE1, posE2, posE3, posE4, posE5, posE6, posE7
                },
                new List<Button>
                {
                    posF0, posF1, posF2, posF3, posF4, posF5, posF6, posF7
                },
                new List<Button>
                {
                    posG0, posG1, posG2, posG3, posG4, posG5, posG6, posG7
                },
                new List<Button>
                {
                    posH0, posH1, posH2, posH3, posH4, posH5, posH6, posH7
                },
            });
        }
    }
}