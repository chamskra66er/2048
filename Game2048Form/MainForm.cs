﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGame2048;
using System.Media;

namespace Game2048Form
{
    public partial class MainForm : Form
    {
        const int size = 4;
        private Model model;
        private bool isSound = true;
        public static int timeGame { get; private set; } = 0;
        private Button[,] buttons;

        private static SoundPlayer sound = new SoundPlayer(Properties.Resources._2_2);

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

        private void SoundPlay()
        {
            if(isSound)
            {
                sound.Play();
                Task.Delay(100);
            }
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
                        buttons[i, j].BackColor = Color.Gray;
                    }
                    buttons[i, j].Font = new System.Drawing.Font("Courier New", 16.0F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
            label1.Text ="Score: "+ Model.score.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Start();

            this.Invoke(new EventHandler(timer1_Tick));
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;           
            if (!model.IsGameOver())
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        SoundPlay();
                        model.Up();
                        break;
                    case Keys.Down:
                        SoundPlay();
                        model.Down();
                        break;
                    case Keys.Left:
                        SoundPlay();
                        model.Left();
                        break;
                    case Keys.Right:
                        SoundPlay();
                        model.Right();                      
                        break;
                    default:
                        break;
                }
                UpdateButtons();
            }
            else
            {
                timer1.Stop();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            timeGame += 1;
            TimeSpan result = TimeSpan.FromSeconds(timeGame);
            label2.Text = result.ToString("mm':'ss");
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            if(isSound)
            {
                btnSound.Image = Properties.Resources.soundOff_30;
                isSound = false;
            }
            else
            {
                btnSound.Image = Properties.Resources.sound_30;
                isSound = true;
            }
        }
    }
}
