using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace APILuceedDesktopApp
{
    public partial class CallAPI : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LuceedAPI;Integrated Security=True;");
        public int Id;

        public CallAPI()
        {
            InitializeComponent();
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "select * from Payment";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "select * from Product,Payment";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            displayData();
        }

        private void CallAPI_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void displayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product,Payment";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            displayData();

        }
        protected void SaveInfo()
        {
            string query = "INSERT INTO Product " + "(Id,Aritkli_Uid,Naziv_Artikla,Kolicina,Iznos,Usluga)" + "VALUES (@Id,@Artikli_Uid,@Naziv_Artikla,@Kolicina,@Iznos,@Usluga)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", txtBox1.Text);
            cmd.Parameters.AddWithValue("@Aritkli_Uid", txtBox2.Text);
            cmd.Parameters.AddWithValue("@Naziv_Artikla", txtBox3.Text);
            cmd.Parameters.AddWithValue("@Kolicina", txtBox4.Text);
            cmd.Parameters.AddWithValue("@Iznos", txtBox5.Text);
            cmd.Parameters.AddWithValue("@Usluga", txtBox6.Text);
            cmd.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Product VALUES (@Id,@Artikli_Uid,@Naziv_Artikla,@Kolicina,@Iznos,@Usluga)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", txtBox1.Text);
                cmd.Parameters.AddWithValue("@Artikli_Uid", txtBox2.Text);
                cmd.Parameters.AddWithValue("@Naziv_Artikla", txtBox3.Text);
                cmd.Parameters.AddWithValue("@Kolicina", txtBox4.Text);
                cmd.Parameters.AddWithValue("@Iznos", txtBox5.Text);
                cmd.Parameters.AddWithValue("@Usluga", txtBox6.Text);
                cmd = new SqlCommand("INSERT INTO Product VALUES (@Id,@Payment_Uid,@PaymentTypeName,@PaymentAmount,@OverGroupPayment,@NameOfOverGroupPaymentType)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", txtBox1.Text);
                cmd.Parameters.AddWithValue("@Payment_Uid", txtBox2.Text);
                cmd.Parameters.AddWithValue("@PaymentTypeName", txtBox3.Text);
                cmd.Parameters.AddWithValue("@PaymentAmount", txtBox4.Text);
                cmd.Parameters.AddWithValue("@OverGroupPayment", txtBox5.Text);
                cmd.Parameters.AddWithValue("@NameOfOverGroupPaymentType", txtBox6.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Succesfully added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                ResetControls();
            }
        }
        private bool IsValid()
        {
            if (txtBox1.Text == string.Empty)
            {
                MessageBox.Show("Id is required", "Failer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            displayData();
        }

        private void txtBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", txtBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Article succesuffully deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                ResetControls();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (Id > 0)
            //{
            //    SqlCommand cmd = new SqlCommand("UPDATE Product SET Id = @Id,Artikli_Uid = @Artikli_Uid,Naziv_Artikla = @Naziv_Artikla,Kolicina = @Kolicina,Iznos = @Iznos,Usluga = @Usluga ", con);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddWithValue("@Id", txtBox1.Text);
            //    cmd.Parameters.AddWithValue("@Artikli_Uid", txtBox2.Text);
            //    cmd.Parameters.AddWithValue("@Naziv_Artikla", txtBox3.Text);
            //    cmd.Parameters.AddWithValue("@Kolicina", txtBox4.Text);
            //    cmd.Parameters.AddWithValue("@Iznos", txtBox5.Text);
            //    cmd.Parameters.AddWithValue("@Usluga", txtBox6.Text);


            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("Articles are succesfully updated !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    displayData();
            //    ResetControls();
            //}
            //else
            //{
            //    MessageBox.Show("You need to fill the forms!", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void ResetControls()
        {
            Id = 0;
            txtBox1.Clear();
            txtBox2.Clear();
            txtBox3.Clear();
            txtBox4.Clear();
            txtBox5.Clear();
            txtBox6.Clear();

            txtBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            txtBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=LuceedAPI;Integrated Security=True;"))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using(DataTable dt = new DataTable("Product"))
                    {
                        using(SqlCommand cmd = new SqlCommand("select * from Product where Id=@Id or Artikli_Uid like @Artikli_Uid", cn))
                        {
                            cmd.Parameters.AddWithValue("Id", txtSearch.Text);
                            cmd.Parameters.AddWithValue("Artikli_Uid", txtSearch.Text);
                            cmd.Parameters.AddWithValue("Naziv_Artikla", txtSearch.Text);
                            cmd.Parameters.AddWithValue("Kolicina", txtSearch.Text);
                            cmd.Parameters.AddWithValue("Iznos", txtSearch.Text);
                            cmd.Parameters.AddWithValue("Usluga", txtSearch.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//enter
                btnSearch.PerformClick();
        }
    }
}
