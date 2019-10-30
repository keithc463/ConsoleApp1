namespace TurtleChallenge
{
    public class Turtle
    {
        public int XPos { get; set;}
        public int YPos { get; set; }
        public string Direction { get; set; }

        public void move()
        {
            switch (Direction)
            {
                case "North": XPos++; break;
                case "East": YPos++; break;
                case "South": YPos--; break;
                case "West": XPos--; break;
            }
        }

        public void rotate()
        {
            switch (Direction)
            {
                case "North": Direction = "East"; break;
                case "East": Direction = "South"; break;
                case "South": Direction = "West"; break;
                case "West": Direction = "North"; break;
            }
        }

        public int getxPosition()
        {
            return XPos;
        }

        public int getyPosition()
        {
            return YPos;
        }


    }
}
