using Game2048Form.Models;
using Game2048Form.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            var model = _serialize.GetAllByOrder();
            CreateGamersControls(model);
        }
        private void CreateGamersControls(IEnumerable<Gamer> gamers)
        {
            int x = 10;
            int y = 10;


            foreach (var item in gamers)
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
                y += label.Height + 3;

                Label label1 = new Label();
                label1.Left = x;
                label1.Top = y;
                label1.Text = item.Score.ToString();
                label1.AutoSize = true;
                label1.ForeColor = System.Drawing.Color.White;
                label1.Font = new Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                panel1.Controls.Add(label1);
                y += label1.Height + 10;
                                          
                
                if (level>=700)
                {
                    
                }
                else
                {

                }


            }
        }
    }
}
