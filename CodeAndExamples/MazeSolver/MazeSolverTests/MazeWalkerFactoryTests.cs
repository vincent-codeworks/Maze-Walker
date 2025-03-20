using MazeSolver;

namespace MazeSolverTests;

public class MazeWalkerFactoryTests
{
    [Fact]
    public void CreateWalker()
    {
        var maze = MazeBuilder.ExtractMaze(["SF"]);
        var walker = MazeWalkerFactory.CreateWalker(WalkerType.Dumb, maze);
        Assert.IsType<DumbMazeWalker>(walker);
    }
}
