using ChameleonGame.Model;
using ChameleonGame.Persistance;

namespace ChameleonGame.View
{
    public partial class GameForm : Form
    {
        public event EventHandler<(int r, int c)>? CellClicked;
        public event EventHandler<int>? NewGame;
        public event EventHandler<string>? SaveGame;
        public event EventHandler<string>? LoadGame;

        private readonly GameModel _gameModel;
        private (int r, int c)? _selectedCell = null;

        private int currentBoardSize = 0;
        private Button[,]? cellButtons;
        private bool _centerHandlerAttached = false;
        private const int cellSize = 90;
        private int _cellInnerMargin = 6;
        private const int SelectionThickness = 6;

        public GameForm()
        {
            InitializeComponent();
            _gameModel = new GameModel();

            CellClicked += (s, e) => OnCellClicked(e);
            NewGame +=  OnNewGame;
            SaveGame += OnSaveGame;
            LoadGame += OnLoadGame;
            _gameModel.ErrorOccurred += (s, e) => OnError(e);
            _gameModel.BoardChanged += (s, e) => RenderBoard(_gameModel.Board!);
            _gameModel.CurrentPlayerChanged += (s, e) => ShowCurrentPlayer(_gameModel.CurrentPlayer);
            _gameModel.GameOver += (s, e) => OnGameOver(_gameModel.Winner);
        }

