namespace MazeSolver;

public static class MazeBuilder
{
    public static MazeGrid ExtractMaze(string[] lines)
    {
        Point start = null;
        Point finish = null;

        var grid = new bool[lines.Length][];
        int currentRow = 0;

        foreach (var line in lines)
        {
            grid[currentRow] = new bool[line.Length];
            int currentCol = 0;

            foreach (var point in line)
            {
                switch (point)
                {
                    case '#':
                        grid[currentRow][currentCol] = false;
                        break;
                    case '.':
                        grid[currentRow][currentCol] = true;
                        break;
                    case 'S':
                        grid[currentRow][currentCol] = true;
                        start = new Point(currentCol, currentRow);
                        break;
                    case 'F':
                        grid[currentRow][currentCol] = true;
                        finish = new Point(currentCol, currentRow);
                        break;
                    default:
                        throw new Exception("Maze input string contains invalid characters");
                }

                currentCol++;
            }

            currentRow++;
        }

        if (start == null) throw new Exception("Maze should have a start position set.");
        if (finish == null) throw new Exception("Maze should have a finish position set.");

        var maze = new MazeGrid(grid, start, finish);
        return maze;
    }
}

