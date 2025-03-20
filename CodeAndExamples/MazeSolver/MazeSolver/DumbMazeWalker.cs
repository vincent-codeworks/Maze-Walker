namespace MazeSolver;

public class DumbMazeWalker(MazeGrid mazeGrid) : MazeWalkerBase(mazeGrid, Orientation.South, mazeGrid.StartPosition)
{
    public override bool SolveMaze()
    {
        bool endOfMazeReached = false;

        while (!endOfMazeReached)
        {
            var couldMoveForward = MoveForward();

            if (!couldMoveForward)
            {
                TurnRight();
            }
            else
            {
                if (CanTurnLeft())
                {
                    TurnLeft();
                }
            }

            endOfMazeReached = _mMazeGrid.AtFinish(this);
            Console.WriteLine(CurrentPosition);
        }
        return endOfMazeReached;
    }
}