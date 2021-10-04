using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace _2D_Chess
{
    public abstract class ChessPiece
    {
        public BoardCell CurrentCell { get; protected set; }
        //public System.Windows.Forms.PictureBox Pb { get; set; }
        public Player Player { get; }

        public Image PieceImage { get; protected set; }

        public string ID { get; protected set; }

        protected int ChessPieceWidth { get; set; } = 58;
        protected int ChessPieceHeight { get; set; } = 58;

        public abstract bool Move(BoardCell destinationCell);
        public abstract bool Take(BoardCell destinationCell);

        protected ChessPiece(BoardCell cell, Player player, string id)
        {
            ID = id;
            CurrentCell = cell;
            CurrentCell.PlaceChessPiece(this);
            Player = player;

            //Pb = new PictureBox
            //{
            //    Size = new Size(ChessPieceWidth, ChessPieceHeight),
            //    Width = ChessPieceWidth,
            //    Height = ChessPieceHeight,
            //    Location = new Point(CurrentCell.Button.Location.X + 1, CurrentCell.Button.Location.Y + 1),
            //    BackColor = CurrentCell.Button.BackColor,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //};

        }

        public override string ToString()
        {
            return ID;
        }

        protected bool IsPathToDestObstructed(BoardCell destinationCell)
        {
            // Walk through the path to see if there are any obstructions 
            List<BoardCell> path = Game.ChessBoard.CellsInPath(CurrentCell, destinationCell);
            foreach (var step in path)
            {
                if (step.Occupied && step != destinationCell)
                {
                    Logger.Error($"Cannot move through {step.Button.Name} as it is occupied");
                    return true;
                }
            }
            return false;
        }

    }
}
