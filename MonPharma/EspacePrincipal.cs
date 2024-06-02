using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonPharma
{
    public partial class EspacePrincipal : Form
    {
        public EspacePrincipal()
        {
            InitializeComponent();
        }
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\MA BDD\\MonPharma.accdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'monPharmaDataSet2.Ventes'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.ventesTableAdapter.Fill(this.monPharmaDataSet2.Ventes);
            // TODO: cette ligne de code charge les données dans la table 'monPharmaDataSet1.Medicaments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.medicamentsTableAdapter.Fill(this.monPharmaDataSet1.Medicaments);
            // TODO: cette ligne de code charge les données dans la table 'monPharmaDataSet.Clients'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.clientsTableAdapter.Fill(this.monPharmaDataSet.Clients);
            buttonAjout.Visible = false;
            buttonModif.Visible = false;
            dataGridView1.Visible = false;
            buttonSuppr.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            panel5.Visible = false;
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAjout.Visible = true;
            buttonSuppr.Visible = false;
            panel3.Visible = true;
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonModif.Visible = true;
            buttonAjout.Visible = false;
            panel3.Visible = true;
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSuppr.Visible = true;
            buttonAjout.Visible = false;
            buttonModif.Visible = false;
            panel3.Visible = true;
        }

        private void afficherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {
            OleDbCommand command = cnn.CreateCommand();
            cnn.Open();
            command.CommandText = "Insert into Medicaments(Nom, Description, PU, DateExpiration, Quantite) values('"+textBox1.Text+"','"+textBox3.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Value+"','"+textBox4.Text+"')";
            command.Connection = cnn;
            command.ExecuteNonQuery();
            MessageBox.Show("Un nouveau médicament a été inséré !");
            textBox1.Focus();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            cnn.Close();
        }

        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            dataGridView1.Visible = false;
        }

        private void afficherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void afficherToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand command = cnn.CreateCommand();
            cnn.Open();
            command.CommandText = "Insert into Clients(Nom, Telephone, Adresse) values('" + textBox8.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')";
            command.Connection = cnn;
            command.ExecuteNonQuery();
            MessageBox.Show("Le client a été inséré !");
            textBox8.Focus();
            textBox8.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand command = cnn.CreateCommand();
            cnn.Open();
            command.CommandText = "Insert into Ventes(DateVente, Total) values('" + dateTimePicker2.Value + "','" + textBox11.Text + "')";
            command.Connection = cnn;
            command.ExecuteNonQuery();
            MessageBox.Show("La vente a été insérée !");
            textBox11.Focus();
            textBox11.Text = "";
            cnn.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fermeture de l'application !");
            Application.Exit();
        }
    }
}
