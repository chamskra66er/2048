using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var gamer = new Gamer()
            {
                Name = textBox1.Text,
                Score = label3.Text
            };
            var model = new Serializ();
            model.DataSave(gamer);

            this.Close();
        }
    }
}
