using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    class Player
    {
        public Colour colour;
        public List<ChessPiece> chessPieces { get; set; }

        public Player(Colour colour)
        {
            this.colour = colour;
        }

        public enum Colour
        {
            White,
            Black
        }
    }
}
