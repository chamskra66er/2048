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
using System.Collections.Generic;

namespace Game2048Form
{
    public partial class MainForm : Form
    {
        const int size = 4;
        private Model model;
        private bool isActive = true;

        public MainForm()
        {
            InitializeComponent();

            model =new Model(size);                     
        }

        private void Start()
        {          
            model.Start();
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            string[,] maps = new string[size, size];
            for (int i = 0; i < model.size; i++)
            {
                for (int j = 0; j < model.size; j++)
                {
                    int number = model.GetMap(j, i);
                    if (number != 0)
                        maps[i, j] = number.ToString();
                    else
                        maps[i, j] = "";
                }
            }


            btn1.Font = new System.Drawing.Font("Courier New", 16.0F, btn1.Font.Style ^ FontStyle.Bold);
            btn1.BackColor = Color.Green;
            btn1.ForeColor = Color.White;
            btn1.Text = maps[0, 0];

            btn2.Font = new System.Drawing.Font("Courier New", 16.0F, btn2.Font.Style ^ FontStyle.Bold);
            btn2.BackColor = Color.Green;
            btn2.ForeColor = Color.White;
            btn2.Text = maps[0, 1];

            btn3.Font = new System.Drawing.Font("Courier New", 16.0F, btn3.Font.Style ^ FontStyle.Bold);
            btn3.BackColor = Color.Green;
            btn3.ForeColor = Color.White;
            btn3.Text = maps[0, 2];

            btn4.Font = new System.Drawing.Font("Courier New", 16.0F, btn4.Font.Style ^ FontStyle.Bold);
            btn4.BackColor = Color.Green;
            btn4.ForeColor = Color.White;
            btn4.Text = maps[0, 3];

            btn5.Font = new System.Drawing.Font("Courier New", 16.0F, btn5.Font.Style ^ FontStyle.Bold);
            btn5.BackColor = Color.Green;
            btn5.ForeColor = Color.White;
            btn5.Text = maps[1, 0];

            btn6.Font = new System.Drawing.Font("Courier New", 16.0F, btn6.Font.Style ^ FontStyle.Bold);
            btn6.BackColor = Color.Green;
            btn6.ForeColor = Color.White;
            btn6.Text = maps[1, 1];

            btn7.Font = new System.Drawing.Font("Courier New", 16.0F, btn7.Font.Style ^ FontStyle.Bold);
            btn7.BackColor = Color.Green;
            btn7.ForeColor = Color.White;
            btn7.Text = maps[1, 2];

            btn8.Font = new System.Drawing.Font("Courier New", 16.0F, btn8.Font.Style ^ FontStyle.Bold);
            btn8.BackColor = Color.Green;
            btn8.ForeColor = Color.White;
            btn8.Text = maps[1, 3];

            btn9.Font = new System.Drawing.Font("Courier New", 16.0F, btn9.Font.Style ^ FontStyle.Bold);
            btn9.BackColor = Color.Green;
            btn9.ForeColor = Color.White;
            btn9.Text = maps[2, 0];

            btn10.Font = new System.Drawing.Font("Courier New", 16.0F, btn10.Font.Style ^ FontStyle.Bold);
            btn10.BackColor = Color.Green;
            btn10.ForeColor = Color.White;
            btn10.Text = maps[2, 1];

            btn11.Font = new System.Drawing.Font("Courier New", 16.0F, btn11.Font.Style ^ FontStyle.Bold);
            btn11.BackColor = Color.Green;
            btn11.ForeColor = Color.White;
            btn11.Text = maps[2, 2];

            btn12.Font = new System.Drawing.Font("Courier New", 16.0F, btn12.Font.Style ^ FontStyle.Bold);
            btn12.BackColor = Color.Green;
            btn12.ForeColor = Color.White;
            btn12.Text = maps[2, 3];

            btn13.Font = new System.Drawing.Font("Courier New", 16.0F, btn13.Font.Style ^ FontStyle.Bold);
            btn13.BackColor = Color.Green;
            btn13.ForeColor = Color.White;
            btn13.Text = maps[3, 0];

            btn14.Font = new System.Drawing.Font("Courier New", 16.0F, btn14.Font.Style ^ FontStyle.Bold);
            btn14.BackColor = Color.Green;
            btn14.ForeColor = Color.White;
            btn14.Text = maps[3, 1];

            btn15.Font = new System.Drawing.Font("Courier New", 16.0F, btn15.Font.Style ^ FontStyle.Bold);
            btn15.BackColor = Color.Green;
            btn15.ForeColor = Color.White;
            btn15.Text = maps[3, 2];

            btn16.Font = new System.Drawing.Font("Courier New", 16.0F, btn16.Font.Style ^ FontStyle.Bold);
            btn16.BackColor = Color.Green;
            btn16.ForeColor = Color.White;
            btn16.Text = maps[3, 3];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
