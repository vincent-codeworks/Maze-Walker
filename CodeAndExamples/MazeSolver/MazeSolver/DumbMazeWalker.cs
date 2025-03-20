namespace MazeSolver;

public class DumbMazeWalker
{
    private readonly MazeGrid _mMazeGrid;
    private Orientation _mDirec;

    public DumbMazeWalker(MazeGrid mazeGrid)
    {
        _mMazeGrid = mazeGrid;
        CurrentPosition = _mMazeGrid.StartPosition;
        _mDirec = Orientation.South;
    }

    public bool CanSeeLeftTurning()
    {
        var pointToOurLeft = new Point(CurrentPosition.X, CurrentPosition.Y);

        switch (_mDirec)
        {
            case Orientation.North:
                pointToOurLeft.X -= 1;
                break;
            case Orientation.South:
                pointToOurLeft.X += 1;
                break;
            case Orientation.East:
                pointToOurLeft.Y -= 1;
                break;
            case Orientation.West:
                pointToOurLeft.Y += 1;
                break;
            default:
                throw new Exception();
        }

        return _mMazeGrid.Grid[pointToOurLeft.Y][pointToOurLeft.X];
    }

    public Point CurrentPosition { get; set; }

    public void TurnRight()
    {
        _mDirec = _mDirec switch
        {
            Orientation.North => Orientation.East,
            Orientation.West => Orientation.North,
            Orientation.South => Orientation.West,
            Orientation.East => Orientation.South,
            _ => throw new Exception(),
        };
    }

    public void TurnLeft()
    {
        _mDirec = _mDirec switch
        {
            Orientation.North => Orientation.West,
            Orientation.West => Orientation.South,
            Orientation.South => Orientation.East,
            Orientation.East => Orientation.North,
            _ => throw new Exception(),
        };
    }

    public bool MoveForward()
    {
        var desiredPoint = new Point(CurrentPosition.X, CurrentPosition.Y);

        switch (_mDirec)
        {
            case Orientation.North:
                desiredPoint.Y -= 1;
                break;
            case Orientation.South:
                desiredPoint.Y += 1;
                break;
            case Orientation.East:
                desiredPoint.X += 1;
                break;
            case Orientation.West:
                desiredPoint.X -= 1;
                break;
            default:
                throw new Exception();
        }

        var canMoveForward = _mMazeGrid.Grid[desiredPoint.Y][desiredPoint.X];
        if (canMoveForward) CurrentPosition = desiredPoint;
        return canMoveForward;
    }
}