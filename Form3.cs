using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPractice1._2
{
    public partial class Form3 : Form
    {
        private string text = String.Empty;

        public Form3()
        {
            InitializeComponent();
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            double Xpos =  Width * 0.2;
            double Ypos =  Height * 0.2;

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; i++)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Convert.ToInt32(Xpos), Convert.ToInt32(Ypos)));

            //Добавим немного помех
            ///Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0 , Height / 2),
                       new Point(Width , Height / 2));
            //////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 25 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                this.Close();
                Form2 form2 = new Form2();
            }
            else
            {
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                textBox1.Text = string.Empty;
            }

        }
    }
}
