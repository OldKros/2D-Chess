using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Chess
{
    public class Player
    {
        public Game.PlayerColour Colour;
        public List<ChessPiece> ChessPieces { get; set; }

        public Player(Game.PlayerColour colour)
        {
            this.Colour = colour;
        }

    }
}
