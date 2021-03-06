using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Client_Updater
{
    public partial class Form1 : MetroForm
    {
        private ClientUpdater updater;

        public Form1()
        {
            InitializeComponent();
            Load += (s, e) => Activate();
        }

        private void c453_btn_Click(object sender, EventArgs e) => runUpdater(textBoxDomain.Text);

        private void getLanguage(string id)
        {
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var contents = wc.UploadString("https://realmofthemadgodhrd.appspot.com/app/getLanguageStrings", "languageType=" + id);
                File.WriteAllText(id + ".txt", contents, Encoding.UTF8);
            }
        }

        private static class CurrentMillis
        {
            private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            /// <summary>Get extra long current timestamp</summary>
            public static long Millis { get { return (long)((DateTime.UtcNow - Jan1St1970).TotalMilliseconds); } }
        }

        private void runUpdater(string ip)
        {
            if (checkBoxDownloadClient.Checked)
            {
                labelStatus.Text = "Status: Downloading latest client...";
                labelStatus.Update();
                using (var webCli = new WebClient())
                {
                    var clientVersion = Encoding.UTF8.GetString(webCli.DownloadData($"http://www.realmofthemadgod.com/version.txt?time={CurrentMillis.Millis}"));
                    webCli.DownloadFile($"https://realmofthemadgodhrd.appspot.com/AssembleeGameClient{clientVersion}.swf", "client.swf");
                }
                getLanguage("de");
                getLanguage("en");
                getLanguage("es");
                getLanguage("fr");
                getLanguage("it");
                getLanguage("ru");
                getLanguage("tr");
            }

            updater = new ClientUpdater(ip, labelStatus);
            updater.UpdateClient();
        }
    }
}
