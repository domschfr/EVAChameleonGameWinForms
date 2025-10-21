namespace ChameleonGame.View
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            boardPanel = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            loadGameToolStripMenuItem = new ToolStripMenuItem();
            labelTurnIndicator = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // boardPanel
            // 
            boardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            boardPanel.Location = new Point(0, 110);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(627, 626);
            boardPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, saveGameToolStripMenuItem, loadGameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(627, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(77, 20);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(77, 20);
            saveGameToolStripMenuItem.Text = "Save Game";
            saveGameToolStripMenuItem.Click += saveGameToolStripMenuItem_Click;
            // 
            // loadGameToolStripMenuItem
            // 
            loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            loadGameToolStripMenuItem.Size = new Size(79, 20);
            loadGameToolStripMenuItem.Text = "Load Game";
            loadGameToolStripMenuItem.Click += loadGameToolStripMenuItem_Click;
            // 
            // labelTurnIndicator
            // 
            labelTurnIndicator.AutoSize = true;
            labelTurnIndicator.Font = new Font("Segoe UI", 12F);
            labelTurnIndicator.Location = new Point(258, 86);
            labelTurnIndicator.Name = "labelTurnIndicator";
            labelTurnIndicator.Size = new Size(126, 21);
            labelTurnIndicator.TabIndex = 0;
            labelTurnIndicator.Text = "It's no one's turn";
            labelTurnIndicator.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(603, 50);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(627, 737);
            Controls.Add(pictureBox1);
            Controls.Add(labelTurnIndicator);
            Controls.Add(boardPanel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chameleon Game";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel boardPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem loadGameToolStripMenuItem;
        private Label labelTurnIndicator;
        private PictureBox pictureBox1;
    }
}
