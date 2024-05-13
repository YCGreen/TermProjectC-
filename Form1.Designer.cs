namespace Term_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonGD = new System.Windows.Forms.Button();
            this.dropdownSymbol = new System.Windows.Forms.ComboBox();
            this.chartPL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CumPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chartPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGD
            // 
            this.buttonGD.Location = new System.Drawing.Point(12, 12);
            this.buttonGD.Name = "buttonGD";
            this.buttonGD.Size = new System.Drawing.Size(82, 27);
            this.buttonGD.TabIndex = 0;
            this.buttonGD.Text = "buttonGD";
            this.buttonGD.UseVisualStyleBackColor = true;
            this.buttonGD.Click += new System.EventHandler(this.buttonGD_Click);
            // 
            // dropdownSymbol
            // 
            this.dropdownSymbol.FormattingEnabled = true;
            this.dropdownSymbol.Items.AddRange(new object[] {
            "DJI",
            "GSPC",
            "IBM",
            "TSLA",
            "AAPL",
            "GLD",
            "ZM",
            "VZ",
            "MSFT"});
            this.dropdownSymbol.Location = new System.Drawing.Point(182, 12);
            this.dropdownSymbol.Name = "dropdownSymbol";
            this.dropdownSymbol.Size = new System.Drawing.Size(89, 21);
            this.dropdownSymbol.TabIndex = 1;
            // 
            // chartPL
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPL.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPL.Legends.Add(legend1);
            this.chartPL.Location = new System.Drawing.Point(385, 74);
            this.chartPL.Name = "chartPL";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPL.Series.Add(series1);
            this.chartPL.Size = new System.Drawing.Size(363, 315);
            this.chartPL.TabIndex = 6;
            this.chartPL.Text = "chart1";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Quantity,
            this.Value,
            this.DailyPL,
            this.CumPL});
            this.dgvData.Location = new System.Drawing.Point(12, 74);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(355, 314);
            this.dgvData.TabIndex = 3;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // DailyPL
            // 
            this.DailyPL.HeaderText = "Daily P/L";
            this.DailyPL.Name = "DailyPL";
            this.DailyPL.ReadOnly = true;
            // 
            // CumPL
            // 
            this.CumPL.HeaderText = "Cum. P/L";
            this.CumPL.Name = "CumPL";
            this.CumPL.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.chartPL);
            this.Controls.Add(this.dropdownSymbol);
            this.Controls.Add(this.buttonGD);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGD;
        private System.Windows.Forms.ComboBox dropdownSymbol;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPL;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyPL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CumPL;
    }
}

