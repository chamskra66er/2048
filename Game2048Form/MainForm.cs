using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048Form
{
    public partial class MainForm : Form
    {
        const int size = 4;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            
            switch (e.KeyCode)
            {
                case Keys.Up:
                    
                    break;
                case Keys.Down:
                    
                    break;
                case Keys.Left:

                    break;
                case Keys.Right:

                    break;
                default:
                    MessageBox.Show("This button is'n active...");
                    break;
            }
        }
    }
}
