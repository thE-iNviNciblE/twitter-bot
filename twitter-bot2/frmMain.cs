using LinqToTwitter;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Renci.SshNet;
using System.Data.SqlClient;
using System.Net;

namespace twitter_bot2
{
     
    public partial class frmMain : Form
    { 
        public string ConsumerKey = "";
        public string ConsumerSecret = "";
        public string AccessToken = "";
        public string AccessTokenSecret = "";
        private int iadded = 0;
        public string strMsg = "";
        int offset = 0;
        int next = 0;
        bool bStop_tweeting = false;
        string tweeter_waittime = Properties.Settings.Default.tweets_wait_timeout;

        public frmMain()
        {
            InitializeComponent();
        }
        public async Task<string[]> getJTLWawiArtikellisteAsync()
        {
            string[] strData = new string[2001];

            listView2.Items.Clear();

            string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer+"; password=" + Properties.Settings.Default.datenbank_pwd , Properties.Settings.Default.datenbank_datenbank );
            SqlConnection connection = new SqlConnection(connstring1);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();

            }

            try
            { 
                string query = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr,fVKNetto, tartikel.dErstelldatum  FROM tartikel LEFT JOIN tArtikelBeschreibung ON tArtikelBeschreibung.kArtikel = tartikel.kArtikel WHERE tartikel.cAktiv ='Y' AND  tArtikelBeschreibung.kSprache=" + lblkSprache.Text + " AND tArtikelBeschreibung.kPlattform=1 AND (tArtikelBeschreibung.kShop=" + lblkShop.Text + "OR tArtikelBeschreibung.kShop =0) ORDER BY tartikel.dErstelldatum DESC OFFSET " + txtOffsetStart.Text  + " ROWS FETCH NEXT " + txtNextItems.Text  + " ROWS ONLY";
                SqlCommand cmd1 = new SqlCommand(query, connection);
                using (var cursor = cmd1.ExecuteReader())
                {

                 

                    while (cursor.Read())
                    {
                        if (bStop_tweeting == true)
                        {
                            bStop_tweeting = false;
                            break;

                        }
                        string strPath = "JTLShopConnector";

                        if (cmbSprache.Text == "Deutsch")
                        {
                            strPath = "JTLShopConnector";
                        } else if (cmbSprache.Text == "Dänisch")
                        {
                            strPath = "JTLShopConnector_1";
                        }
                        else if (cmbSprache.Text == "Englisch")
                        {
                            strPath = "JTLShopConnector_1";
                        }
                        else if (cmbSprache.Text == "Französisch")
                        {
                            strPath = "JTLShopConnector_1_1";
                        }
                        else if (cmbSprache.Text == "Italenisch")
                        {
                            strPath = "JTLShopConnector_1_1_1";
                        }
                        else if (cmbSprache.Text == "Finnisch")
                        {
                            strPath = "JTLShopConnector_1_1_1";
                        }
                        else if (cmbSprache.Text == "Niederländisch")
                        {
                            strPath = "JTLShopConnector_1_1_1_1";
                        }
                        else if (cmbSprache.Text == "Norwegisch")
                        {
                            strPath = "JTLShopConnector_1_1_1_1_1";
                        }
                        else if (cmbSprache.Text == "Schwedisch")
                        {
                            strPath = "JTLShopConnector_1_1_1_1_1_1";
                        }
                        else if (cmbSprache.Text == "Spanisch")
                        {
                            strPath = "JTLShopConnector_1_1_1_1";
                        }
                        else if (cmbSprache.Text == "Türkisch")
                        {
                            strPath = "JTLShopConnector_1_1_1_1_1_1_1_1";
                        }


                        // Create a request for the URL. 
                        WebRequest request = WebRequest.Create(
                           Properties.Settings.Default.strDomain + "/" + strPath + "?kArtikel=" + cursor["bkArtikel"].ToString()  + "&modus=PathByKArtikel");
                        // If required by the server, set the credentials.
                        request.Credentials = CredentialCache.DefaultCredentials;
                        // Get the response.
                        WebResponse response = request.GetResponse();
                        // Display the status.
                        Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                        // Get the stream containing content returned by the server.
                        Stream dataStream = response.GetResponseStream();
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        Console.WriteLine(responseFromServer);
                        // Clean up the streams and the response.
                        reader.Close();
                        response.Close();


                        ListViewItem lvwData = new ListViewItem();
                        lvwData.Text = cursor["cName"].ToString();
                        lvwData.SubItems.Add(cursor["cBeschreibung"].ToString());
                        lvwData.SubItems.Add(""+ cursor["fVKNetto"]);
                        lvwData.SubItems.Add("");
                        if (responseFromServer.Length > 0)
                        {
                            lvwData.SubItems.Add(Properties.Settings.Default.strDomain + "/" + responseFromServer.Replace("\n","").Replace("     ",""));


                        }  else
                        {
                            lvwData.SubItems.Add(Properties.Settings.Default.strDomain + "/" + responseFromServer);

                        }

                        lvwData.SubItems.Add(cursor["bkArtikel"].ToString()); 
                        lvwData.SubItems.Add(cursor["bArtNr"].ToString());
                        listView2.Items.Add(lvwData);
                         
                    }
                }
                txtOffsetStart.Text = (Convert.ToInt64(txtOffsetStart.Text) + Convert.ToInt64(txtNextItems.Text)).ToString();

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }


