using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twitter_bot2
{
    public partial class frmJTLShopConnector : Form
    {
        public frmJTLShopConnector()
        {
            InitializeComponent();
        }

        private void txtDomain_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.strDomain  = txtDomain.Text;
            Properties.Settings.Default.Save();
        }

        private void frmJTLShopConnector_Load(object sender, EventArgs e)
        {
            txtDomain.Text = Properties.Settings.Default.strDomain;

        }

        private void btnJTLShopConnectorPluginTest_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
