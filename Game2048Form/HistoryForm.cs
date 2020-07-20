using Game2048Form.Models;
using Game2048Form.Services;
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
            CreateGamersControls(_serialize.GetAllGamers());
        }
        private void CreateGamersControls(List<Gamer> gamers)
        {
            int x = 55;
            int y = 22;

            foreach (var item in gamers)
            {
                Label label = new Label();
                label.Left = x;
                label.Top = y;
                label.Text = item.Name + " - " + item.Score;
                label.AutoSize = true;
                label.ForeColor = System.Drawing.Color.White;
                label.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                panel1.Controls.Add(label);
                y += label.Height + 10;
            }
        }
    }
}