            if(bStop_tweeting == false)
            {

                try
                { 
                    string strDomain = Properties.Settings.Default.strDomain;

                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);
                }

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

                for (int i = 0; i <= listView2.Items.Count - 1; i++)
                {
                    if(bStop_tweeting == true)
                    {
                        bStop_tweeting = false;
                        break;
                    }

                    if (Math.Round(Convert.ToDouble(listView2.Items[i].SubItems[2].Text)) == 0.00 || listView2.Items[i].SubItems[4].Text == "https://www.chic-net.de/")
                    {

                    }
                    else
                    {

                        var twitterCtx = new TwitterContext(auth);
                        string status = listView2.Items[i].Text + "\r\n" + txtTwitterAdditional.Text +  " \r\n" + listView2.Items[i].SubItems[4].Text;
                        try
                        {
                            var tweet = await twitterCtx.TweetAsync(status);

                            if (tweet != null)
                            {
                                Console.WriteLine(
                                    "Status returned: " +
                                    "(" + tweet.StatusID + ")" +
                                    tweet.User.Name + ", " +
                                    tweet.Text + "\n");
                                textBox1.Text = "Status returned: " +
                                    "(" + tweet.StatusID + ")" +
                                    tweet.User.Name + ", " +
                                    tweet.Text + "\n";
                                txtTweet_counter.Text = "" + (Convert.ToInt16(txtTweet_counter.Text) + 1);

                                if (Convert.ToInt16(txtTweet_counter.Text) <= 0)
                                {
                                    tmrTweeter_waiter.Enabled = true;
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }



                    }


                }
            }
 


            return strData;
        }

        private void getPossibleShops()
        {

            string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer + "; password=" + Properties.Settings.Default.datenbank_pwd, Properties.Settings.Default.datenbank_datenbank);

