using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Discrete_Histogram_Equalization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int min, max;
            try {
                min = Convert.ToInt32(MinPixel.Text);
                max = Convert.ToInt32(MaxPixel.Text);
            }
            catch( Exception ex ) {
                MessageBox.Show("請輸入正確格式");
                MinPixel.Text = "";
                MaxPixel.Text = "";
                return;
            }
            if( min < 0 || min > 256 || max < 0 || max >256)
            {
                MessageBox.Show("請輸入正確格式");
                MinPixel.Text = "";
                MaxPixel.Text = "";
                return;
            }
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                Histogram_Equalization.Handle(openFileDialog1.FileName,Source, Answer,min,max);
                PaintHistogram.Paint_Source(openFileDialog1.FileName,Source_R,0);
                PaintHistogram.Paint_Source(openFileDialog1.FileName, Source_G,1);
                PaintHistogram.Paint_Source(openFileDialog1.FileName, Source_B,2);
                PaintHistogram.Paint_Answer(openFileDialog1.FileName, Answer_R, Answer, 0);
                PaintHistogram.Paint_Answer(openFileDialog1.FileName, Answer_G, Answer, 1);
                PaintHistogram.Paint_Answer(openFileDialog1.FileName, Answer_B, Answer, 2);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Answer_Click(object sender, EventArgs e)
        {

        }
    }
}
