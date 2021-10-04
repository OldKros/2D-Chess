using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    public class Graveyard
    {
        public List<ChessPiece> PiecesInGraveyard { get; private set; }
        public Player Player { get; private set; }


        public Graveyard()
        {
            PiecesInGraveyard = new List<ChessPiece>();
        }

        public void AddToGraveyard(ChessPiece piece)
        {

        }
    }
}
