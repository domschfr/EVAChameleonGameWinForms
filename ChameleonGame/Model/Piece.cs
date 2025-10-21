namespace ChameleonGame.Model
{
    public class Piece(Player owner, Cell cell)
    {
        public Player Owner { get; private set; } = owner;
        public Cell CurrentCell { get; private set; } = cell;
        public int ColorChangeDelay { get; private set; } = 0;


        public void SetCurrentCell(Cell cell)
        {
            CurrentCell = cell;
        }

        public void ChangeColor()
        {
            Owner = Owner == Player.Red ? Player.Green : Player.Red;
            ResetDelay();
        }

        public void IncrementDelay()
        {
            ColorChangeDelay++;
        }

        public void ResetDelay()
        {
            ColorChangeDelay = 0;
        }
    }
}
