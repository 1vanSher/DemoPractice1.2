using Microsoft.VisualBasic.Logging;
using Npgsql;
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
    public partial class Form2 : Form
    {

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123456;Database=products;");

        int count = 0;

        async public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"select * from users where login = '{textBox1.Text}'";
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];

                
                data.login = dt.Rows[0][1].ToString();
                if (count != 3 && dt != null && dt.Rows[0][2].ToString() == textBox2.Text && dt.Rows[0][1].ToString() == textBox1.Text)
                {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                else
                {
                    count++;
                    if (count >= 3)
                    {
                        button1.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        Form3 form3 = new Form3();
                        form3.ShowDialog();
                        await Task.Delay(20000);
                        this.button1.Enabled = true;
                        this.textBox1.Enabled = true;
                        this.textBox2.Enabled = true;

                    }
                    label4.Text = "CRITICAL ERROR";
                    conn.Close();
                }

                conn.Close(); 
            }
            catch
            {
                count++;
                if (count >= 3)
                {
                    button1.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    Form3 form3 = new Form3();
                    form3.ShowDialog();
                    await Task.Delay(20000);
                    this.button1.Enabled = true;
                    this.textBox1.Enabled = true;
                    this.textBox2.Enabled = true;
                }
                label4.Text = "CRITICAL ERROR";
                conn.Close();
            }
        }
    }
}
