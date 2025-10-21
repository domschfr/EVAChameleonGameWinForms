using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChameleonGame.View
{
    public partial class NewGameForm : Form
    {
        public int SelectedSize { get; private set; } = 3;

        public NewGameForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object? sender, EventArgs e)
        {
            if (easyRadio.Checked) SelectedSize = 3;
            else if (mediumRadio.Checked) SelectedSize = 5;
            else if (hardRadio.Checked) SelectedSize = 7;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
