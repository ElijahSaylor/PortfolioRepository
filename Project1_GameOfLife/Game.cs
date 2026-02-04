using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Project1_GameOfLife
{
    internal class Game
    {
        int boardWidth;
        int boardHeight;
        Cell[,] board;
        Random Randy = new Random();
        string aliveSymbol = "O";
        string deadSymbol = "-";

        public Game() 
        {
            
        }

        /// <summary>
        /// Generates a game board with a random width and height from 5 - 25
        /// </summary>
        /// <param name="boardWidth"></param>
        /// <param name="boardHeight"></param>
        public void GenerateBoard()
        {
            boardHeight = Randy.Next(5, 21);
            boardWidth = Randy.Next(5, 21);

            board = new Cell[boardHeight, boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for(int j = 0; j < boardWidth; j++)
                {
                    board[i, j] = new Cell();
                }
            }

            Console.WriteLine($"Generated a {boardWidth} by {boardHeight} board!\n");
        }

        /// <summary>
        /// generates and populates a board of the specified size
        /// </summary>
        /// <param name="boardHeight"></param>
        /// <param name="boardWidth"></param>
        public void GenerateBoard(int boardHeight, int boardWidth)
        {

            board = new Cell[boardHeight, boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    board[i, j] = new Cell(deadSymbol,aliveSymbol);
                }
            }

            Console.WriteLine($"Generated a {boardWidth} by {boardHeight} board!\n");
        }

        /// <summary>
        /// Prints the current board
        /// </summary>
        public void DisplayBoard()
        {
            Console.WriteLine("Here is the current board: ");

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int i = 0; i < rows; i++) 
            { 
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// checks whether or not the current game has a board
        /// </summary>
        /// <returns></returns>
        public bool HasBoard()
        {
            if (board != null)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// loads board from specified file at path
        /// </summary>
        /// <param name="boardPath">path of file to load the board from</param>
        public void LoadBoard(string boardPath)
        {
            StreamReader reader = new StreamReader(boardPath);

            int lineNumber = 1;
            string line = reader.ReadLine()!;

            //int boardHeight;
            //int boardWidth;
            
            int boardRow = 0;
            int boardCol = 0;

            while (line != null) 
            {
                

                if (lineNumber == 1)
                {
                    string[] splitLine = line.Split(',');
                    //GenerateBoard(int.Parse(splitLine[1]), int.Parse(splitLine[0]));
                    boardHeight = int.Parse(splitLine[1]);
                    boardWidth = int.Parse(splitLine[0]);

                    //create empty board of size in file
                    board = new Cell[boardHeight,boardWidth];
                }

                else if (lineNumber == 2) 
                {
                    string[] splitLine = line.Split(',');
                    //register alive/dead symbol
                    aliveSymbol = splitLine[0];
                    deadSymbol = splitLine[1];
                }

                else
                {
                    boardCol = 0;
                    foreach(char c in line)
                    {
                        
                        if(c == 'o') { board[boardRow, boardCol] = new Cell(deadSymbol, aliveSymbol, true); }
                        else board[boardRow, boardCol] = new Cell(deadSymbol, aliveSymbol, false);

                        boardCol++;
                    }

                    boardRow++;
                }

                lineNumber++;
                line = reader.ReadLine()!;
            }

            reader.Close();
        }

        /// <summary>
        /// saves game board at specified file path
        /// the first line specifies board width/height separated by commas
        /// the second like specifies alive/dead symbol separated by commas
        /// the rest of the lines specify the board arrangement using 'o' as
        /// the alive symbol and 'x' as the dead symbol.
        /// </summary>
        /// <param name="boardPath"></param>
        public void SaveBoard(string boardPath)
        {
            StreamWriter writer = new StreamWriter(boardPath);

            writer.WriteLine(boardWidth + "," + boardHeight);
            writer.WriteLine(aliveSymbol + "," + deadSymbol);

            float x = 0;

            foreach (Cell c in board)
            {
                if (c.ToString() == aliveSymbol)
                {
                    writer.Write('o');
                }
                if (c.ToString() == deadSymbol)
                {
                    writer.Write('x');
                }
                x++;

                if (x % boardWidth == 0)
                {
                    writer.WriteLine();
                }
            }

            writer.Close();
        }

        /// <summary>
        /// progresses the simulation by 1 generation
        /// </summary>
        public void Advance()
        {
            Cell[,] futureBoard = new Cell[boardHeight,boardWidth];

            //populate future board
            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    futureBoard[i, j] = new Cell(deadSymbol, aliveSymbol, false);
                }
            }

            // board access is [Y,X] FROM TOP LEFT WHERE TOP LEFT IS [0,0]
            // for every cell, count that cell's neighbors. modify this cell's location in future board
            // accordingly. Finall, copy future board to board

            //board[1, 2] = new Cell("P", "L", true);

            int xPos = 0;
            int yPos = 0;
            int aliveNeighbors = 0;

            while (xPos < boardWidth && yPos < boardHeight) 
            {

                Cell thisCell = board[yPos, xPos];

                aliveNeighbors = thisCell.CountAllNeighbors(xPos, yPos, board, boardWidth, boardHeight);

                //logic checks
                if (thisCell.IsAlive && aliveNeighbors < 2)
                {
                    futureBoard[yPos, xPos].Die();
                }
                else if (thisCell.IsAlive && (aliveNeighbors == 2 || aliveNeighbors == 3)) 
                {
                    futureBoard[yPos, xPos].Live();
                }
                else if (thisCell.IsAlive && aliveNeighbors > 3)
                {
                    futureBoard[yPos, xPos].Die();
                }
                else if (!thisCell.IsAlive && aliveNeighbors == 3)
                {
                    futureBoard[yPos,xPos].Live();
                }


                    //loop position controller logic
                    xPos++;
                if (xPos > boardWidth - 1)
                {
                    xPos = 0;
                    yPos++;
                }

                //Console.WriteLine($"Cell {xPos}, {yPos} has {aliveNeighbors} alive neighbors");
                aliveNeighbors = 0;
            }

            board = futureBoard;
            //Console.WriteLine("No crashes!");
        }

        

        
    }
}