        public void RenderBoard(ChameleonBoard board)
        {
            if (board == null) return;

            if (currentBoardSize != board.Size || cellButtons == null)
            {
                GenerateBoardButtons(board.Size);
                currentBoardSize = board.Size;
            }

            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    Cell cell = board[r, c];
                    Button button = cellButtons![r, c];

                    switch (cell.Color)
                    {
                        case CellColor.Red:
                            if (cell.Piece == null)
                            {
                                if (button.Image != Properties.Resources.cell_red)
                                {
                                    button.Image = Properties.Resources.cell_red;
                                }
                            }
                            else if (cell.Piece.Owner == Player.Red && button.Image != Properties.Resources.cell_red_with_red_chameleon)
                            {
                                button.Image = Properties.Resources.cell_red_with_red_chameleon;
                            }
                            else if (cell.Piece.Owner == Player.Green && button.Image != Properties.Resources.cell_red_with_green_chameleon)
                            {
                                button.Image = Properties.Resources.cell_red_with_green_chameleon;
                            }
                            break;
                        case CellColor.Green:
                            if (cell.Piece == null)
                            {
                                if (button.Image != Properties.Resources.cell_green)
                                {
                                    button.Image = Properties.Resources.cell_green;
                                }
                            }
                            else if (cell.Piece.Owner == Player.Red && button.Image != Properties.Resources.cell_green_with_red_chameleon)
                            {
                                button.Image = Properties.Resources.cell_green_with_red_chameleon;
                            }
                            else if (cell.Piece.Owner == Player.Green && button.Image != Properties.Resources.cell_green_with_green_chameleon)
                            {
                                button.Image = Properties.Resources.cell_green_with_green_chameleon;
                            }
                            break;
                        case CellColor.Gray:
                            if (cell.Piece == null)
                            {
                                if (button.Image != Properties.Resources.cell_gray)
                                {
                                    button.Image = Properties.Resources.cell_gray;
                                }
                            }
                            else if (cell.Piece.Owner == Player.Red && button.Image != Properties.Resources.cell_gray_with_red_chameleon)
                            {
                                button.Image = Properties.Resources.cell_gray_with_red_chameleon;
                            }
                            else if (cell.Piece.Owner == Player.Green && button.Image != Properties.Resources.cell_gray_with_green_chameleon)
                            {
                                button.Image = Properties.Resources.cell_gray_with_green_chameleon;
                            }
                            break;
                    }

                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black;

                    if (button.Parent is Panel container)
                    {
                        if (_selectedCell != null && r == _selectedCell.Value.r && c == _selectedCell.Value.c)
                        {
                            container.Padding = new Padding(SelectionThickness);
                            container.BackColor = Color.Gold;

                            container.Padding = new Padding(_cellInnerMargin);
                            container.BackColor = boardPanel.BackColor;
                        }
                    }

                    button.Enabled = true;
                }
            }
        }

        private void GenerateBoardButtons(int size)
        {
            boardPanel.Controls.Clear();
            boardPanel.ColumnStyles.Clear();
            boardPanel.RowStyles.Clear();

            boardPanel.ColumnCount = size;
            boardPanel.RowCount = size;

            cellButtons = new Button[size, size];

            boardPanel.SuspendLayout();
            boardPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            for (int c = 0; c < size; c++)
            {
                boardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));
            }
            for (int r = 0; r < size; r++)
            {
                boardPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
            }

            int innerSize = cellSize - 12;
            if (innerSize < 8) innerSize = cellSize - 2;

            _cellInnerMargin = Math.Max(0, (cellSize - innerSize) / 2);


            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Panel cellContainer = new Panel()
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Padding = new Padding(_cellInnerMargin),
                        BackColor = boardPanel.BackColor,
                    };

                    Button button = new Button()
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Tag = (r, c),
                        Font = new Font(FontFamily.GenericSansSerif, 10),
                        Text = "",
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,
                    };
                    button.Click += CellButton_Click;

                    cellContainer.Controls.Add(button);
                    cellButtons[r, c] = button;
                    boardPanel.Controls.Add(cellContainer, c, r);
                }
            }

            boardPanel.ResumeLayout();

            int gridWidth = size * cellSize;
            int gridHeight = size * cellSize;

            boardPanel.AutoSize = false;
            boardPanel.Size = new Size(gridWidth, gridHeight);
            boardPanel.Dock = DockStyle.None;
            boardPanel.Anchor = AnchorStyles.None;

            void CenterBoardPanel()
            {
                if (boardPanel.Parent == null) return;
                Control parent = boardPanel.Parent;

                int headerHeight = menuStrip1.Height + pictureBox1.Height + labelTurnIndicator.Height;

                int x = (parent.ClientSize.Width - boardPanel.Width) / 2;
                int y = Math.Max(headerHeight + 10, (parent.ClientSize.Height - boardPanel.Height) / 2 + headerHeight / 2);
                boardPanel.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }

            CenterBoardPanel();

            if (!_centerHandlerAttached && boardPanel.Parent != null)
            {
                boardPanel.Parent.Resize += (s, e) => CenterBoardPanel();
                _centerHandlerAttached = true;
            }
        }

        public void ShowCurrentPlayer(Player currentPlayer)
        {
            string currentPlayerString = currentPlayer == Player.Red ? "Red Player" : "Green Player";
            labelTurnIndicator.Text = $"It\'s {currentPlayerString}\'s turn!";
            labelTurnIndicator.ForeColor = currentPlayer == Player.Red ? Color.Red : Color.Green;
        }

        private void CellButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button) return;
            if (button.Tag is not ValueTuple<int, int> indexes) return;

            var (r, c) = indexes;
            CellClicked?.Invoke(this, (r, c));
        }

        public void OnGameOver(Player? winner)
        {
            boardPanel.Enabled = false;

            string winnerString = winner == Player.Red ? "Red" : "Green";
            string message = $"Game Over.\n{winnerString} wins.";
            MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using NewGameForm newGameForm = new NewGameForm();
            if (newGameForm.ShowDialog() == DialogResult.OK)
            {
                NewGame?.Invoke(this, newGameForm.SelectedSize);
            }
        }

        private void SaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Chameleon Save (*.txt)|*.txt|All files (*.*)|*.*" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveGame?.Invoke(this, saveFileDialog.FileName);
            }
        }

        private void LoadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Chameleon Save (*.txt)|*.txt|All files (*.*)|*.*" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadGame?.Invoke(this, openFileDialog.FileName);
            }
        }

        private void OnCellClicked((int r, int c) e)
        {
            if (_gameModel.Board == null || !boardPanel.Enabled)
            {
                OnError("No active game. Start a new or load one first!");
                return;
            }

            _gameModel.OnCellClicked(e.r, e.c);           
        }

        private void OnNewGame(object? sender, int e)
        {
            try
            {
                _gameModel.NewGame(e);
                boardPanel.Enabled = true;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
            }
        }

        private void OnSaveGame(object? sender, string e)
        {
            try
            {
                _gameModel.DataAccess = new ChameleonTxtDataAccess();
                _gameModel.SaveGame(e);
            }
            catch (Exception ex)
            {

                OnError(ex.Message);
            }
        }

        private void OnLoadGame(object? sender, string e)
        {
            try
            {
                _gameModel.DataAccess = new ChameleonTxtDataAccess();
                _gameModel.LoadGame(e);
                boardPanel.Enabled = true;
            }
            catch (Exception ex)
            {

                OnError(ex.Message);
            }
        }
    }
}
