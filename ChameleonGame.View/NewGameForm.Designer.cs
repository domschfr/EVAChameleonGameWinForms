namespace ChameleonGame.View
{
    partial class NewGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameForm));
            cancelButton = new Button();
            okButton = new Button();
            newGameLabel = new Label();
            difficultyLabel = new Label();
            easyRadio = new RadioButton();
            mediumRadio = new RadioButton();
            hardRadio = new RadioButton();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 250);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(159, 36);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Location = new Point(328, 250);
            okButton.Name = "okButton";
            okButton.Size = new Size(159, 36);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OKButton_Click;
            // 
            // newGameLabel
            // 
            newGameLabel.AutoSize = true;
            newGameLabel.Font = new Font("Segoe UI", 20F);
            newGameLabel.Location = new Point(179, 31);
            newGameLabel.Name = "newGameLabel";
            newGameLabel.Size = new Size(148, 37);
            newGameLabel.TabIndex = 2;
            newGameLabel.Text = "New Game";
            // 
            // difficultyLabel
            // 
            difficultyLabel.AutoSize = true;
            difficultyLabel.Font = new Font("Segoe UI", 12F);
            difficultyLabel.Location = new Point(179, 80);
            difficultyLabel.Name = "difficultyLabel";
            difficultyLabel.Size = new Size(143, 21);
            difficultyLabel.TabIndex = 3;
            difficultyLabel.Text = "Choose a difficulty!";
            // 
            // easyRadio
            // 
            easyRadio.AutoSize = true;
            easyRadio.CheckAlign = ContentAlignment.BottomCenter;
            easyRadio.Checked = true;
            easyRadio.Font = new Font("Segoe UI", 10F);
            easyRadio.Location = new Point(62, 159);
            easyRadio.Name = "easyRadio";
            easyRadio.Size = new Size(84, 36);
            easyRadio.TabIndex = 4;
            easyRadio.TabStop = true;
            easyRadio.Text = "Easy - 3 x 3";
            easyRadio.UseVisualStyleBackColor = true;
            // 
            // mediumRadio
            // 
            mediumRadio.AutoSize = true;
            mediumRadio.CheckAlign = ContentAlignment.BottomCenter;
            mediumRadio.Font = new Font("Segoe UI", 10F);
            mediumRadio.Location = new Point(198, 159);
            mediumRadio.Name = "mediumRadio";
            mediumRadio.Size = new Size(108, 36);
            mediumRadio.TabIndex = 5;
            mediumRadio.Text = "Medium - 5 x 5";
            mediumRadio.UseVisualStyleBackColor = true;
            // 
            // hardRadio
            // 
            hardRadio.AutoSize = true;
            hardRadio.CheckAlign = ContentAlignment.BottomCenter;
            hardRadio.Font = new Font("Segoe UI", 10F);
            hardRadio.Location = new Point(355, 159);
            hardRadio.Name = "hardRadio";
            hardRadio.Size = new Size(87, 36);
            hardRadio.TabIndex = 6;
            hardRadio.Text = "Hard - 7 x 7";
            hardRadio.UseVisualStyleBackColor = true;
            // 
            // NewGameForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(499, 298);
            Controls.Add(hardRadio);
            Controls.Add(mediumRadio);
            Controls.Add(easyRadio);
            Controls.Add(difficultyLabel);
            Controls.Add(newGameLabel);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewGameForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Game";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button okButton;
        private Label newGameLabel;
        private Label difficultyLabel;
        private RadioButton easyRadio;
        private RadioButton mediumRadio;
        private RadioButton hardRadio;
    }
}