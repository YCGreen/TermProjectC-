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
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = dataset.Tables["Date"];

                UpdateDataGridView();
              //  UpdateChart(dataset);

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

            private void UpdateDataGridView()
            {
             //   dgvData.Columns["volume"].DefaultCellStyle.Format = "#,###";
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
                    DateTime date = (DateTime)dataset.Tables["Date"].Rows[row].ItemArray[0];
                    double price = (double)dataset.Tables["Date"].Rows[row].ItemArray[1];
                    chartPL.Series[0].Points.AddXY(date, price);
                    if (price > maxPr) maxPr = price;
                    if (price < minPr) minPr = price;
                }
                chartPL.ChartAreas[0].AxisY.Maximum = Math.Ceiling(1.1 * maxPr);
                chartPL.ChartAreas[0].AxisY.Minimum = Math.Floor(0.9 * minPr);
            }

       
    }

    }
    
