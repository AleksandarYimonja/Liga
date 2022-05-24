using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Liga
{
    public partial class Mecevi : Form
    {
        DataTable tabela;
        SqlDataAdapter adapter;
        DataTable dt_klub1;
        DataTable dt_klub2;
        DataTable dt_igrac1;
        DataTable dt_igrac2;
        DataTable dt_sezona;

        public Mecevi()
        {
            InitializeComponent();
        }

        void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            adapter = new SqlDataAdapter("Select * FROM MecPogled", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            dataGridView1.ReadOnly = true;

            adapter = new SqlDataAdapter("SELECT * FROM Klub", veza);
            dt_klub1 = new DataTable();
            dt_klub2 = new DataTable();
            adapter.Fill(dt_klub1);
            adapter.Fill(dt_klub2);

            cmbKlub1.DataSource = dt_klub1;
            cmbKlub1.ValueMember = "id";
            cmbKlub1.DisplayMember = "naziv";

            cmbKlub2.DataSource = dt_klub2;
            cmbKlub2.ValueMember = "id";
            cmbKlub2.DisplayMember = "naziv";

            adapter = new SqlDataAdapter("SELECT * FROM Igrac", veza);
            dt_igrac1 = new DataTable();
            dt_igrac2 = new DataTable();
            adapter.Fill(dt_igrac1);
            adapter.Fill(dt_igrac2);

            cmbGolovi1.DataSource = dt_igrac1;
            cmbGolovi1.ValueMember = "id";
            cmbGolovi1.DisplayMember = "prezime";

            cmbGolovi2.DataSource = dt_igrac2;
            cmbGolovi2.ValueMember = "id";
            cmbGolovi2.DisplayMember = "prezime";

            adapter = new SqlDataAdapter("SELECT * FROM Sezona", veza);
            dt_sezona = new DataTable();
            adapter.Fill(dt_sezona);

            cmbSezona.DataSource = dt_sezona;
            cmbSezona.ValueMember = "id";
            cmbSezona.DisplayMember = "naziv";
        }

        private void Mecevi_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indeksRed = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1[0, indeksRed].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listGolovi1.Items.Add(cmbGolovi1.SelectedValue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listGolovi1.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listGolovi2.Items.Add(cmbGolovi2.SelectedValue);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listGolovi2.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("INSERT INTO Mec (Klub1ID, Klub2ID, datum, SezonaID) VALUES(");
            naredba.Append(cmbKlub1.SelectedValue + ", ");
            naredba.Append(cmbKlub2.SelectedValue + ", '");
            naredba.Append(dateTimePicker1.Value.Date + "', ");
            naredba.Append(cmbSezona.SelectedValue + ")");

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba.ToString(), veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            for (int i = 0; i < listGolovi1.Items.Count; i++)
            {
                naredba = new StringBuilder("INSERT INTO Gol (StrelacID, AsistiraoID, MecID) VALUES(");
                naredba.Append(listGolovi1.Items[i] + ", ");
                naredba.Append("1" + ", ");
                naredba.Append(txtID.Text + ")");

                veza = Konekcija.Connect();
                komanda = new SqlCommand(naredba.ToString(), veza);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }

            for (int i = 0; i < listGolovi2.Items.Count; i++)
            {
                naredba = new StringBuilder("INSERT INTO Gol (StrelacID, AsistiraoID, MecID) VALUES(");
                naredba.Append(listGolovi2.Items[i] + ", ");
                naredba.Append("1" + ", ");
                naredba.Append(txtID.Text + ")");

                veza = Konekcija.Connect();
                komanda = new SqlCommand(naredba.ToString(), veza);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }

            Load_Data();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("UPDATE Mec SET ");
            naredba.Append("klub1ID = " + cmbKlub1.SelectedValue + ", ");
            naredba.Append("klub2ID = " + cmbKlub2.SelectedValue + ", ");
            naredba.Append("datum = '" + dateTimePicker1.Value.Date + "', ");
            naredba.Append("sezonaID = " + cmbSezona.SelectedValue + " ");
            naredba.Append("WHERE id = " + txtID.Text);

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba.ToString(), veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            string naredbaDel = "DELETE FROM Gol WHERE MecID = " + txtID.Text;

            veza = Konekcija.Connect();
            komanda = new SqlCommand(naredbaDel, veza);

            for (int i = 0; i < listGolovi1.Items.Count; i++)
            {
                naredba = new StringBuilder("INSERT INTO Gol (StrelacID, AsistiraoID, MecID) VALUES(");
                naredba.Append(listGolovi1.Items[i] + ", ");
                naredba.Append("1" + ", ");
                naredba.Append(txtID.Text + ")");

                veza = Konekcija.Connect();
                komanda = new SqlCommand(naredba.ToString(), veza);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }

            for (int i = 0; i < listGolovi2.Items.Count; i++)
            {
                naredba = new StringBuilder("INSERT INTO Gol (StrelacID, AsistiraoID, MecID) VALUES(");
                naredba.Append(listGolovi2.Items[i] + ", ");
                naredba.Append("1" + ", ");
                naredba.Append(txtID.Text + ")");

                veza = Konekcija.Connect();
                komanda = new SqlCommand(naredba.ToString(), veza);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }

            Load_Data();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string naredba = "DELETE FROM Gol WHERE MecID = " + txtID.Text;

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);

            naredba = "DELETE FROM Mec WHERE id = " + txtID.Text;

            veza = Konekcija.Connect();
            komanda = new SqlCommand(naredba, veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            Load_Data();
        }
    }
}
