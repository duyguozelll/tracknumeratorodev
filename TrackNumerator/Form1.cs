using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackNumerator
{
    public partial class Form1 : Form
    {
        int nSayisi;
        int minDeger;
        int maxDeger;
        int aralik;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            nSayisi = Convert.ToInt32(textBox1.Text);
            minDeger = Convert.ToInt32(textBox2.Text, 16);
            maxDeger = Convert.ToInt32(textBox3.Text, 16);
            aralik = maxDeger - minDeger;
            Random random = new Random();

            ArrayList TrackArray = new ArrayList(nSayisi);

            for (int i = 0; i < nSayisi; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Height = 15;
                picture.Width = 15;
                picture.Location = new Point(random.Next(25, panel1.Width - 25), random.Next(25, panel1.Height - 25));
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                if (i <= aralik)
                {
                    Label label = new Label();
                    label.Text = (i + minDeger).ToString("X");
                    label.Font = new Font("Arial", 6, FontStyle.Italic);
                    label.Height = 10;
                    label.Location = new Point(picture.Location.X, picture.Location.Y - 10);
                    panel1.Controls.Add(label);
                    picture.ImageLocation = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Gorseller\green-round-button-26746.jpg";
                }
                else
                {
                    picture.ImageLocation = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Gorseller\kırmızı.jpg";
                }
                panel1.Controls.Add(picture);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen sadece sayı giriniz");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }


        }
    }
}

