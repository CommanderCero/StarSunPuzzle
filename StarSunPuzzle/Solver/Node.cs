using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSunPuzzle.Solver
{
    public class Node
    {
        public StarSunPuzzle State { get; set; }
        public (Vector2D, Direction) Move { get; set; }
        public Node PreviousNode { get; set; }

        public Node(StarSunPuzzle state, (Vector2D, Direction) move, Node prevNode)
        {
            State = state;
            Move = move;
            PreviousNode = prevNode;
        }

        public IEnumerable<(Vector2D, Direction)> GetAllMoves()
        {
            if (PreviousNode == null)
            {
                yield break;
            }

            foreach (var move in PreviousNode.GetAllMoves())
                yield return move;

            yield return Move;
        }
    }
}
