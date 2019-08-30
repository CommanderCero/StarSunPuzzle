using StarSunPuzzle.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarSunPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = new StarSunPuzzle();
            var solver = new BreadthFirstSearchSolver();
            var solution = solver.Solve(puzzle);

            Console.WriteLine(puzzle);
            foreach(var (pos, dir) in solution)
            {
                Thread.Sleep(1000);
                puzzle.Move(pos, dir);
                Console.Clear();
                Console.WriteLine(puzzle);
            }
        }
    }
}
