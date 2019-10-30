namespace TurtleChallenge
{
    public class Tile
    {
        public Tile()
        {
            IsMine = false;
            IsExit = false;
        }

        public bool IsMine { get; set; }
        public bool IsExit { get; set; }
    }
}