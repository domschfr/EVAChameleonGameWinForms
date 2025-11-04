namespace ChameleonGame.Model
{
    public interface IChameleonDataAccess
    {
        void SaveGame(String path, ChameleonBoard board, Player currentPlayer);
        ChameleonBoard LoadGame(String path, out Player currentPlayer);
    }
}
