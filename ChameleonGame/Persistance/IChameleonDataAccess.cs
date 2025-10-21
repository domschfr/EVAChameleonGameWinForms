using ChameleonGame.Model;

namespace ChameleonGame.Persistance
{
    public interface IChameleonDataAccess
    {
        void SaveGame(String path, ChameleonBoard board, Player currentPlayer);
        ChameleonBoard LoadGame(String path, out Player currentPlayer);
    }
}
