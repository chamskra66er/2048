using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGame2048;

namespace Game2048Form
{
    public partial class MainForm : Form
    {
        const int size = 4;
        private Model model;
        private bool isActive = true;
        private Button[,] buttons;

        public MainForm()
        {
            InitializeComponent();

            model =new Model(size);
            buttons = new Button[size, size];
            buttons[0, 0] = btn1;
            buttons[0, 1] = btn2;
            buttons[0, 2] = btn3;
            buttons[0, 3] = btn4;
            buttons[1, 0] = btn5;
            buttons[1, 1] = btn6;
            buttons[1, 2] = btn7;
            buttons[1, 3] = btn8;
            buttons[2, 0] = btn9;
            buttons[2, 1] = btn10;
            buttons[2, 2] = btn11;
            buttons[2, 3] = btn12;
            buttons[3, 0] = btn13;
            buttons[3, 1] = btn14;
            buttons[3, 2] = btn15;
            buttons[3, 3] = btn16;
        }

        private void Start()
        {          
            model.Start();
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            for (int i = 0; i < model.size; i++)
            {
                for (int j = 0; j < model.size; j++)
                {
                    int number = model.GetMap(j, i);
                    if (number == 0)
                    {
                        buttons[i, j].Text = "";
                        buttons[i, j].BackColor = Color.Green;
                    }
                    else if(number>0&&number<=64)
                    {
                        buttons[i, j].Text = number.ToString();
                        buttons[i, j].BackColor = Color.Green;
                    }
                    else if (number > 64 && number <= 512)
                    {
                        buttons[i, j].Text = number.ToString();
                        buttons[i, j].BackColor = Color.Orange;
                    }
                    else if(number>512&&number<2048)
                    {
                        buttons[i, j].Text = number.ToString();                        
                        buttons[i, j].BackColor = Color.Red;
                    }
                    else if(number >= 2048)
                    {
                        buttons[i, j].Text = number.ToString();
                        buttons[i, j].BackColor = Color.Black;
                    }
                    buttons[i, j].Font = new System.Drawing.Font("Courier New", 16.0F, buttons[i, j].Font.Style ^ FontStyle.Bold);
                }
            }
            label1.Text ="Score: "+ Model.score.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;

            if (model.IsGameOver())
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        model.Up();
                        break;
                    case Keys.Down:
                        model.Down();
                        break;
                    case Keys.Left:
                        model.Left();
                        break;
                    case Keys.Right:
                        model.Right();                      
                        break;
                    default:
                        break;
                }
                UpdateButtons();
            }
            else
            {
                MessageBox.Show("Game over...");

                InputForm input = new InputForm();
                input.score = Model.score.ToString();
                input.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }
    }
}
