using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistyka_1
{
    public partial class Form2 : Form
    {
        public Form2(List<float> tmp , List<int> tmp2)
        {
            InitializeComponent();
            duration_of_crit = tmp;
            act_draw = tmp2;
        }

        List<float> duration_of_crit = new List<float>();
        List<int> act_draw = new List<int>();
        private Graphics g;


        private void Form2_Load(object sender, EventArgs e)
        {
            Pen marker = new Pen(Color.Red, 15);
            pictureBox1.Image = new Bitmap(1000,1000);
            g = Graphics.FromImage(pictureBox1.Image);
            var font = new Font("TimeNewRoman", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            int i = 0;
            int start = 0;
            foreach (int step in duration_of_crit)
            {
                g.DrawLine(marker, start, 20+15*i, start+15*step, 20+15*i);

                g.DrawString((act_draw[i]+1).ToString()+"("+step+")", font, Brushes.Black, new Point(start, (20 + 15 * i)-10));
                i++;
                start = start+15*step;
                
            }

            /* foreach (int xD in duration_of_crit)
                 System.Console.Write(xD + " ");
             System.Console.WriteLine();*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }
    }
}
