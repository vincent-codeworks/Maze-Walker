namespace MazeSolver
{
    public abstract class MazeWalkerBase
    {
        protected readonly MazeGrid _mMazeGrid;
        protected Orientation _mDirec;
        public Point CurrentPosition { get; set; }

        protected MazeWalkerBase(MazeGrid mMazeGrid, Orientation mDirec, Point currentPosition)
        {
            _mMazeGrid = mMazeGrid;
            _mDirec = mDirec;
            CurrentPosition = currentPosition;
        }

        public bool CanTurnLeft()
        {
            var pointToOurLeft = new Point(CurrentPosition.X, CurrentPosition.Y);

            switch (_mDirec)
            {
                case Orientation.North:
                    pointToOurLeft.X--;
                    break;
                case Orientation.South:
                    pointToOurLeft.X++;
                    break;
                case Orientation.East:
                    pointToOurLeft.Y--;
                    break;
                case Orientation.West:
                    pointToOurLeft.Y++;
                    break;
                default:
                    throw new Exception();
            }

            return _mMazeGrid.Grid[pointToOurLeft.Y][pointToOurLeft.X];
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

        public abstract bool SolveMaze();

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
    }
}