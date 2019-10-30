using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TurtleChallenge
{
    public class MinefieldGame
    {
        public Turtle getTurtle(string config)
        {
            var lines = System.IO.File.ReadAllLines(config + ".txt"); //kept it to a text file but would've used JSON or XML and serialize it.
            string[] Split(string line) => line.Split(new[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var line1 = Split(lines[1]);
            var line2 = Split(lines[2]);

            Turtle _turtle = new Turtle
            {
                XPos = int.Parse(line1[1]),
                YPos = int.Parse(line1[2]),
                Direction = line2[1]
            };
            return _turtle;
        }

        public Board getBoard(String config)
        {
            var lines = System.IO.File.ReadAllLines(config + ".txt"); //kept it to a text file but would've used JSON or XML and serialize it.
            string[] Split(string line) => line.Split(new[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var line0 = Split(lines[0]);
            var line3 = Split(lines[3]);
            var line4 = Split(lines[4]);

            Mine mine1 = new Mine();
            Mine mine2 = new Mine();

            mine1.PosX = int.Parse(line4[1]); mine1.PosY = int.Parse(line4[2]);
            mine2.PosX = int.Parse(line4[3]); mine2.PosY = int.Parse(line4[4]);

            List<Mine> mines = new List<Mine>();
            mines.Add(mine1); mines.Add(mine2);
            Board _board = new Board(int.Parse(line0[1]), int.Parse(line0[2]), mines, int.Parse(line3[1]), int.Parse(line3[2]));
            return _board;
        }

        public void getSequence(String config, String sequence)
        {

            Board board = getBoard(config);

            using (StreamReader sr = new StreamReader(sequence +".txt"))
            {
                while (sr.Peek() >= 0)
                {
                    List<Action> Actions = new List<Action>();
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split('=' , ' ');
                    Action action = new Action();
                    for (int i = 1; i< strArray.Length; i++)
                    {
                        action = (Action)Enum.Parse(typeof(Action), strArray[i]);
                        Actions.Add(action);
                    }

                    var console = runSequence(Actions, getTurtle(config), board);
                    Console.WriteLine(console);
                }

            }
        }

        public string runSequence(List<Action> sequence, Turtle turtle, Board board)
        {
            Console.Write($" | Position: { turtle.XPos }-{ turtle.YPos }");
            Console.WriteLine($" | Direction: { turtle.Direction.ToString() }");
            foreach (var action in sequence.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{ action.value.ToString()}");
                switch(action.value)
                {
                    case Action.Move:
                        turtle.move();
                        if (board.isTurtleOffBoard(turtle.getxPosition(), turtle.getyPosition()))
                        {
                            return "Turtle is off the board";
                        }
                        else if (board.isTurtleOnMine(turtle.getxPosition(), turtle.getyPosition()))
                        {
                            return "BOOM! Turtle is blown up :(";
                        }
                        else if (board.isTurtleOnExit(turtle.getxPosition(), turtle.getyPosition()))
                        {
                            return "Yay! Turtle has escaped";
                        }
                        break;
                    case Action.Rotate:
                        turtle.rotate();
                        break;
                }
                Console.Write($" | Position: { turtle.XPos }-{ turtle.YPos }");
                Console.WriteLine($" | Direction: { turtle.Direction.ToString() }");
            }
            return "Turtle never found exit";
        }

    }
}
