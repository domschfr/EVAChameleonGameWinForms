namespace ChameleonGame.Model
{
    public enum Player
    {
        Red,
        Green
    }

    public class GameModel
    {

        public ChameleonBoard? Board { get; private set; }
        public IChameleonDataAccess? DataAccess { get; set; }
        public Player CurrentPlayer { get; private set; }
        public Player? Winner { get; private set; } = null;
        private bool isGameOver = false;

        public event EventHandler? BoardChanged;
        public event EventHandler? CurrentPlayerChanged;
        public event EventHandler<Player?>? GameOver;

        public void NewGame(int size)
        {
            Board = new ChameleonBoard(size);
            Board.InitializePieces();
            CurrentPlayer = Player.Red;

            OnBoardChange();
        }

        public void LoadGame(string path)
        {
            Board = DataAccess!.LoadGame(path, out Player currentPlayer);
            CurrentPlayer = currentPlayer;

            OnBoardChange();
        }

        public void SaveGame(string path)
        {
            DataAccess!.SaveGame(path, Board!, CurrentPlayer);
        }

        public void EndTurn()
        {
            Board!.PerformColorChange();
            CurrentPlayer = CurrentPlayer == Player.Red ? Player.Green : Player.Red;

            if (IsGameOver())
            {
                OnGameOver(Winner);
            }

            OnCurrentPlayerChanged();
        }

        public bool IsGameOver()
        {
            bool redHasPieces = Board!.PlayerHasPieces(Player.Red);
            bool greenHasPieces = Board!.PlayerHasPieces(Player.Green);

            if (redHasPieces && !greenHasPieces && !isGameOver)
            {
                Winner = Player.Red;
                isGameOver = true;
                return true;
            }

            if (greenHasPieces && !redHasPieces && !isGameOver)
            {
                Winner = Player.Green;
                isGameOver = true;
                return true;
            }

            return false;
        }

        private void OnBoardChange()
        {
            BoardChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnCurrentPlayerChanged()
        {
            CurrentPlayerChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameOver(Player? winner)
        {
            GameOver?.Invoke(this, winner);
        }
    }
}
