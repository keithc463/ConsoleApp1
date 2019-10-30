using System.Collections.Generic;

namespace TurtleChallenge
{
    public class Board
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int XExit { get; set; }
        public int YExit { get; set; }

        public Tile[,] Tiles { get; set; }

        public Board()
        {

        }

        public Board(int SizeX, int SizeY, List<Mine> Mines, int XExit, int YExit)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.XExit = XExit;
            this.YExit = YExit;
            Tiles = new Tile[SizeX, SizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    Tiles[x, y] = new Tile();
                }
            }

            foreach (var Mine in Mines)
            {
                Tiles[Mine.PosX, Mine.PosY].IsMine = true;
            }

            Tiles[XExit, YExit].IsExit = true;
        }

        public bool isTurtleOffBoard(int turtleXPos, int turtleYPos)
        {
            return turtleXPos >= SizeX || turtleYPos >= SizeY || turtleXPos<0 || turtleYPos<0;
        }

        public bool isTurtleOnMine(int turtleXPos, int turtleYPos)
        {
            return Tiles[turtleXPos, turtleYPos].IsMine;
        }

        public bool isTurtleOnExit(int turtleXPos, int turtleYPos)
        {
            return Tiles[turtleXPos, turtleYPos].IsExit;
        }


    }
}
