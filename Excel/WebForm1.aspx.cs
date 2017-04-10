using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Excel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        DataTable DS;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            lblName.Text = lblName.Text + "<br/>" + "PreInit";
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            lblName.Text = lblName.Text + "<br/>" + "InitComplete";
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            lblName.Text = lblName.Text + "<br/>" + "Init";
        }

      

        protected override void OnPreLoad(EventArgs e)
        {
            //Work and It will assign the values to label.
            //If the page is post back, then label contrl values will be loaded from view state.
            //E.g: If you string str = lblName.Text, then str will contain viewstate values.
            lblName.Text = lblName.Text + "<br/>" + "PreLoad";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            finallyWorkingExcel();
           // 
            //    BindGv();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            lblName.Text = lblName.Text + "<br/>" + "btnSubmit_Click";
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            lblName.Text = lblName.Text + "<br/>" + "LoadComplete";
         //   Loop();
        }

        protected override void OnPreRender(EventArgs e)
        {
            asynctest();
           // OnPreRender(e);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            //Work and It will assign the values to label.
            //But "SaveStateComplete" values will not be available during post back. i.e. View state.
            lblName.Text = lblName.Text + "<br/>" + "SaveStateComplete";
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //Work and it will not effect label contrl, view stae and post back data.
            lblName.Text = lblName.Text + "<br/>" + "UnLoad";
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            // AutoResetEvent waiter = new AutoResetEvent(false);
            Response.Write("<script>alert('" + "Guzik klikniety" + "');</script>");
            
            //asynctest();
            //  Loop();
        }
    

        public async Task<bool> Run2(string pin)
        {
            Ping p = new Ping();
            AutoResetEvent waiter = new AutoResetEvent(false);
            string data = "aaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            byte[] buffer2 = { 32, 32 };
           
            if (pin == null)
            {
                return false;
            }
            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);
            try
            {
                Thread.CurrentThread.Name = "ping";
                IPStatus status = IPStatus.Success;
                //if (pin == null)
                //{
                //    return false;
                //}
                status = (await p.SendPingAsync(pin,1000,buffer)).Status;
                // status = await p.SendAsync(pin, 100, 300, are;
                if (status == IPStatus.Success)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                p.Dispose();
            }
            return false;
        }
      

        public async void asynctest()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < DS.Rows.Count -1; i++)
            {
               
                if(DS.Rows[i][1].ToString() == "0.0.0.0")
                {
                    continue; 
                }
                try
                {
                    bool result = await Run2(DS.Rows[i][1].ToString());
                    if (result)
                    {
                        DS.Rows[i][2] = "ok";
                    }
                    else
                    {
                        DS.Rows[i][2] = "not ok";

                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                }
              
            }
            stopwatch.Stop();

            Response.Write("<script>alert('" + "Zajeło to " + stopwatch.Elapsed + "');</script>");
            stopwatch.Reset();
             
        }

      

        public void finallyWorkingExcel()
        {
            string path = Server.MapPath("File/NAS.xlsx");
            string connstr = "Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
            String connstr2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                       path +
                       ";Extended Properties='Excel 8.0;HDR=YES;';";
            OleDbConnection conn = new OleDbConnection(connstr2);
            string strSQL = "SELECT * FROM [Arkusz1$]";
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DS = new DataTable();
            //DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(DS);
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            da.Dispose();        

            GridView1.DataSource = DS;
            GridView1.DataBind();
        }


        static int FreeTcpPort()
        {
           // IPAddress ip = new IPAddress(int.Parse(dr.ToString()));
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }



        public async Task<bool> Run(string pin)
        {
            Ping p = new Ping();
            AutoResetEvent waiter = new AutoResetEvent(false);
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            PingOptions options = new PingOptions(64, true);
            try
            {
                Thread.CurrentThread.Name = "ping";
                IPStatus status = IPStatus.Success;
                if (pin == null)
                {
                    return false;
                }
                    status = (await p.SendPingAsync(pin)).Status;
               // status = await p.SendAsync(pin, 100, 300, are;
                if (status == IPStatus.Success)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                p.Dispose();
            }
            return false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                    if ( drv[2].ToString().Equals("ok") )
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }
                    else if ( drv[2].ToString().Equals("not ok")) 
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
