using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSweeper.Data
{
    public class Spaces
    {
        // Coordinates on the 10x10 board
        public int X { get; set; }

        public int Y { get; set; }

        // The number that is shown in the square after you click it to show how many bombs its neighbors have.
        public string KnownNeighbors { get; set; }

        // This list is used for when the current space has no neighboring bombs, so the open function is run on each neighbor. This list holds the name of each neighbor to check.
        public List<Spaces> NeighborSpaces { get; set; }

        // True if the space has a mine.
        public bool HasMine { get; set; }

        // True if the user flagged the square.
        public bool Flagged { get; set; }

        // True if the user or game has checked/opened the square.
        public bool Checked { get; set; }

        // CSS property to change the color of the square.
        public string Color { get; set; }

        // Basic constructor.
        public Spaces(int i, int j)
        {
            X = i;
            Y = j;
            Color = "gray;";
            NeighborSpaces = new List<Spaces>();
            Checked = false;
        }
    }

    // This Board object will hold the 2D array of Spaces objects
    public class Board
    {
        // The 2D array object.
        public Spaces[,] BoardSpace { get; set; }

        // How many flags the user has placed
        public int FlagNums { get; set; }

        // How many mines were inserted into the board.
        public int MineNums { get; set; }

        public Board()
        {
            // Create 10x10 array of Squares.
            BoardSpace = new Spaces[10, 10];
            FlagNums = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    BoardSpace[i, j] = new Spaces(i, j);
                }
            }

            // Generate random coordinates to insert the mines.
            Random placementX = new Random();
            Random placementY = new Random();
            int MyX, MyY;

            // Generate a random number of bombs. Right now it generates between 12 and 20 bombs.
            Random MineNum = new Random();
            MineNums = MineNum.Next(12, 20);

            // Insert the mines into random coordinates.
            for (int i = 0; i < MineNums; i++)
            {
                MyX = placementX.Next(0, 9);
                MyY = placementY.Next(0, 9);

                // If the mine already exists, make sure to generate another set of coordinates and try again.
                if (!BoardSpace[MyX, MyY].HasMine)
                {
                    BoardSpace[MyX, MyY].HasMine = true;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}