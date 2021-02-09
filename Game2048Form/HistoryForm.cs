using Game2048Form.Models;
using Game2048Form.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Game2048Form
{
    public partial class HistoryForm : Form
    {
        private readonly Serializ _serialize;
        public HistoryForm()
        {
            InitializeComponent();
            _serialize = new Serializ();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            var model = _serialize.GetAllByOrder().OrderByDescending(x=>x.Score);
            CreateGamersControls(model);
        }
        private void CreateGamersControls(IEnumerable<Gamer> gamers)
        {
            int x = 10;
            int y = 10;


            foreach (var item in gamers.Take(10))
            {
                var level = item.Score;

                Label label = new Label();
                label.Left = x;
                label.Top = y;
                label.Text = item.Name;
                label.AutoSize = true;
                label.ForeColor = System.Drawing.Color.White;
                label.Font = new Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                panel1.Controls.Add(label);

                Label label1 = new Label();
                label1.Left = x;
                label1.Top = y+20;
                label1.Text = item.Score.ToString();
                label1.AutoSize = true;
                label1.ForeColor = System.Drawing.Color.White;
                label1.Font = new Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                panel1.Controls.Add(label1);

                TimeSpan result = TimeSpan.FromSeconds(item.Time);
                Label label2 = new Label();
                label2.Left = x+70;
                label2.Top = y;
                label2.Text = result.ToString("mm':'ss");
                label2.AutoSize = true;
                label2.ForeColor = System.Drawing.Color.White;
                label2.Font = new Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                panel1.Controls.Add(label2);

                if (level>=7000)
                {
                    CreatePicture(3, true, y);
                }
                else if(level>=6000)
                {
                    CreatePicture(2, true, y);
                }
                else if(level>=5000)
                {
                    CreatePicture(1, true, y);
                }
                else if(level>=4000)
                {
                    CreatePicture(3, false, y);
                }
                else if(level>=3000)
                {
                    CreatePicture(2, false, y);
                }
                else if(level>=2000)
                {
                    CreatePicture(1, false, y);
                }

                y += label.Height + 2;
                y += label1.Height + 10;
            }
        }
        private void CreatePicture(int count, bool level, int y)
        {
            int x1 = 10;

            if(level)
            {
                for (int i = 0; i < count; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Left = x1 + 155 + i*30;
                    pictureBox.Top = y;
                    pictureBox.Size = new Size(25, 25);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = Properties.Resources.korona_50;

                    panel1.Controls.Add(pictureBox);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Left = x1 + 155 + i * 30;
                    pictureBox.Top = y;
                    pictureBox.Size = new Size(25, 25);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = Properties.Resources.zvezda_50;

                    panel1.Controls.Add(pictureBox);
                }
            }           
           
        }
    }
}
