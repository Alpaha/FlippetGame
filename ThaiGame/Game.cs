namespace ThaiGame
{
    public class Game
    {
        private readonly Desk _desk = new Desk();

        public bool IsFinished { get; private set; }
        public bool IsSuccessed { get; private set; } = true;

        public bool Start()
        {
            while (!IsFinished)
            {
                IsSuccessed = _desk.DoTurn();
                IsFinished = !IsSuccessed || _desk.AllOpened;
            }

            return IsSuccessed;
        }
    }
}