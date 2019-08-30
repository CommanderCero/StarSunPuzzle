using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSunPuzzle
{
    public class StarSunPuzzle
    {
        public const int Width = 5;
        public const int Height = 5;
        public static readonly Vector2D SunSolvePosition = new Vector2D(2, 2);

        private Dictionary<Vector2D, char> starPositions;

        public StarSunPuzzle()
        {
            starPositions = new Dictionary<Vector2D, char>
            {
                {new Vector2D(0, 0), '*'},
                {new Vector2D(2, 0), '*'},
                {new Vector2D(3, 0), '*'},
                {new Vector2D(4, 3), '*'},
                {new Vector2D(1, 4), 'S'}
            };
        }

        public bool IsSolved()
        {
            return starPositions.ContainsKey(SunSolvePosition) && starPositions[SunSolvePosition] == 'S';
        }

        public Vector2D Move(Vector2D p, Direction d)
        {
            if (!starPositions.ContainsKey(p))
            {
                throw new Exception($"Invalid Move: Tried to move a not existing star at position {p}.");
            }

            Vector2D moveDirection;
            switch(d)
            {
                case Direction.Up: moveDirection = new Vector2D(0, -1); break;
                case Direction.Down: moveDirection = new Vector2D(0, 1); break;
                case Direction.Left: moveDirection = new Vector2D(-1, 0); break;
                case Direction.Right: moveDirection = new Vector2D(1, 0); break;
                default: throw new Exception($"Invalid Move: Unknown direction {d}");
            }

            var currPosition = new Vector2D(p.X, p.Y);
            while(true)
            {
                var newPosition = new Vector2D(currPosition.X + moveDirection.X, currPosition.Y + moveDirection.Y);
                // Check OutOfBounds
                if (IsOutOfBounds(newPosition))
                {
                    starPositions.Remove(p);
                    return null;
                }
                // Check if our moving star is blocked
                if (starPositions.ContainsKey(newPosition))
                {
                    var starSymbol = starPositions[p];
                    starPositions.Remove(p);
                    starPositions.Add(currPosition, starSymbol);
                    return currPosition;
                }

                currPosition = newPosition;
            }
        }

        public bool IsOutOfBounds(Vector2D p)
        {
            return p.X < 0 || p.Y < 0 || p.X >= Width || p.Y >= Height;
        }

        public List<Vector2D> GetStarPositions()
        {
            return starPositions.Keys.ToList();
        }

        public StarSunPuzzle Copy()
        {
            var copy = new StarSunPuzzle();
            copy.starPositions = new Dictionary<Vector2D, char>(starPositions);

            return copy;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for(var y = 0; y < Height; y++)
            {
                for(var x = 0; x < Width; x++)
                {
                    var position = new Vector2D(x, y);
                    var symbol = '-';
                    if(starPositions.ContainsKey(position))
                    {
                        symbol = starPositions[position];
                    }

                    builder.Append(symbol);
                }

                builder.Append('\n');
            }

            return builder.ToString();
        }
    }
}
