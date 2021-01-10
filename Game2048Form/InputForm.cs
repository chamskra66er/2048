using System;
using System.Windows.Forms;
using Game2048Form.Services;
using Game2048Form.Models;

namespace Game2048Form
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public string score
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }
        public string name
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var gamer = new Gamer()
            {
                Name = name,
                Score = int.Parse(label3.Text),
                Time = MainForm.timeGame
            };
            var model = new Serializ();
            model.DataSave(gamer);

            this.Close();
        }
    }
}
