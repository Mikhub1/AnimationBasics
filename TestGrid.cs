/// <summary>
/// Provides an interactive test of the Grid class.  The user will control a
/// red t-shape with the arrow keys.  If Grid is functioning correctly, then 
/// the user should be able to move the t-shape within the grid, but these
/// movements should be blocked by the grid boundaries and by other shapes.
/// </summary>
public class TestGrid
{
    static void Print(Grid grid)
    {
        Console.Clear();
        grid.Print();
        Console.WriteLine("Use arrow keys to move and escape or 'q' to quit.");
    }

    static void Main()
    {
        Grid g = new Grid(12, 18);

        // Various shapes, expressed as two-dimensional bool arrays.
        bool[,] tShape = { {true,   true,   true},
                           {false,  true,   false} };
        bool[,] xShape = { {true,   false,  true},
                           {false,  true,   false},
                           {true,   false,  true} };
        bool[,] horizShape = { { true, true, true } };
        bool[,] vertShape = { { true }, { true }, { true } };

        // Fill initial grid.
        g.SetAll(CellType.Empty);
        g.Add(tShape, CellType.Red, 0, 0);
        g.Add(xShape, CellType.Magenta, 3, 10);
        g.Add(horizShape, CellType.Blue, 1, 13);
        g.Add(horizShape, CellType.Green, 5, 0);
        g.Add(vertShape, CellType.Blue, 9, 9);

        // Initialize the active shape (i.e. the player) in the upper-left
        // corner and choose it to be red.
        int row = 0;
        int col = 0;
        CellType activeColour = CellType.Red;
        g.Add(tShape, activeColour, row, col);

        Print(g);

        // Enter a loop where we accept movement controls from the user
        // via the arrow keys.  If the shape will fit into the updated position
        // without colliding with existing shapes, then execute the move. 
        bool quit = false;
        do
        {
            // Quit if escape or 'q' is pressed.
            ConsoleKeyInfo input = Console.ReadKey(false);
            quit = input.Key == ConsoleKey.Escape || input.Key == ConsoleKey.Q;

            int deltaRow = 0;
            int deltaCol = 0;
            if (input.Key == ConsoleKey.LeftArrow)
                deltaCol = -1;
            else if (input.Key == ConsoleKey.RightArrow)
                deltaCol = 1;
            else if (input.Key == ConsoleKey.UpArrow)
                deltaRow = -1;
            else if (input.Key == ConsoleKey.DownArrow)
                deltaRow = 1;

            // Delete the shape from its former position.
            g.Delete(tShape, row, col);

            // Can we reposition the piece?
            if (g.WillFit(tShape, row + deltaRow, col + deltaCol))
            {
                row += deltaRow;
                col += deltaCol;
            }

            // Whether we (row, col) has changed or not, re-add the shape.
            g.Add(tShape, activeColour, row, col);

            Print(g);

        } while (!quit);
    }
}