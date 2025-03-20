using MazeSolver;

namespace MazeSolverTests;
public class MazeTests
{
    [Fact]
    public void Golden_master()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var expectedOutput = """
            Point(1, 1)
            Point(2, 1)
            Point(3, 1)
            Point(4, 1)
            Point(4, 1)
            Point(4, 1)
            Point(3, 1)
            Point(2, 1)
            Point(2, 2)
            Point(2, 3)
            Point(3, 3)
            Point(4, 3)
            Point(5, 3)
            Reached end of maze! :)
            
            """;
        MazeApp.Run(@"MazeFiles\maze1.txt");
        var actualOutput = stringWriter.ToString();
        Assert.Equal(expectedOutput, actualOutput);

    }
}
