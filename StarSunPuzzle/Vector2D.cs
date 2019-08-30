using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSunPuzzle
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var other = (Vector2D)obj;
            return other.X == X && other.Y == Y;
        }

        public override int GetHashCode()
        {
            return X * 13 + Y * 29;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
