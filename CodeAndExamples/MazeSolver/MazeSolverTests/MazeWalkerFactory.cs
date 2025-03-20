using MazeSolver;

namespace MazeSolverTests
{
    internal class MazeWalkerFactory
    {
        internal static object CreateWalker(WalkerType dumb, MazeGrid maze)
        {
            return new DumbMazeWalker(maze);
        }
    }
}