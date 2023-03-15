using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twitter_bot2
{
    public partial class frmDatenbank : Form
    {
        public frmDatenbank()
        {
            InitializeComponent();
        }

        private void txtMSSQLSernameInstanz_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.datenbank_server = txtMSSQLSernameInstanz.Text;
            Properties.Settings.Default.Save();

        }

        private void txtMSSQLDatebankname_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.datenbank_datenbank = txtMSSQLDatebankname.Text;
            Properties.Settings.Default.Save();

        }

        private void txtMSSQLDatenbankBenutzername_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.datenbank_benutzer = txtMSSQLDatenbankBenutzername.Text;
            Properties.Settings.Default.Save();
        }

        private void txtMSSQLDatenbankPasswort_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.datenbank_pwd = txtMSSQLDatenbankPasswort.Text;
            Properties.Settings.Default.Save();
        }

        private void frmDatenbank_Load(object sender, EventArgs e)
        {
            txtMSSQLSernameInstanz.Text = twitter_bot2.Properties.Settings.Default.datenbank_server;
            txtMSSQLDatebankname.Text = twitter_bot2.Properties.Settings.Default.datenbank_datenbank;
            txtMSSQLDatenbankPasswort.Text = twitter_bot2.Properties.Settings.Default.datenbank_pwd;
            txtMSSQLDatenbankBenutzername.Text = twitter_bot2.Properties.Settings.Default.datenbank_benutzer;
        }

        private void btnJTLWawiReadIn_Click(object sender, EventArgs e)
        {
            string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer + "; password=" + Properties.Settings.Default.datenbank_pwd, Properties.Settings.Default.datenbank_datenbank);

            SqlConnection connection1 = new SqlConnection(connstring1);
            if (connection1.State == ConnectionState.Closed)
            {
                try
                {

                    connection1.Open();
                    MessageBox.Show("MSSQL Datenbankverbindung erfolgreich getestet!.", "MSSQL Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Information );

                }
                catch (Exception ex)
                {
                    MessageBox.Show("MSSQL Datenbankverbindung fehlgeschlagen.Bitte Datenbankeinstellungen öffnen.", "MSSQL Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Form frmDatenbank = new frmDatenbank();
                    frmDatenbank.Show();
                }
            }
        }
    }
}
