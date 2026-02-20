using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RetailIQAnalytics.ServiceLayer;

namespace RetailIQAnalytics.UI
{
    public partial class ExecutiveDashboardForm : Form
    {
        private DashboardService service = new DashboardService();

        public ExecutiveDashboardForm()
        {
            InitializeComponent();

            // Wire up sidebar buttons
            btnDashboard.Click += BtnDashboard_Click;
            btnUsers.Click += BtnUsers_Click;
            btnProducts.Click += BtnProducts_Click;
            btnCategories.Click += BtnCategories_Click;
            btnInventoryTransactions.Click += BtnInventoryTransactions_Click;

            this.Load += ExecutiveDashboardForm_Load;
        }

        private void ExecutiveDashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // ================= LOAD DASHBOARD =================
        private void LoadDashboard()
        {
            LoadKPIs();
            LoadCharts();
            LoadRiskAnalysis();
        }

        // ================= KPI =================
        private void LoadKPIs()
        {
            try
            {
                DataTable dt = service.LoadKPIs();
                if (dt.Rows.Count == 0) return;

                lblTotalProducts.Text = "Total Products: " + dt.Rows[0]["TotalProducts"];
                lblTotalStock.Text = "Total Stock: " + dt.Rows[0]["TotalStock"];
                lblTotalValue.Text = "Inventory Value: Rs " + Convert.ToDecimal(dt.Rows[0]["TotalInventoryValue"]).ToString("N2");
                lblAvgStock.Text = "Avg Stock: " + dt.Rows[0]["AvgStockPerProduct"];
                lblHighestProduct.Text = "Highest Value Product: " + dt.Rows[0]["HighestValueProduct"];

                int lowStockCount = Convert.ToInt32(dt.Rows[0]["LowStockProducts"]);
                lblLowStock.Text = "Low Stock: " + lowStockCount;
                lblLowStock.ForeColor = lowStockCount > 0 ? Color.Black : Color.Green;

                // Highest Value Product
                var highestProduct = dt.Rows[0]["HighestValueProduct"];
                lblHighestValueProduct.Text = "Highest Value Product: " +
                    (highestProduct != DBNull.Value ? highestProduct.ToString() : "N/A");
                lblHighestValueProduct.ForeColor = Color.Black;
                lblHighestValueProduct.Font = new Font("Arial Rounded MT", 14, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPIs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CHARTS =================
        private void LoadCharts()
        {
            LoadStockChart();
            LoadTrendChart();
            LoadCategoryChart();
        }

        private void LoadStockChart()
        {
            chartStock.Series.Clear();
            chartStock.ChartAreas.Clear();
            chartStock.ChartAreas.Add(new ChartArea("MainArea"));
            chartStock.Series.Add("Stock");
            chartStock.Series["Stock"].ChartType = SeriesChartType.Column;

            DataTable dt = service.LoadStockByProduct();
            foreach (DataRow row in dt.Rows)
            {
                int stock = Convert.ToInt32(row["StockQuantity"]);
                int index = chartStock.Series["Stock"].Points.AddXY(row["ProductName"].ToString(), stock);
                chartStock.Series["Stock"].Points[index].Color = stock <= 10 ? Color.Red : Color.Green;
            }
        }

        private void LoadTrendChart()
        {
            chartTrend.Series.Clear();
            chartTrend.ChartAreas.Clear();
            chartTrend.ChartAreas.Add(new ChartArea("MainArea"));
            chartTrend.Series.Add("Trend");
            chartTrend.Series["Trend"].ChartType = SeriesChartType.Line;

            DataTable dt = service.LoadTrend();
            foreach (DataRow row in dt.Rows)
            {
                chartTrend.Series["Trend"].Points.AddXY(row["Month"].ToString(), row["ValueChange"]);
            }
        }

        private void LoadCategoryChart()
        {
            chartCategory.Series.Clear();
            chartCategory.ChartAreas.Clear();
            chartCategory.ChartAreas.Add(new ChartArea("MainArea"));
            chartCategory.Series.Add("Category");
            chartCategory.Series["Category"].ChartType = SeriesChartType.Pie;

            DataTable dt = service.LoadCategoryDistribution();
            foreach (DataRow row in dt.Rows)
            {
                int index = chartCategory.Series["Category"].Points.AddXY(row["CategoryName"].ToString(), Convert.ToInt32(row["TotalStock"]));
                chartCategory.Series["Category"].Points[index].Label = row["CategoryName"].ToString();
            }
        }

        // ================= RISK ANALYSIS =================
        private void LoadRiskAnalysis()
        {
            chartRisk.Series.Clear();
            chartRisk.ChartAreas.Clear();
            chartRisk.ChartAreas.Add(new ChartArea("MainArea"));
            chartRisk.Series.Add("Risk");
            chartRisk.Series["Risk"].ChartType = SeriesChartType.Doughnut;

            DataTable dt = service.LoadRiskAnalysis();
            foreach (DataRow row in dt.Rows)
            {
                int index = chartRisk.Series["Risk"].Points.AddXY(row["StockStatus"].ToString(), Convert.ToInt32(row["ProductCount"]));
                chartRisk.Series["Risk"].Points[index].Color = row["StockStatus"].ToString() == "Low" ? Color.Red : Color.Green;
                chartRisk.Series["Risk"].Points[index].Label = row["StockStatus"].ToString();
            }
        }
        private void lblTotalProducts_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }


        // ================= SIDEBAR BUTTONS =================
        private void BtnDashboard_Click(object sender, EventArgs e) => LoadDashboard();
        private void BtnUsers_Click(object sender, EventArgs e) { new UsersForm().ShowDialog(); }
        private void BtnProducts_Click(object sender, EventArgs e) { new ProductsForm().ShowDialog(); }
        private void BtnCategories_Click(object sender, EventArgs e) { new CategoriesForm().ShowDialog(); }
        private void BtnInventoryTransactions_Click(object sender, EventArgs e) { new InventoryTransactionsForm().ShowDialog(); }

        private void lblTotalStock_Click(object sender, EventArgs e) { }
    }
}
