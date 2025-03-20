namespace MazeSolver
{
    public class MazeWalkerFactory
    {
        public static MazeWalkerBase CreateWalker(WalkerType dumb, MazeGrid maze)
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