using Npgsql;
using System.Data;

namespace DemoPractice1._2
{
    public partial class Form1 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
            bind_data("select * FROM products ORDER BY id ASC");
            Form2 form2 = new Form2();
            labellogin.Text = data.login;
        }



        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123456;Database=products;");

        public void bind_data(string sql)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    bind_data("select * FROM products ORDER BY price ASC");
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    bind_data("select * FROM products ORDER BY price DESC");
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    bind_data("select * FROM products ORDER BY name ASC");
                    comboBox2.SelectedIndex = -1;
                    textBox1.Text = "";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    bind_data("select * FROM products ORDER BY name DESC");
                    comboBox2.SelectedIndex = -1;
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    bind_data($"SELECT * FROM products WHERE name LIKE '%{textBox1.Text}%'");
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
