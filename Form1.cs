using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Term_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SqlConnection sqlCon = null;

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
                sqlCon = new SqlConnection(strConnect);
                sqlCon.Open();

                /* set up a call to getTickers stored procedure */
                SqlCommand sqlCmdTicker = new SqlCommand("getTickers", sqlCon);
                sqlCmdTicker.CommandType = CommandType.StoredProcedure;

                /* execute getTickers */
                sqlCmdTicker.ExecuteNonQuery();

                /* get the data returned by getTickers and display it */
                SqlDataAdapter daT = new SqlDataAdapter(sqlCmdTicker);
                DataSet datasetTicker = new DataSet();
                daT.Fill(datasetTicker, "Ticker");

                String[] tickers = GetTickers(datasetTicker.Tables["Ticker"]);


                for (int i = 0; i < tickers.Length; i++)
                {
                    dropdownSymbol.Items.Add(tickers[i]);
                }

            }

            catch (Exception ex)

            {
                MessageBox.Show(" " + DateTime.Now.ToLongTimeString() + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally

            {

                if (sqlCon != null && sqlCon.State == System.Data.ConnectionState.Open)

                    sqlCon.Close();

            }
        }

        private void buttonGD_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = null;

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
                sqlCon = new SqlConnection(strConnect);
                sqlCon.Open();


                /* prepare parameters for stored procedure  called below */
                String symbol = dropdownSymbol.Text;

                /* set up a call to getDQVDC stored procedure */
                SqlCommand sqlCmd = new SqlCommand("getDQVDC", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@symbol", System.Data.SqlDbType.VarChar).Value = symbol;

                /* execute getDQVDC */
                sqlCmd.ExecuteNonQuery();

                /* get the data returned by getDQVDC and display it */
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet dataset = new DataSet();
                da.Fill(dataset, "Date");

                if (dataset.Tables["Date"] == null || dataset.Tables["Date"].Rows.Count == 0) 
                {
                    // The dataset is empty
                    MessageBox.Show("The dataset is empty.");
                }


                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = dataset.Tables["Date"];
                FillRows(dataset.Tables["Date"]);

                UpdateDataGridView();
                 UpdateChart(dataset);

            }

            catch (Exception ex)

            {
                MessageBox.Show(" " + DateTime.Now.ToLongTimeString() + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally

            {

                if (sqlCon != null && sqlCon.State == System.Data.ConnectionState.Open)

                    sqlCon.Close();

            }
        }

        private String[] GetTickers(DataTable dataTable)
        {
            String[] tickers = new String[dataTable.Rows.Count];

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                tickers[i] = dataTable.Rows[i][0].ToString();
            }

            return tickers;
        }

        private void UpdateDataGridView()
        {
            for (int cix = 0; cix < dgvData.Columns.Count; cix++)
            {
                dgvData.AutoResizeColumn(cix);
            }

            
        }
        private void UpdateChart(DataSet dataset)
        {
            chartPL.Series[0].Points.Clear();
            var nrRows = dataset.Tables["Date"].Rows.Count;
            double maxPr = Double.MinValue;
            double minPr = Double.MaxValue;
            for (int row = 1; row < nrRows; ++row)
            {
                String date = dataset.Tables["Date"].Rows[row][0].ToString();
                DateTime dateT;
                DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateT);
                double price = Convert.ToDouble(dataset.Tables["Date"].Rows[row][1]);
                chartPL.Series[0].Points.AddXY(dateT, price);
                if (Math.Abs(price) > maxPr) maxPr = price; //keep getting error on GSPC graph that
                if (price < minPr) minPr = price;
            }
            chartPL.ChartAreas[0].AxisY.Maximum = Math.Ceiling(1.1 * maxPr);
            chartPL.ChartAreas[0].AxisY.Minimum = Math.Floor(0.9 * minPr);
        }


        private void FillRows(DataTable dataTable)
        {
            int dgvrow = 0;

            Double cumpl = 0;

            for (int dtrow = 0; dtrow < dataTable.Rows.Count; dtrow++)
            {
                String date = dataTable.Rows[dtrow][0].ToString();
                String quantity = dataTable.Rows[dtrow][1].ToString();
                String value = dataTable.Rows[dtrow][2].ToString();
                Double dailypl = Convert.ToDouble(dataTable.Rows[dtrow][3]);
                
                cumpl += dailypl;

                String dailyplStr = dailypl.ToString("C");
                String cumplStr = cumpl.ToString("C");

                dgvData.Rows[dgvrow].Cells[0].Value = date;
                dgvData.Rows[dgvrow].Cells[1].Value = quantity;
                dgvData.Rows[dgvrow].Cells[2].Value = value;
                dgvData.Rows[dgvrow].Cells[3].Value = dailyplStr;
                dgvData.Rows[dgvrow].Cells[4].Value = cumplStr;

                dgvrow++; 

            }
        }
    }

}
    

