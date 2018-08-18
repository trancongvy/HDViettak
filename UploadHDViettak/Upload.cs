using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDTLib;
using System.IO;
using System.Data.SqlClient;
using System.Xml.Serialization;
using hddtviettak.api;
using ViettakInv;
using Newtonsoft;
using Newtonsoft.Json;
namespace UploadHDViettak
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }
        string connection;
        string url;
        string user;
        string pass;
        DataTable dtInvoices;
        DataTable dtDetails;
        Database db;
        Inv[] invoices;
        string sData="";
        private string BuildData1HD(string MT32ID)
        {
            string Data = "";
            List<Inv> lInv = new List<Inv>();
            DataRow[] ldrMT = dtInvoices.Select("MT32ID='" + MT32ID + "'");
            if (ldrMT.Length == 0) return Data;
            DataRow drMT = ldrMT[0];

            Invoice invoice = new Invoice();
            invoice.ArisingDate = DateTime.Parse(drMT["NgayCT"].ToString());
            invoice.CusCode = drMT["MaKH"].ToString();
            invoice.CusName = drMT["TenKH"].ToString();
            invoice.CusTaxCode = drMT["MST"].ToString();
            invoice.CusAddress = drMT["DiaChi"].ToString();
            invoice.CusBankNo = drMT["TkNganHang"].ToString();
            invoice.CusBankName = drMT["NganHang"].ToString();
            invoice.CusPhone = drMT["SDT"].ToString();
            invoice.EmailDeliver = drMT["Email"].ToString();
            invoice.Buyer = drMT["Ongba"].ToString();
            invoice.SellBankNo = "";
            invoice.InvNote = drMT["Diengiai"].ToString(); ;
            invoice.PaymentMethod = drMT["TenHTTT"].ToString();
            invoice.Currency = drMT["MaNT"].ToString();
            invoice.ExRate = double.Parse(drMT["TyGia"].ToString());
            invoice.Amount = double.Parse(drMT["TTienH"].ToString());
            invoice.DiscountAmount = double.Parse(drMT["TCK"].ToString());
            if (drMT["MaThue"].ToString() == "KT") invoice.VATRate = 0;
            else invoice.VATRate = double.Parse(drMT["MaThue"].ToString());
            invoice.VATAmount = double.Parse(drMT["TThue"].ToString());
            invoice.Total = double.Parse(drMT["TTien"].ToString());
            invoice.AmountInWords = NumberReader.ReadMoney(double.Parse(drMT["TTien"].ToString()).ToString("###############0")) + "  đồng";
            DataRow[] ldrdt = dtDetails.Select("MT32ID='" + drMT["MT32ID"].ToString() + "'");
            List<Product> lpro = new List<Product>();
            for (int i = 0; i < ldrdt.Length; i++)
            {
                DataRow dr = ldrdt[i];
                Product pro = new Product();
                pro.No = i;
                pro.ProdCode = dr["MaVT"].ToString();
                pro.ProdName = dr["TenVT"].ToString();
                pro.ProdUnit = dr["TenDVT"].ToString();
                pro.ProdQuantity = double.Parse(dr["Soluong"].ToString());
                pro.ProdPrice = double.Parse(dr["Gia"].ToString());
                pro.Amount = double.Parse(dr["ps"].ToString());
                pro.ProdVat = double.Parse(dr["Thuesuat"].ToString());
                pro.ProdVATAmount = double.Parse(dr["thue"].ToString());
                pro.DiscountRate = double.Parse(dr["tileck"].ToString());
                pro.DiscountAmount = double.Parse(dr["ck"].ToString());
                if (double.Parse(dr["ps"].ToString()) == 0) pro.Promotion = 1;
                else pro.Promotion = 0;
                lpro.Add(pro);
            }
            invoice.Products = lpro.ToArray();
            Inv inv = new Inv();
            inv.key = drMT["MT32ID"].ToString();
            inv.Invoice = invoice;
            lInv.Add(inv);

            invoices = lInv.ToArray();
            StringWriter stringwriter = new System.IO.StringWriter();

            XmlSerializer serializer = new XmlSerializer(invoices.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // serializer.Serialize(stringwriter, invoices,ns);
            serializer.Serialize(stringwriter, invoices);

            string xmlInvData = stringwriter.ToString();
            string[] lines = xmlInvData.Split("\n".ToCharArray()).Skip(2).ToArray();
            Data = string.Join("\n", lines);
            Data = "<Invoices>\n" + Data.Replace("</ArrayOfInv>", "</Invoices>");
            return Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(NumberReader.ReadMoney("234244234"));
            if (checkBox1.Checked)
            {
                dtInvoices = db.GetDataTable("select * from wMT32 where status <1 or status is null");
                dtDetails = db.GetDataTable("select * from wDT32 where MT32ID in (select MT32ID from MT32 where status <1 or status is null)");
            }
            else
            {
                string query =" where (status=1)";
                if(tSohoadon.Text.Trim()!=string.Empty)
                {
                    query += " and sohoadon='" + tSohoadon.Text + "'";
                }
                if (dTungay.EditValue != null && dDenngay.EditValue != null)
                {
                    query += " and (ngayct between cast('" + dTungay.EditValue.ToString() + "' as datetime) and cast('" + dDenngay.EditValue.ToString() + "' as datetime))";
                }
                dtInvoices = db.GetDataTable("select * from wMT32 " + query);
                dtDetails = db.GetDataTable("select * from wDT32 where MT32ID in (select MT32ID from MT32 " + query + ")");
                
            }
            if (dtInvoices == null) return;
            gridControl1.DataSource = dtInvoices;
            gridControl2.DataSource = dtDetails;
           
            //sData = xmlInvData;
            //------------
            //StringReader strReader = null;

            //System.Xml.XmlTextReader xmlReader = null;
            //Object obj = null;
            //try
            //{
            //    strReader = new StringReader(sData);
            //    serializer = new XmlSerializer(invoices.GetType());
            //    xmlReader = new System.Xml.XmlTextReader(strReader);
            //    obj = serializer.Deserialize(xmlReader);
            //}
            //catch (Exception exp)
            //{
            //    //Handle Exception Code
            //}
        }

        private void Upload_Load(object sender, EventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt"))
            {
                fConfig f1 = new fConfig();
                f1.ShowDialog();
            }
            if (!GetInfo()) return;
            db = new Database(connection);
            if (db.Connection == null) return;
            
            
        }

        private bool GetInfo()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\LogInfo.txt");
                if (lines.Length != 4) return false;
                connection = Security.DeCode64(lines[0]);
                url = Security.DeCode64(lines[1]);
                user = Security.DeCode64(lines[2]);
                pass = Security.DeCode64(lines[3]);
                return true;
            }
            else return false;
        }
        string mauso = "01GTKT0/001";
        string kyhieu = "VT/18E";
        private void button2_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            int[] iSelect = gridView1.GetSelectedRows();
            foreach (int i in iSelect)
            {
                try
                {
                    ViettakInv.SyncInv sync = new SyncInv(user, pass, url, mauso, kyhieu);
                    string MT32ID=gridView1.GetDataRow(i)["MT32ID"].ToString();
                    if (MT32ID == string.Empty) continue;
                    if (!(gridView1.GetDataRow(i)["status"] == DBNull.Value || gridView1.GetDataRow(i)["status"].ToString() == "0")) continue;
                    sData = BuildData1HD(MT32ID);

                    string result = sync.AddInvoice(sData);
                    result = result.Replace("\n", "");
                    if (result.Contains("ERR"))
                    {
                    }
                    else if(result.Contains("OK"))
                    {
                        string sohoadon="";
                        Result r = JsonConvert.DeserializeObject<Result>(result);
                        if (r == null) continue;
                        string reString = r.result;
                        string[] lPara = reString.Split("_".ToCharArray());
                        if (lPara.Length != 2) continue;
                        sohoadon = "0000000".Substring(0,7-lPara[1].Length) + lPara[1];
                        string sql = "update MT32 set Status=1, sohoadon='" + sohoadon + "' where MT32ID='" + MT32ID + "'";
                        db.UpdateByNonQuery(sql);
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fConfig f1 = new fConfig();
            f1.ShowDialog();
        }
        //Delete
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ViettakInv.SyncInv sync = new SyncInv(user, pass, url, mauso, kyhieu);
                string result = sync.DeleteInvoice("0000061");
                result = result.Replace("\n", "");

            }
            catch (Exception ex) { }
        }
        //Edit
        private void button4_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) return;
            int[] iSelect = gridView1.GetSelectedRows();
            foreach (int i in iSelect)
            {
                try
                {
                    ViettakInv.SyncInv sync = new SyncInv(user, pass, url, mauso, kyhieu);
                    string MT32ID = gridView1.GetDataRow(i)["MT32ID"].ToString();
                    if (MT32ID == string.Empty) continue;
                    if (gridView1.GetDataRow(i)["status"] == DBNull.Value || gridView1.GetDataRow(i)["status"].ToString() == "0") continue;
                    sData = BuildData1HD(MT32ID);

                    string result = sync.EditInvoice(sData, gridView1.GetDataRow(i)["Sohoadon"].ToString());
                    result = result.Replace("\n", "");
                    if (result.Contains("ERR"))
                    {
                    }
                    else if (result.Contains("OK"))
                    {
                        string sohoadon = "";
                        Result r = JsonConvert.DeserializeObject<Result>(result);
                        if (r == null) continue;
                        string reString = r.result;
                        string[] lPara = reString.Split("_".ToCharArray());
                        if (lPara.Length != 2) continue;
                        sohoadon = "0000000".Substring(0, 7 - lPara[1].Length) + lPara[1];
                        string sql = "update MT32 set Status=1, sohoadon='" + sohoadon + "' where MT32ID='" + MT32ID + "'";
                        db.UpdateByNonQuery(sql);
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
