using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSunPuzzle.Solver
{
    public class BreadthFirstSearchSolver
    {
        public IEnumerable<(Vector2D, Direction)> Solve(StarSunPuzzle puzzle)
        {
            var openList = new Queue<Node>();
            Expand(openList, new Node(puzzle, (null, Direction.Up), null));

            while(openList.Count > 0)
            {
                var nextNode = openList.Dequeue();
                if(nextNode.State.IsSolved())
                {
                    return nextNode.GetAllMoves();
                }

                Expand(openList, nextNode);
            }

            return null;
        }

        private void Expand(Queue<Node> openList, Node n)
        {
            foreach(var position in n.State.GetStarPositions())
            {
                foreach(var direction in new List<Direction>() {Direction.Up, Direction.Down, Direction.Left, Direction.Right})
                {
                    var copy = n.State.Copy();
                    var newPosition = copy.Move(position, direction);

                    // Ignore all moves that resulted in an out of bounds or didn't change anything
                    if (newPosition != null && !newPosition.Equals(position))
                    {
                        openList.Enqueue(new Node(copy, (position, direction), n));
                    }
                }
            }
        }
    }
}
