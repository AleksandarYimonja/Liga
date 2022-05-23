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
    public partial class Igraci : Form
    {
        int broj_sloga = 0;
        DataTable tabela;
        DataTable dt_klub;

        public Igraci()
        {
            InitializeComponent();
        }

        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Igrac", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);

            adapter = new SqlDataAdapter("SELECT * FROM Klub", veza);
            dt_klub = new DataTable();
            adapter.Fill(dt_klub);

            cmbKlub.DataSource = dt_klub;
            cmbKlub.ValueMember = "id";
            cmbKlub.DisplayMember = "naziv";
        }

        private void Txt_Load()
        {
            if (tabela.Rows.Count == 0)
            {
                txtID.Text = "";
                txtIme.Text = "";
                txtPrezime.Text = "";
                cmbKlub.SelectedValue = -1;

                btnDelete.Enabled = false;
            }
            else
            {
                txtID.Text = tabela.Rows[broj_sloga]["id"].ToString();
                txtIme.Text = tabela.Rows[broj_sloga]["ime"].ToString();
                txtPrezime.Text = tabela.Rows[broj_sloga]["prezime"].ToString();
                cmbKlub.SelectedValue = tabela.Rows[broj_sloga]["klubID"];

                btnDelete.Enabled = true;
            }

            if (broj_sloga == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
            }

            if (broj_sloga == tabela.Rows.Count - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            Txt_Load();
        }

        private void Igraci_Load(object sender, EventArgs e)
        {
            Load_Data();
            Txt_Load();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            Txt_Load();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            Txt_Load();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count - 1;
            Txt_Load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("INSERT INTO Igrac (Ime, Prezime, KlubID) VALUES('");
            naredba.Append(txtIme.Text + "', '");
            naredba.Append(txtPrezime.Text + "', ");
            naredba.Append(cmbKlub.SelectedValue + ")");

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

            Load_Data();
            broj_sloga = tabela.Rows.Count - 1;
            Txt_Load();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("UPDATE igrac SET ");
            naredba.Append("ime = '" + txtIme.Text + "', ");
            naredba.Append("prezime = '" + txtPrezime.Text + "', ");
            naredba.Append("klubID = " + cmbKlub.SelectedValue + " ");
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

            Load_Data();
            Txt_Load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string naredba = "DELETE FROM Igrac WHERE id = " + txtID.Text;

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);

            bool brisano = false;

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();

                brisano = true;
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }

            if (brisano)
            {
                Load_Data();
                if (broj_sloga > 0) broj_sloga--;
                Txt_Load();
            }
        }
    }
}
