namespace MazeSolver;

public class MazeApp
{
    public static void Main()
    {
        /*
         * maze1.txt works
         * maze2.txt gets stuck
         * If using NUnit 3 - You will need to append TestContext.CurrentContext.TestDirectory to front of path to make it work properly
         * And do not use Path.Combine. If Path1 contains a C:\ it will always just return path2? Ask MS why.
         */
        Run(@"MazeFiles\maze2.txt");
        Console.ReadLine();
    }

    public static void Run(string mazeFilePath, WalkerType walkerType = WalkerType.Dumb)
    {
        var lines = File.ReadAllLines(mazeFilePath).Select(l => l.Replace(" ", "")).ToArray();
        MazeGrid maze = MazeBuilder.ExtractMaze(lines);
        var solved = MazeWalkerFactory.CreateWalker(walkerType, maze).SolveMaze();
        if (solved)
        {
            Console.WriteLine("Reached end of maze! :)");
        }
    }
}