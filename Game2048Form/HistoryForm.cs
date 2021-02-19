using Game2048Form.Models;
using Game2048Form.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048Form
{
    public partial class HistoryForm : Form
    {
        private readonly Serializ _serialize;
        private Button[] buttons = new Button[10];
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
            int counter = 0;

            int x = 10;
            int y = 10;


            foreach (var item in gamers.Take(10))
            {
                var level = item.Score;

                MyLabel label = new MyLabel();
                label.Left = x;
                label.Top = y;
                label.Text = item.Name;
                label.AutoSize = true;
                label.ForeColor = System.Drawing.Color.White;
                label.Font = new Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                label.Number = counter;
                label.MouseEnter += new EventHandler(pictureBox_MouseEnter);
                label.MouseLeave += new EventHandler(pictureBox_MouseLeave);
                counter++;

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

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            var delete = sender as MyLabel;

            MyButton button = new MyButton();
            button.Left = delete.Bounds.X + 250;
            button.Top = delete.Bounds.Y;
            button.Size = new Size(25, 25);
            button.Number = delete.Number;
            button.UserName = delete.Text;
            button.BackgroundImage = Properties.Resources.trash_25;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            button.Click += new EventHandler(delete_User);

            buttons[delete.Number] = button;
            panel1.Controls.Add(button);
        }

        private async void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            await Task.Delay(4500);

            var deletedButtonNumber = (sender as MyLabel).Number; 

            panel1.Controls.Remove(buttons[deletedButtonNumber]);
        }

        private async void delete_User(object sender, EventArgs e)
        {
            var userName = (sender as MyButton).UserName;
            _serialize.DeleteGamers(userName);

            await Task.Delay(200);
            this.Close();
        }
    }

    public class MyLabel :Label
    {
        public int Number { get; set; }
    }
    public class MyButton : Button
    {
        public int Number { get; set; } 
        public string UserName { get; set; }
    }
}
