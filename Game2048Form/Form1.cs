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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomisizeDesign();
        }
        //added for designing
        private void CustomisizeDesign()
        {
            panel1.Visible = false;
        }
        public string name;
        private void HideSubMenu()
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }


        Button[,] buttons;
        Random random = new Random();

        bool isGameOver;
        bool moved;
        const int  mapSize = 4;
        int value = 0;
        int[,] nums = new int[,] { {0, 0, 0, 0, 0, 0 },{0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, };
      
        private void AddRandomumber()
        {
            if (isGameOver)
            {
                return;
            }
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(1, 5);
                int y = random.Next(1, 5);
                if (nums[x,y]==0)
                {
                    nums[x, y] = random.Next(1, 3) * 2;                   
                    return;
                }
            }           
        }
        void ConvertNums()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (nums[i+1, j+1] == 0)
                    {
                        buttons[i, j].Text = "";
                        buttons[i, j].BackColor = Color.Gray;
                    }
                    if (nums[i + 1, j + 1] <= 32 && nums[i + 1, j + 1] > 0)
                    {
                        buttons[i, j].Text = "" + nums[i + 1, j + 1];
                        buttons[i, j].Font = new System.Drawing.Font("Courier New", 10.0F, buttons[i, j].Font.Style ^ FontStyle.Bold);
                        buttons[i, j].BackColor = Color.Green;
                    }
                    if (nums[i + 1, j + 1] <= 256 && nums[i + 1, j + 1] > 32)
                    {
                        buttons[i, j].Text = "" + nums[i + 1, j + 1];
                        buttons[i, j].Font = new System.Drawing.Font("Courier New", 10.0F, buttons[i, j].Font.Style ^ FontStyle.Bold);
                        buttons[i, j].BackColor = Color.Orange;
                    }
                    if (nums[i + 1, j + 1] <= 1024 && nums[i + 1, j + 1] > 256)
                    {
                        buttons[i, j].Text = "" + nums[i + 1, j + 1];
                        buttons[i, j].Font = new System.Drawing.Font("Courier New", 10.0F, buttons[i, j].Font.Style ^ FontStyle.Bold);
                        buttons[i, j].BackColor = Color.Red;
                    }
                }

            }
        }

        void CheckWin()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (nums[i + 1, j + 1] == 2048)
                    {
                        MessageBox.Show("Поздравляю. Вы выиграли "+"со счетом: "+value, "Сообщение");

                        //Application.Restart();
                    }
                }
            }

            IsGameOver();
        }

        public void Leftt()
        {
            int sx = 0, sy = -1;
            moved = false;
            for (int x = 1; x <mapSize+1; x++)
            {
                for (int y =2; y <mapSize+1; y++)
                {                   
                    if (nums[x, y] > 0)
                    {                     
                        for (int i = 0; i < 3; i++)
                        {
                            if (nums[x + sx, y + sy] == 0)
                            {                                
                                    nums[x + sx, y + sy] = nums[x, y];
                                    nums[x, y] = 0;
                                    x += sx;
                                    y += sy;
                                    moved = true;                                
                            }
                            if (y<=1) { break;  }                           
                        }
                    }
                }
            }
            ///////////////
            for (int x = 1; x < mapSize+1; x++)
            {
                for (int y = 2; y <mapSize+1; y++)
                {
                    if (nums[x, y] > 0)
                    {
                        if (nums[x + sx, y + sy] == nums[x, y])
                        {
                            nums[x + sx, y + sy] = nums[x, y] * 2;
                            value = value + nums[x, y] * 2; // счет
                            for (int i = 0; i < 3; i++)
                            {
                                if (nums[x - sx, y - sy] > 0)
                                {
                                    nums[x, y] = nums[x - sx, y - sy];
                                    x -= sx;
                                    y -= sy;
                                }                                
                            }                           
                            nums[x, y] = 0;
                            moved = true;
                        }                       
                    }
                }
            }
            ConvertNums();
            if (moved)
            {
                AddRandomumber();
                ConvertNums();
            }
        }
        public void Rightt()
        {
            moved = false;

            int sx = 0, sy = +1;
            moved = false;
            for (int x = 1; x < mapSize+1; x++)
            {
                for (int y = mapSize-1; y >= 1; y--)
                {
                    if (nums[x, y] > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (nums[x + sx, y + sy] == 0)
                            {
                                nums[x + sx, y + sy] = nums[x, y];
                                nums[x, y] = 0;
                                x += sx;
                                y += sy;
                                moved = true;
                            }
                            if (y >= 4) { break; }
                        }
                    }
                }
            }
            /////////////////
           for (int x = 1; x < mapSize+1; x++)
            {
                for (int y = mapSize- 1; y>= 1; y--)
                {
                    if (nums[x, y] > 0)
                    {
                        if (nums[x + sx, y + sy] == nums[x, y])
                        {
                            nums[x + sx, y + sy] = nums[x, y] * 2;
                            value = value + nums[x, y] * 2; // счет
                            for (int i = 0; i < 3; i++)
                            {
                                if (nums[x - sx, y - sy] > 0)
                                {
                                    nums[x, y] = nums[x - sx, y - sy];
                                    x -= sx;
                                    y -= sy;
                                }
                            }
                            nums[x, y] = 0;
                            moved = true;
                        }
                    }
                }
            }
            
            ConvertNums();
            if (moved)
            {
                AddRandomumber();
                ConvertNums();
            }

        }
        public void Up()
        {
            moved = false;
            int sx = -1, sy = 0;
            for (int x = 1; x < mapSize+1; x++)
            {
                for (int y = 2; y < mapSize+1; y++)
                {
                    if (nums[y, x] > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (nums[y + sx, x + sy] == 0)
                            {
                                nums[y + sx, x + sy] = nums[y, x];
                                nums[y, x] = 0;
                                x += sy;
                                y += sx;
                                moved = true;
                            }
                            if (y <= 1) { break; }
                        }
                    }
                }
            }
            ///////////////////
            
            for (int x = 1; x < mapSize + 1; x++)
            {
                for (int y = 1; y < mapSize + 1; y++)
                {
                    if (nums[x, y] > 0)
                    {
                        if (nums[x + sx, y + sy] == nums[x, y])
                        {
                            nums[x + sx, y + sy] = nums[x, y] * 2;

                            value = value + nums[x, y] * 2; // счет
                            for (int i = 0; i < 3; i++)
                            {
                                if (nums[x - sx, y - sy] > 0)
                                {
                                    nums[x, y] = nums[x - sx, y - sy];
                                    x -= sx;
                                    y -= sy;
                                }
                            }
                            nums[x, y] = 0;
                            moved = true;
                        }
                    }
                }
            }

            ConvertNums();
            if (moved)
            {
                AddRandomumber();
                ConvertNums();
            }

        }
        public void Down()
        {
            moved = false;
            int sx = +1, sy = 0;
            for (int x = 1; x < mapSize + 1; x++ ) 
            {
                for (int y = mapSize-1; y >= 1; y--)
                {
                    if (nums[y, x] > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (nums[y + sx, x + sy] == 0)
                            {
                                nums[y + sx, x + sy] = nums[y, x];
                                nums[y, x] = 0;
                                x += sy;
                                y += sx;
                                moved = true;
                            }
                            if (y >= 4) { break; }
                        }
                    }
                }
            }
            ////////////////////////////////
            ////
           
            for (int x = mapSize ; x >=1; x--)//int x = 1; x < mapSize + 1; x++
            {
                for (int y = mapSize; y >=1; y--)
                {
                    if (nums[x, y] > 0)
                    {
                        if (nums[x + sx, y + sy] == nums[x, y])
                        {
                            nums[x + sx, y + sy] = nums[x, y] * 2;
                            value = value + nums[x, y] * 2; // счет

                            for (int i = 0; i < 3; i++)
                            {
                                if (nums[x - sx, y - sy] > 0)
                                {
                                    nums[x, y] = nums[x - sx, y - sy];
                                    x -= sx;
                                    y -= sy;
                                }
                            }
                            nums[x, y] = 0;
                            moved = true;
                        }
                    }
                }

            }
            
                ConvertNums();
            if (moved)
            {
                AddRandomumber();
                ConvertNums();
            }

        }

        public bool IsGameOver()
        {
            if (isGameOver)
            {
                var message = MessageBox.Show("Вы проиграли"+"со счетом: "+value+"\n. Хотите сохранить результат?", "Сообщение",
                    MessageBoxButtons.YesNo);
                if(message == DialogResult.Yes)
                {
                    var inputForm = new InputForm();
                    inputForm.score = value.ToString();
                    inputForm.ShowDialog();
                }

                return isGameOver;
            }
            else
            {
                for (int x = 1; x < mapSize+1; x++)
                {
                    for (int y = 1; y < mapSize+1; y++)
                    {
                        if (nums[x,y] == 0)
                            return false;
                    }
                }

                for (int x = 1; x < mapSize+1; x++)
                {
                    for (int y = 1; y < mapSize+1; y++)
                    {
                        if (nums[x, y] == nums[x + 1, y] || nums[x, y] == nums[x, y + 1])
                            return false;
                    }
                }
            }
            isGameOver = true;
            return isGameOver;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isGameOver = false;
            this.Text = "Game2048";
            label2.Text = "" + value;
            buttons = new Button[4, 4];
            buttons[0, 0] = button1;
            buttons[0, 1] = button2;
            buttons[0, 2] = button3;
            buttons[0, 3] = button4;
            buttons[1, 0] = button5;
            buttons[1, 1] = button6;
            buttons[1, 2] = button7;
            buttons[1, 3] = button8;
            buttons[2, 0] = button9;
            buttons[2, 1] = button10;
            buttons[2, 2] = button11;
            buttons[2, 3] = button12;
            buttons[3, 0] = button13;
            buttons[3, 1] = button14;
            buttons[3, 2] = button15;
            buttons[3, 3] = button16;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i, j].Enabled = false;
                    buttons[i,j].FlatAppearance.BorderSize = 0;
                    buttons[i, j].FlatStyle = FlatStyle.Flat;                   
                }
            }            
            AddRandomumber();
            AddRandomumber();          
            ConvertNums();
        }       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            HideSubMenu();
            panel2.BringToFront();

            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.D:

                    Rightt();
                    ConvertNums();
                    CheckWin();
                    break;

                case Keys.A:
                    
                    Leftt();
                    ConvertNums();
                    CheckWin();
                    break;

                case Keys.W:

                   Up();
                    ConvertNums();
                    CheckWin();
                    break;

                case Keys.S:
                   Down();
                    ConvertNums();
                    CheckWin();
                    break;
                    
                default:
                    break;
            }
            label2.Text = "" + value;
            

        }
        private void button17_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel1);
            panel1.BringToFront();            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }
    }


}
