using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace crudbetamart
{
    public partial class BetaMartCrud : Form
    {

        private OleDbConnection con = new OleDbConnection();

        public BetaMartCrud()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\HP\Documents\bmcrud.accdb";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNama.Text == "" || txtJenis.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
                {
                    MessageBox.Show("REQUIRED MISSING FIELD!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into bmdb (ID,Nama,Jenis,Jumlah,Harga)values('" + txtId.Text + "','" + txtNama.Text + "','" + txtJenis.Text + "','" + txtJumlah.Text + "','" + txtHarga.Text + "')";

                cmd.ExecuteNonQuery();
                MessageBox.Show("NEW DATA HAS BEEN SUCCESSFULLY SAVED.", "MASSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        void ClearText()
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string query = "select * from bmdb";

                cmd.CommandText = query;


                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNama.Text == "" || txtJenis.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
                {
                    MessageBox.Show("REQUIRED MISSING FIELD!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("WANT TO UPDATE THIS RECORD?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.Connection = con;
                    string query = "update bmdb set Nama='" + txtNama.Text + "' ,Jenis='" + txtJenis.Text + "' ,Jumlah='" + txtJumlah.Text + "' ,Harga='" + txtHarga.Text + "' WHERE ID='" + txtId.Text + "'";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("NEW DATA HAS BEEN SUCCESSFULLY UPDATED.", "MASSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("WANT TO DELETE THIS RECORD?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from bmdb Where ID='" + txtId.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("NEW DATA HAS BEEN SUCCESSFULLY DELETED.", "MASSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
