namespace ThaiGame
{
    public class Cell
    {
        public int Number { get; set; }
        public bool IsOpened { get; private set; }

        public Cell(int number)
        {
            Number = number;
            IsOpened = false;
        }

        public void Open() => IsOpened = true;
    }
}