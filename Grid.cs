// STUDENTS: Fill in the code for the SetAll, WillFit, Add, and Delete methods below.

/// <summary>
/// A two-dimensional grid of CellType cells.  The general concept is that we
/// add and remove shapes to the grid through the Add and Delete methods.  A
/// shape is defined as a 2d array of bools where true represent part of the
/// shape and false is not part of the shape (e.g. representing a hole or gap).
/// The WillFit method checks whether the shape will fit (i.e. not collide with
/// the boundary or any any non-empty cells).
/// 
/// The Add/Delete/WillFit methods use the idea of a translated shape, which means
/// that we consider the shape to be translated (i.e. moved without rotation)
/// such that it's upper-left hand corner lies at the specified (row, column)
/// coordinates.  
/// </summary>
class Grid
{
    //The line private CellType[,] grid; declares a two-dimensional array of type CellType,
    // which is the type used to represent each cell on the grid
    private CellType[,] grid; //The [,] syntax in C# represents a two-dimensional array.

    public Grid(int nRows, int nCols)
    {
        grid = new CellType[nRows, nCols];
    }

    /// <summary>
    /// Set all grid cells to the given type.
    public void SetAll(CellType type)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {          // rows
            for (int j = 0; j < grid.GetLength(1); j++)
            {     // columns
                grid[i, j] = type;
            }
        }
    }

    /// <summary>
    /// Determine if the given shape will fit at position (row, col).  Note that
    /// (row, col) specifies the position of the upper-left corner of the given
    /// shape within the grid.
    /// </summary>
    /// <returns>
    /// True iff the given shape fits within the grid and does not overlap any
    /// non-empty cells.  Consider that the shape is translated such that it's
    /// upper-left corner lies at row 'row' and column 'col'.  Fitting within 
    /// the grid means all true cells of the translated shape lie within the grid.
    /// Overlap means that true cells of the translated shape would be at the same
    /// position as non-empty cells of the grid (i.e. there is a collision).
    /// </returns>
    public bool WillFit(bool[,] shape, int row, int col)
    {          // shape is to defined before setting value in grid
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j])
                {                                 // checking If the cell in the shape is part of the shape 
                    int targetRow = row + i;
                    int targetCol = col + j;

                    // This block ensures that the target position in the grid falls 
                    //within the valid range of the grid's rows and columns. If not the shape cannot fit.
                    if (targetRow < 0 || targetRow >= grid.GetLength(0) || targetCol < 0 || targetCol >= grid.GetLength(1))
                    {
                        return false;
                    }

                    // if the cell at the target position in the grid 
                    //is already occupied by something other than an empty cell. If it is, the shape cannot be placed there.
                    if (grid[targetRow, targetCol] != CellType.Empty)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }


    /// <summary>
    /// Adds the given shape to the grid, where (row, col) represents the
    /// upper-left corner of the insertion point.
    /// </summary>
    /// <precondition>
    /// WillFit would return true on the same arguments.
    /// </precondition>
    public void Add(bool[,] shape, CellType type, int row, int col)
    {
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j])
                {              // If the current cell in the shape is part of the shape (true)
                    int targetRow = row + i;
                    int targetCol = col + j;

                    grid[targetRow, targetCol] = type;
                }
            }
        }
    }


    /// <summary>
    /// Deletes the shape from the grid by setting all true cells within the
    /// translated shape to CellType.Empty.
    /// </summary>
    /// <precondition>
    /// The translated shape lies entirely within the grid.
    /// </precondition>
    public void Delete(bool[,] shape, int row, int col)
    {
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j])
                {              // If the current cell in the shape is part of the shape (true)
                    int targetRow = row + i;
                    int targetCol = col + j;

                    grid[targetRow, targetCol] = CellType.Empty;
                }
            }
        }
    }


    /// <summary>
    /// Prints the contents of the grid to the console, using one character per
    /// cell.
    /// </summary>
    public void Print()
    {
        for (int j = 0; j < grid.GetLength(0); j++)
        {
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[j, i] == CellType.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('\u2588');
                }
                else if (grid[j, i] == CellType.Red)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('\u2591');
                }
                else if (grid[j, i] == CellType.Magenta)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('\u2592');
                }
                else if (grid[j, i] == CellType.Green)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('\u2593');
                }
                else if (grid[j, i] == CellType.Blue)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('\u2591');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('?');
                }
            }
            Console.WriteLine("");
        }
    }
}