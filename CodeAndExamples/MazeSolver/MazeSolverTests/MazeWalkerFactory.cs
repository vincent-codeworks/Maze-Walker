using MazeSolver;

namespace MazeSolverTests
{
    internal class MazeWalkerFactory
    {
        internal static object CreateWalker(WalkerType dumb, MazeGrid maze)
        {
            return dumb switch
            {
                WalkerType.Smart => new SmartMazeWalker(maze),
                WalkerType.Dumb => new DumbMazeWalker(maze),
                _ => throw new NotImplementedException()
            };
        }
    }
}