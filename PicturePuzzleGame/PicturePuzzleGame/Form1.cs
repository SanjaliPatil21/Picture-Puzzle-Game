using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePuzzleGame
{
    public partial class Form1 : Form
    {
        int timeLeft = 60;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if((string)pictureBox6.Tag=="0")
            {
                Swap(pictureBox9, pictureBox6);
            }
            else if((string)pictureBox8.Tag=="0")
            {
                Swap(pictureBox9 , pictureBox8);
            }
            Check();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if((string)pictureBox9.Tag == "0")
            {
                Swap(pictureBox8, pictureBox9);
            }
            else if((string)pictureBox5.Tag == "0")
            {
                Swap(pictureBox8 , pictureBox5);
            }
            else if((string)pictureBox7.Tag == "0")
            {
                Swap(pictureBox8 , pictureBox7);
            }
            Check();
        }

        private void Swap(PictureBox picA, PictureBox picB)
        {
            PictureBox picT = new PictureBox();
            picT.Image = picA.Image;
            picT.Tag = picA.Tag;
            picA.Image = picB.Image;
            picA.Tag = picB.Tag;
            picB.Image = picT.Image;
            picB.Tag = picT.Tag;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if((string)pictureBox8.Tag=="0")
            {
                Swap(pictureBox7, pictureBox8);
            }
            else if((string)pictureBox4.Tag=="0")
            {
                Swap(pictureBox7 , pictureBox4);
                 
            }
            Check();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if((string)pictureBox1.Tag=="0")
            {
                Swap(pictureBox4, pictureBox1);
            }
            else if((string)pictureBox5.Tag=="0")
            {
                Swap(pictureBox4, pictureBox5);
            }
            else if((string)pictureBox7.Tag=="0")
            {
                Swap(pictureBox4 , pictureBox7);
            }
            Check();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if((string)pictureBox2.Tag=="0")
            {
                Swap(pictureBox1, pictureBox2);
            }
            else if((string)pictureBox4.Tag=="0")
            {
                Swap(pictureBox1, pictureBox4);
            }
            Check();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if((string)pictureBox1.Tag=="0")
            {
                Swap(pictureBox2, pictureBox1);
            }
            else if((string)pictureBox5.Tag=="0")
            {
                Swap(pictureBox2, pictureBox5);
            }
            else if((string)pictureBox3.Tag=="0")
            {
                Swap(pictureBox2, pictureBox3);
            }
            Check();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if ((string)pictureBox2.Tag == "0")
            {
                Swap(pictureBox3, pictureBox2);
            }
            else if ((string)pictureBox6.Tag == "0")
            {
                Swap(pictureBox3, pictureBox6);
            }
            Check();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if((string)pictureBox3.Tag=="0")
            {
                Swap(pictureBox6 , pictureBox3);
            }
            else if((string)pictureBox5.Tag=="0")
            {
                Swap(pictureBox6, pictureBox5);
            }
            else if ((string)pictureBox9.Tag =="0")
            {
                Swap(pictureBox6, pictureBox9);
            }
            Check();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if((string)pictureBox2.Tag=="0")
            {
                Swap(pictureBox5 , pictureBox2);
            }
            else if ((string)pictureBox4.Tag == "0")
            {
                Swap(pictureBox5, pictureBox4);
            }
            else if ((string)pictureBox6.Tag == "0")
            {
                Swap(pictureBox5, pictureBox6);
            }
            else if ((string)pictureBox8.Tag == "0")
            {
                Swap(pictureBox5, pictureBox8);
            }
            Check();
        }

        public void Check()
        {
            if((string)pictureBox1.Tag=="1" && (string)pictureBox2.Tag=="2" && 
                (string)pictureBox3.Tag == "3" && (string)pictureBox4.Tag == "4" && 
                (string)pictureBox5.Tag == "5" && (string)pictureBox6.Tag == "6" && 
                (string)pictureBox7.Tag == "7" && (string)pictureBox8.Tag == "8" && 
                (string)pictureBox9.Tag =="0")
            {
                timer1.Stop();
                MessageBox.Show("You have completed the puzzle on time!!!", "Congratulations", MessageBoxButtons.OK);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timeLeft--;
            lblTimer.Text = "Time Left: " + timeLeft + "s";

            if (timeLeft <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Time's up! Try again.", "Game Over", MessageBoxButtons.OK);
               
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timeLeft = 60;
            lblTimer.Text = "Time Left: 60s";
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Timer stopped!", "Info", MessageBoxButtons.OK);
        }

        private void ResetPuzzle()
        {
            // Prepare list of image-tag pairs
            List<(Image img, string tag)> tiles = new List<(Image, string)>()
    {
        (Properties.Resources._1, "1"),
        (Properties.Resources._2, "2"),
        (Properties.Resources._3, "3"),
        (Properties.Resources._4, "4"),
        (Properties.Resources._5, "5"),
        (Properties.Resources._6, "6"),
        (Properties.Resources._7, "7"),
        (Properties.Resources._8, "8"),
        (Properties.Resources._0, "0")
    };

            // Shuffle the list
            Random rnd = new Random();
            tiles = tiles.OrderBy(x => rnd.Next()).ToList();

            // Assign shuffled images to PictureBoxes
            PictureBox[] boxes = {
        pictureBox1, pictureBox2, pictureBox3,
        pictureBox4, pictureBox5, pictureBox6,
        pictureBox7, pictureBox8, pictureBox9
    };

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Image = tiles[i].img;
                boxes[i].Tag = tiles[i].tag;
            }
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetPuzzle();            
            timeLeft = 60;            
            lblTimer.Text = "Time Left: 60s";
            timer1.Start();
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Timer stopped!", "Info", MessageBoxButtons.OK);
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            timeLeft = 60;
            lblTimer.Text = "Time Left: 60s";
            timer1.Start();
        }
    }
}
