using ChameleonGame.Model;
using System.Text;

namespace ChameleonGame.Persistance
{
    public class ChameleonTxtDataAccess : IChameleonDataAccess
    {
        public void SaveGame(String path, ChameleonBoard board, Player currentPlayer)
        {
            try
            {
                StringBuilder sb = new();
                _ = sb.Append($"{(currentPlayer == Player.Red ? 'r' : 'g')}\t{board.Size.ToString()}\n");

                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        if (board[i, j].Piece != null)
                        {
                            _ = sb.Append($"{i}\t{j}\t{(board[i, j].Piece!.Owner == Player.Red ? 'r' : 'g')}\t{board[i, j].Piece!.ColorChangeDelay}\n");
                        }
                    }
                }

                using StreamWriter streamWriter = new(path);
                streamWriter.Write(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new ChameleonDataException(ex.Message, ex);
            }
        }

        public ChameleonBoard LoadGame(String path, out Player currentPlayer)
        {
            try
            {
                using StreamReader streamReader = new(path);
                string[] boardInfo = (streamReader.ReadLine() ?? String.Empty).Split('\t');
                currentPlayer = boardInfo[0] == "r" ? Player.Red : Player.Green;
                _ = int.TryParse(boardInfo[1], out int size);
                ChameleonBoard board = new(size);

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine() ?? String.Empty;
                    string[] pieceString = line.Split('\t');

                    _ = int.TryParse(pieceString[0], out int i);
                    _ = int.TryParse(pieceString[1], out int j);
                    Player owner = pieceString[2] == "r" ? Player.Red : Player.Green;
                    _ = int.TryParse(pieceString[3], out int delay);

                    Piece piece = new(owner, board[i, j]);
                    if (delay > 0)
                    {
                        piece.IncrementDelay();
                    }

                    board[i, j].ChangePiece(piece);
                }

                return board;
            }
            catch (Exception ex)
            {

                throw new ChameleonDataException(ex.Message, ex);
            }
        }
    }

}
