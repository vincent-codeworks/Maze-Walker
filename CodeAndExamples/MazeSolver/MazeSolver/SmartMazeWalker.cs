namespace MazeSolver;

public class SmartMazeWalker(MazeGrid maze) : MazeWalkerBase(maze, Orientation.South, maze.StartPosition)
{
    public override bool SolveMaze()
    {
        throw new NotImplementedException();
    }
}