            SqlConnection connection1 = new SqlConnection(connstring1);
            if (connection1.State == ConnectionState.Closed)
            {
                try
                {

                    connection1.Open();

                    try
                    {

                        string query = "SELECT * FROM tShop";
                        SqlCommand cmd1 = new SqlCommand(query, connection1);
                        using (var cursor = cmd1.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                cmbShop .Items.Add(cursor["cName"]);
                            }
                        }
                        connection1.Close();
                        cmbShop.SelectedIndex = 0;
                    }

                    catch (Exception e2)
                    {
                        Console.WriteLine(e2);
                    }


                }
                catch (Exception ex)
                {

                }
            }
        }

                private void Form1_Load(object sender, EventArgs e)
        {
            getPossibleShops();
            txtTweet_counter.Text = Properties.Settings.Default.max_tweets_per_hour;
            lblCounter.Text = Properties.Settings.Default.tweets_wait_timeout;

            txtOffsetStart.Text = Properties.Settings.Default.db_tweet_offset;
            txtNextItems.Text =  Properties.Settings.Default.tweet_timeout; 
            txtTwitterAdditional.Text  = Properties.Settings.Default.strTweetMessage;        

            if (Properties.Settings.Default.datenbank_server.Length > 0)
            {

                string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer + "; password=" + Properties.Settings.Default.datenbank_pwd, Properties.Settings.Default.datenbank_datenbank );

                SqlConnection connection1 = new SqlConnection(connstring1);
                if (connection1.State == ConnectionState.Closed)
                {
                    try
                    {

                        connection1.Open();

                        try
                        {

                            string query = "SELECT * FROM tSpracheUsed";
                            SqlCommand cmd1 = new SqlCommand(query, connection1);
                            using (var cursor = cmd1.ExecuteReader())
                            {
                                while (cursor.Read())
                                {
                                    cmbSprache.Items.Add(cursor["cNameDeu"]);
                                }
                            }
                            connection1.Close();
                            cmbSprache.SelectedIndex = 0;
                        }

                        catch (Exception e2)
                        {
                            Console.WriteLine(e2);
                        }


                    }
                    catch (Exception ex)
                    {

                        if (ex.Message.Contains("Die von der Anmeldung angeforderte ") == true)
                        {
                            MessageBox.Show("MSSQL Datenbankverbindung fehlgeschlagen.Bitte Datenbankeinstellungen öffnen.", "MSSQL Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }


            } else
            {
                MessageBox.Show("MSSQL Datenbankverbindung Anmeldung einrichten.Bitte gleich die Einstellungen -> Datenbankeinstellungen öffnen.", "MSSQL Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Form frmDatenbank = new frmDatenbank();
                frmDatenbank.Show();
            }

            if (Properties.Settings.Default.strDomain.Length == 0)
            {
                MessageBox.Show("JTL Shop Plugin nicht eingerichtet. Bitte Einstellungen -> JTL Shop Connector Plugin", "JTL Shop Plugin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form frmJTLShopPlugin = new frmJTLShopConnector();
                frmJTLShopPlugin.Show();
            }

            if (Properties.Settings.Default.ConsumerKey .Length == 0)
            {
                MessageBox.Show("Twitter API Verbindung nicht eingerichtet. Bitte Einstellungen -> Twitter API..", "Twitter API einrichten", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form frmTwitterSettings = new frmTwitterSettings ();
                frmTwitterSettings.Show();
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.strDomain.Length > 0)
            {
                string connstring = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
                MySqlConnection connection = new MySqlConnection(connstring);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                }

                try
                {
 
                    string strDomain = Properties.Settings.Default.strDomain;
                    timer1.Enabled = true;
                    new Task(() => TwitterBot_stream_keyword(txtKeyword.Text, strDomain, iadded )).Start();
                    
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);
                }
            } else
            {
                MessageBox.Show("Fehler keine Domain ausgewählt.");
                
            }

            
            //var user = await context.CreateFriendshipAsync("JoeMayo", true);

            //    if (user != null && user.Status != null)
            //        Console.WriteLine(
            //            "User Name: {0}, Status: {1}",
            //            user.Name,
            //            user.Status.Text);
        }

        static async Task getRateLimit(frmMain frm)
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


            var helpResponse =
               await
                   (from help in twitterCtx.Help
                    where help.Type == HelpType.RateLimits
                    select help)
                   .SingleOrDefaultAsync();

            string strMsg = "";
            if (helpResponse != null && helpResponse.RateLimits != null)
                foreach (var category in helpResponse.RateLimits)
                {
                    Console.WriteLine("\nCategory: {0}", category.Key);
                    strMsg += "\nCategory: " + category.Key;
                    foreach (var limit in category.Value)
                    {
                        Console.WriteLine(
                            "\n  Resource: {0}\n    Remaining: {1}\n    Reset: {2}\n    Limit: {3}",
                            limit.Resource, limit.Remaining, limit.Reset, limit.Limit);

                             strMsg += "\n  Resource: " + limit.Resource  + " \n    Remaining: "  + limit.Remaining + "\n    Reset: " + limit.Reset  + "\n    Limit: " + limit.Limit;
                            
                    }



                }

            frm.BeginInvoke(new Action(() => frm.setStatus(strMsg)));

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (Properties.Settings.Default.strDomain.Length > 0)
            {
                string connstring = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
                MySqlConnection connection = new MySqlConnection(connstring);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                }

                try
                {
                     
                     new Task(() => getRateLimit(this)).Start();
                     

                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);
                }
            }
            else
            {
                MessageBox.Show("Fehler keine Domain ausgewählt.");

            }
        }
    
       public string setLabel(int iadded)
        {
            lblCounter.Text = "" + iadded;
            return "true";
        }

        public string setStatus(string iadded)
        {
            textBox1.Text = "" + iadded;
            return "true";
        }
        public string setLVW(string strUID,string strSprache,string strCreated, int strFollower_count, int strFriends_count, int strListed_count, int strFav_count, string strMsgFetch, string strName, string strScreen_name, int status_count)
        {
            ListViewItem lvwData = new ListViewItem();

            lvwData.Text = strUID;
            lvwData.SubItems.Add(strSprache);
            lvwData.SubItems.Add(strCreated);
            lvwData.SubItems.Add("" + strFollower_count);
            lvwData.SubItems.Add("" + strFriends_count);
            lvwData.SubItems.Add("" + strListed_count);
            lvwData.SubItems.Add(strMsgFetch);
            lvwData.SubItems.Add(strName );
            lvwData.SubItems.Add(strScreen_name);

            lvwData.SubItems.Add("" + strFav_count);
            lvwData.SubItems.Add("" + status_count);
            listView1.Items.Add(lvwData);
            listView1.EnsureVisible(listView1.Items.Count -1);
            return "true";
        }
      async Task TwitterBot_stream_keyword(string strKeyword,string strDomain, int iadded)
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

            int count = 0;

            string[] strTweets = new string[2001];
            await
            (from strm in twitterCtx.Streaming
             where strm.Type == StreamingType.Filter &&
                 strm.Track == strKeyword 
             select strm)
            .StartAsync(async strm =>
            {

                try
                {
                  


                    if (strm.Content.Length > 0)
                    {

                        string JSONContent = "";
                        // Console.WriteLine(strm.Content + "\n");
                        JSONContent = strm.Content;
                        Console.WriteLine(strm.Content + "\r\n\r\n");
                        string strUser = "";
                        dynamic obj = JsonConvert.DeserializeObject(JSONContent);
                        UInt32 uid = obj.user.id;
                        string strUID = "" + uid;
                        string strSprache = obj.user.lang;
                        iadded = iadded + 1;

                        BeginInvoke(new Action(() => setLabel(iadded)));
 
                        try
                        {

                          

                            var user = await twitterCtx.CreateFriendshipAsync(uid, true);

                            if (user != null && user.Status != null)
                            {
                                //strCount = "" + iCount;
                                //string[] row = { strCount, substrings[0], substrings[1], substrings[2] };
                                //var listViewItem = new ListViewItem(row);
                                //listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(listViewItem)));
                                twitterCtx.CreateFavoriteAsync(user.Status.StatusID);

                                Console.WriteLine(
                                    "User Name: {0}, Status: {1}",
                                    user.Name,
                                    user.Status.Text);

                                string query = "";

                                query = "UPDATE twitter_accounts_fetched SET friend_request='Y' WHERE screen_name ='" + obj.user.screen_name + "'";

                                string connstring1 = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
                                MySqlConnection connection1 = new MySqlConnection(connstring1);

                                if (connection1.State == ConnectionState.Closed)
                                {
                                    connection1.Open();

                                }
                                MySqlCommand cmd2 = new MySqlCommand(query, connection1);
                                cmd2.ExecuteNonQueryAsync();

                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        try
                        {
                            strUser = obj.user.name;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }


                        string text = "";
                        try
                        {

                            text = obj.text;
                            text = text.Replace("'", "");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        int listed = 0;
                        try
                        {
                            listed = obj.user.listed_count;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string beschreibung = "";
                        try
                        {
                            beschreibung = obj.user.description;
                            //beschreibung = beschreibung.Replace("'", "");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        int favourites = 0;
                        try
                        {
                            favourites = obj.user.favourites_count;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        int status = 0;
                        try
                        {
                            status = obj.user.statuses_count;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        int follower = 0;
                        try
                        {
                            follower = obj.user.followers_count;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        int friends = 0;
                        try
                        {
                            friends = obj.user.friends_count;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        string url = "";
                        try
                        {
                            url = obj.user.url;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string id = "";
                        try
                        {
                            id = obj.user.id;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string lang = "";
                        try
                        {
                            lang = obj.user.lang;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        string created_at = "";
                        try
                        {
                            created_at = obj.user.created_at;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string screen_name = "";
                        try
                        {
                            screen_name = obj.user.screen_name;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string location = "";
                        try
                        {
                            location = obj.user.location;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        string verified = "";
                        try
                        {
                            verified = obj.user.verified;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        BeginInvoke(new Action(() => setLVW(strUID, strSprache, created_at, follower, friends, listed, favourites,text, strUser, screen_name, status)));

                        //obj.user.followers_count + "', '" + obj.user.friends_count + "', '" + obj.user.listed_count + "', '" + obj.user.favourites_count + "', '" + obj.user.statuses_count + "'"
                        Console.WriteLine(favourites + "', '" + status);
                        Console.WriteLine(id + "', '" + text + "', '" + lang + "', '" + created_at + "','" + beschreibung + "','" + url + "','" + strUser + "','" + screen_name + "','" + location + "','" + verified + "','" + strKeyword + ", " + follower + ", " + friends);

                        string connstring = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
                        MySqlConnection connection = new MySqlConnection(connstring);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();

                        }

                        try
                        {

                            string query = "INSERT INTO twitter_accounts_fetched(id,text,lang,followers_count,friends_count,listed_count,favourites_count,statuses_count,created_at,description,url,name,screen_name,location,verified,event_keyword,event_domain) VALUES('" + id + "','" + text + "','" + lang + "','" + follower + "','" + friends + "','" + listed + "','" + favourites + "','" + status + "','" + created_at + "','" + beschreibung + "','" + obj.user.url + "','" + strUser + "','" + screen_name + "','" + location + "','" + verified + "','" + strKeyword + "','" + strDomain + "')";
                            MySqlCommand cmd1 = new MySqlCommand(query, connection);
                            cmd1.ExecuteNonQueryAsync();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        if (count++ >= 2000)
                            strm.CloseStream();
                    }
                    } catch (Exception e)
               
                {
                    Console.WriteLine(e);
                }
            
            });

            //int iCount = 0;
            //for (iCount = 0; iCount < strTweets.Length; iCount++)
            //{

            //    //clsTwitterJSON tw = new clsTwitterJSON();

            //    //clsTwitterJSON  account = JsonConvert.DeserializeObject<clsTwitterJSON>(strTweets[iCount]);

            //    dynamic obj = JsonConvert.DeserializeObject(strTweets[0]);
            //    Console.WriteLine(obj.user.id + " - " + obj.user.name + " (" + obj.user.lang  + ")");

            //    string connstring = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
            //    MySqlConnection connection = new MySqlConnection(connstring);
            //    if (connection.State == ConnectionState.Closed)
            //    {
            //        connection.Open();

            //    }

            //    try
            //    {
            //        string text;
            //        text = obj.text;
            //        text = text.Replace("'", "");
            //        string beschreibung;
            //        beschreibung = obj.user.description;
            //        beschreibung = beschreibung.Replace("'", "");

            //        string query = "INSERT INTO twitter_accounts_fetched(id,text,lang,followers_count,friends_count,listed_count,favourites_count,statuses_count,created_at,description,url,name,screen_name,location,verified,event_keyword) VALUES('" + obj.user.id + "','" + text + "','" + obj.user.lang + "','" + obj.user.followers_count + "','" + obj.user.friends_count + "','" + obj.user.listed_count + "','" + obj.user.favourites_count + "','" + obj.user.statuses_count + "','" + obj.user.created_at + "','" + beschreibung + "','" + obj.user.url + "','" + obj.user.name + "','" + obj.user.screen_name + "','" + obj.user.location + "','" + obj.user.verified + "','" + strKeyword + "')";
            //        MySqlCommand cmd1 = new MySqlCommand(query, connection);
            //        cmd1.ExecuteNonQuery();
            //    }
            //    catch (Exception e)
            //    {

            //    }
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCounter.Text = "" + iadded;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Task(() => RunCommand()).Start();
        }

        private void RunCommand()
        {
            var host = "bludau-media.de";
            var username = "";
            var password = "";

            using (var client = new SshClient(host, username, password))
            {
                client.Connect();
                // If the command2 depend on an environment modified by command1,
                // execute them like this.
                // If not, use separate CreateCommand calls.
                var cmd = client.CreateCommand("cd /var/www/vhosts/bludau-media.de/twitter-bot.bludau-media.de;ls -al;node app3.js");

                var result = cmd.BeginExecute();

                using (var reader =
                           new StreamReader(cmd.OutputStream, Encoding.UTF8, true, 1024, true))
                {
                    int iCount = 0;
                    string strCount = "";

                    while (!result.IsCompleted || !reader.EndOfStream)
                    {
                        iCount++;
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            textBox1.Invoke(
                                (MethodInvoker)(() =>
                                    textBox1.AppendText(line + Environment.NewLine)));
                            Char delimiter = '~';
                            String[] substrings = line.Split(delimiter);
                            try
                            {
                                string connstring = string.Format("Server=bludau-media.de; database={0}; UID=twitter; password=Viu!c017", "admin_twitter");
                                MySqlConnection connection = new MySqlConnection(connstring);
                                if (connection.State == ConnectionState.Closed)
                                {
                                    connection.Open();

                                }
                                //suppose col0 and col1 are defined as VARCHAR in the DB
                                string query = "INSERT INTO twitter_accounts_fetched( id  , lang, followers_count , friends_count , listed_count , favourites_count , statuses_count , created_at , description, url, name, screen_name, location, verified,stream_events_keywords) VALUES('" + substrings[0] + "','" + substrings[2] + "','" + substrings[3] + "','" + substrings[4] + "','" + substrings[5] + "','" + substrings[6] + "','" + substrings[7] + "','" + substrings[8] + "','" + substrings[9] + "','" + substrings[10] + "','" + substrings[11] + "','" + substrings[12] + "','" + substrings[13] + "','" + substrings[14] + "','" + txtKeyword.Text + "')";
                                MySqlCommand cmd1 = new MySqlCommand(query, connection);
                                cmd1.ExecuteNonQuery();



                                strCount = "" + iCount;
                                string[] row = { strCount, substrings[0], substrings[1], substrings[2] };
                                var listViewItem = new ListViewItem(row);
                                listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(listViewItem)));

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("{0} Second exception caught.", e);
                            }


                        }
                    }
                }

                cmd.EndExecute(result);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //declare new SaveFileDialog + set it's initial properties
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Exportverzeichnis auswählen",
                FileName = "twitter-bot_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "___" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".csv",
                Filter = "CSV (*.csv)|*.csv",
                FilterIndex = 0,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            //show the dialog + display the results in a msgbox unless cancelled

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                string[] headers = listView1.Columns
                           .OfType<ColumnHeader>()
                           .Select(header => header.Text.Trim())
                           .ToArray();

                string[][] items = listView1.Items
                            .OfType<ListViewItem>()
                            .Select(lvi => lvi.SubItems
                                .OfType<ListViewItem.ListViewSubItem>()
                                .Select(si => si.Text).ToArray()).ToArray();

                string table = string.Join("~", headers) + Environment.NewLine;
                foreach (string[] a in items)
                {
                    //a = a_loopVariable;
                    table += string.Join("~", a) + Environment.NewLine;
                }
                table = table.TrimEnd('\r', '\n');
                System.IO.File.WriteAllText(sfd.FileName, table);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(btnJTLWawiReadIn.Text == "Stoppen")
            {
                bStop_tweeting = true;
                btnJTLWawiReadIn.Text = "JTL Wawi Artikel laden &per Twitter API Posten";
                timer2.Enabled = false;
                tmrStatus.Enabled = false;

            } else
            {
                btnJTLWawiReadIn.Text = "Stoppen";
                bStop_tweeting = false;
                if (chkAutoModus.Checked == true)
                {
                    timer2.Enabled = true;
                    tmrStatus.Enabled = true;
                }
                else
                {
                    getJTLWawiArtikellisteAsync();
                }
            }
        }

        private void cmbSprache_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SelektierteSprache = getJTLWawiLanguageIDbyName(cmbSprache.Text );
                Properties.Settings.Default.Save();
            lblkSprache.Text = Properties.Settings.Default.SelektierteSprache;
        }

        string getJTLWawiLanguageIDbyName(string strSprache)
        {

            string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server  + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer + "; password=" + Properties.Settings.Default.datenbank_pwd , Properties.Settings.Default.datenbank_datenbank );
            SqlConnection connection1 = new SqlConnection(connstring1);
            if (connection1.State == ConnectionState.Closed)
            {
                connection1.Open();

            }

            try
            {

                string query = "SELECT * FROM tSpracheUsed WHERE cNameDeu='" + strSprache + "'";
                SqlCommand cmd1 = new SqlCommand(query, connection1);
                using (var cursor = cmd1.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        Properties.Settings.Default.SelektierteSprache = "" + cursor["kSprache"];
                        Properties.Settings.Default.Save();
                    }
                }
                connection1.Close();
                //cmbSprache.SelectedIndex = 0;
            }

            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
            return Properties.Settings.Default.SelektierteSprache;
        }

        private async void timer2_Tick_1(object sender, EventArgs e)
        {
            getJTLWawiArtikellisteAsync();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (txtTweet_counter.Text == "0")
            {
                btnJTLWawiReadIn.PerformClick();
                txtTweet_counter.Text = "450";
                tmrTweeter_waiter.Enabled = false;
            } else
            {
                tmrTweeter_waiter.Enabled = false;
            }

        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            lblCounter.Text = "" + (Convert.ToInt64 (lblCounter.Text) - 1);
        }

        private void txtTweet_counter_TextChanged(object sender, EventArgs e)
        {
            int valueParsed;
            try
            {

                if (Int32.TryParse(txtTweet_counter.Text.Trim(), out valueParsed))
                {
                    Properties.Settings.Default.max_tweets_per_hour = txtTweet_counter.Text;
                    Properties.Settings.Default.Save();
                }
            } catch(Exception e2)
            {
                Console.WriteLine(e2);
            }
        }

        private void beendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void jTLWawiDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDatenbank = new frmDatenbank();
            frmDatenbank.Show();
        }

        private void jTLShopConnectorPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmJTLShopConnector = new frmJTLShopConnector();
            frmJTLShopConnector.Show();

        }

        private void twitterAPIEinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmTwitterSettings = new frmTwitterSettings();
            frmTwitterSettings.Show();

        }

        private void btnTweetListe_Click(object sender, EventArgs e)
        {
            getJTLWawiArtikellisteAsync();
        }

        private void txtTwitterAdditional_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.strTweetMessage = txtTwitterAdditional.Text;
            Properties.Settings.Default.Save();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private async  void timer2_Tick_2(object sender, EventArgs e)
        {
            await getJTLWawiArtikellisteAsync();
        }

        private void bludauMediaWebseiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmbShop_SelectedIndexChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.kShop = GetPossibleShopID(cmbShop);
            Properties.Settings.Default.Save();
            lblkShop.Text = Properties.Settings.Default.kShop.ToString();

        }
        private int GetPossibleShopID(ComboBox cmb)
        {

            string connstring1 = string.Format("Server=" + Properties.Settings.Default.datenbank_server + "; database={0}; UID=" + Properties.Settings.Default.datenbank_benutzer + "; password=" + Properties.Settings.Default.datenbank_pwd, Properties.Settings.Default.datenbank_datenbank);
            SqlConnection connection = new SqlConnection(connstring1);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();

            }

            try
            {
                string query = "SELECT * FROM tShop WHERE cName='" + cmb.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query, connection);
                using (var cursor = cmd1.ExecuteReader())
                { 
                    while (cursor.Read())
                    {
                        if (bStop_tweeting == true)
                        {
                            bStop_tweeting = false;
                            break;

                        }
                        
                        return Convert.ToInt16(cursor["kShop"].ToString());                        
                    }
                }
                return -1;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                return -1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TwitterBot_stream_keyword(txtKeyword2.Text, "freie-welt.eu", 0);
        }
        //     Console.WriteLine("{0} - {1}:\n{2}\n\n", obj.from_user_name,
        //                                              (DateTime)obj.created_at,
        //                                              obj.text);

    }
}

