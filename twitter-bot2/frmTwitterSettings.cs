using LinqToTwitter;
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
    public partial class frmTwitterSettings : Form
    {
        public frmTwitterSettings()
        {
            InitializeComponent();
        }

        private void txtAdditionalMessage_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.ConsumerKey = txtTwitterConsumerKey.Text;
            Properties.Settings.Default.Save();
        }

        private void frmTwitterSettings_Load(object sender, EventArgs e)
        {
            txtTwitterConsumerKey.Text = twitter_bot2.Properties.Settings.Default.ConsumerKey;
            txtTwitterConsumerSecret.Text = twitter_bot2.Properties.Settings.Default.ConsumerSecret;
            txtTwitterAccessToken.Text = twitter_bot2.Properties.Settings.Default.AccessToken;
            txtTwitterTokenSecret.Text = twitter_bot2.Properties.Settings.Default.AccessTokenSecret;
             
        }

        private void txtTwitterConsumerSecret_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.ConsumerSecret = txtTwitterConsumerSecret.Text;
            Properties.Settings.Default.Save();
        }

        private void txtTwitterAccessToken_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.AccessToken = txtTwitterAccessToken.Text;
            Properties.Settings.Default.Save();
        }

        private void txtTwitterTokenSecret_TextChanged(object sender, EventArgs e)
        {
            twitter_bot2.Properties.Settings.Default.AccessTokenSecret = txtTwitterTokenSecret.Text;
            Properties.Settings.Default.Save();
        }

        private async void btnTwitterAPITest_ClickAsync(object sender, EventArgs e)
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = twitter_bot2.Properties.Settings.Default.ConsumerKey,
                    ConsumerSecret = twitter_bot2.Properties.Settings.Default.ConsumerSecret,
                    AccessToken = twitter_bot2.Properties.Settings.Default.AccessToken,
                    AccessTokenSecret = twitter_bot2.Properties.Settings.Default.AccessTokenSecret
                }
            };
            var twitterCtx = new TwitterContext(auth);
 
            try
            {
                string status = "Bitte besucht unseren Online Shop. \n #Shop #Onlineshop #ecommerce " + twitter_bot2.Properties.Settings.Default.strDomain ;

                var tweet = await twitterCtx.TweetAsync(status);

            } catch(Exception ex)
            {
                MessageBox.Show("Twitter API Verbindung fehlgeschlagen. Bitte überprüfen Sie Ihre Werte.", "MSSQL Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
    }
}
