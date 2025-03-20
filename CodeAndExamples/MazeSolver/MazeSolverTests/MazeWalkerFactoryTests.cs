using MazeSolver;

namespace MazeSolverTests;

public class MazeWalkerFactoryTests
{
    [Fact]
    public void CreateWalker_can_create_dumb()
    {
        var maze = MazeBuilder.ExtractMaze(["SF"]);
        var walker = MazeWalkerFactory.CreateWalker(WalkerType.Dumb, maze);
        Assert.IsType<DumbMazeWalker>(walker);
    }

    [Fact]
    public void CreateWalker_can_create_smart()
    {
        var maze = MazeBuilder.ExtractMaze(["SF"]);
        var walker = MazeWalkerFactory.CreateWalker(WalkerType.Smart, maze);
        Assert.IsType<SmartMazeWalker>(walker);
    }
}
