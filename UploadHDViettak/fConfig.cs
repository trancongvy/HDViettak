using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CDTLib;
namespace UploadHDViettak
{
    public partial class fConfig : Form
    {
        public fConfig()
        {
            InitializeComponent();
        }

        private void bGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt");
                string connection = "Server=" + tServer.Text + ";Database=" + tDatabase.Text + ";user =" + tUsersql.Text + ";pwd =" + tPasssql.Text;
                WriteInfo(Security.EnCode64(connection), Security.EnCode64(tUrl.Text), Security.EnCode64(tUser.Text), Security.EnCode64(tPass.Text));
                this.Dispose();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        //
        public void WriteInfo(string Connection, string url, string user, string pass)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt", true);
                sw.WriteLine(Connection);
                sw.WriteLine(url);
                sw.WriteLine(user);
                sw.WriteLine(pass);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }
    }
}
