using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RetailIQAnalytics.UI
{
    partial class ExecutiveDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar
        private Panel panelSidebar;
        private Button btnDashboard;
        private Button btnUsers;
        private Button btnProducts;
        private Button btnCategories;
        private Button btnInventoryTransactions;

        // KPI cards
        private Panel panelKPIs;
        private Label lblTotalProducts;
        private Label lblTotalStock;
        private Label lblTotalValue;
        private Label lblAvgStock;
        private Label lblLowStock;
        private Label lblHighestProduct;

        // Charts
        private Chart chartStock;
        private Chart chartTrend;
        private Chart chartCategory;
        private Chart chartRisk;
        private Label lblHighestValueProduct;
        private PictureBox pictureBox8;




        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 8D);
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureSearchIcon = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnInventoryTransactions = new System.Windows.Forms.Button();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblAvgStock = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblHighestProduct = new System.Windows.Forms.Label();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRisk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblHighestValueProduct = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchIcon)).BeginInit();
            this.panelKPIs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.SteelBlue;
            this.panelSidebar.Controls.Add(this.pictureBox4);
            this.panelSidebar.Controls.Add(this.pictureBox3);
            this.panelSidebar.Controls.Add(this.pictureBox2);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Controls.Add(this.pictureSearchIcon);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Controls.Add(this.btnProducts);
            this.panelSidebar.Controls.Add(this.btnCategories);
            this.panelSidebar.Controls.Add(this.btnInventoryTransactions);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 100);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(241, 683);
            this.panelSidebar.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::RetailIQAnalytics.Properties.Resources.icons8_user_40;
            this.pictureBox4.Location = new System.Drawing.Point(3, 120);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RetailIQAnalytics.Properties.Resources.icons8_product_40;
            this.pictureBox3.Location = new System.Drawing.Point(3, 208);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RetailIQAnalytics.Properties.Resources.icons8_categories_40;
            this.pictureBox2.Location = new System.Drawing.Point(3, 298);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RetailIQAnalytics.Properties.Resources.icons8_in_inventory_40;
            this.pictureBox1.Location = new System.Drawing.Point(3, 395);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureSearchIcon
            // 
            this.pictureSearchIcon.Image = global::RetailIQAnalytics.Properties.Resources.icons8_dashboard_40;
            this.pictureSearchIcon.Location = new System.Drawing.Point(3, 41);
            this.pictureSearchIcon.Name = "pictureSearchIcon";
            this.pictureSearchIcon.Size = new System.Drawing.Size(40, 40);
            this.pictureSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSearchIcon.TabIndex = 12;
            this.pictureSearchIcon.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(49, 41);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 52);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            // 
            // btnUsers
            // 
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(49, 120);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(180, 55);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            // 
            // btnProducts
            // 
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(49, 208);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(180, 54);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Products";
            // 
            // btnCategories
            // 
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Location = new System.Drawing.Point(49, 298);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(180, 59);
            this.btnCategories.TabIndex = 3;
            this.btnCategories.Text = "Categories";
            // 
            // btnInventoryTransactions
            // 
            this.btnInventoryTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryTransactions.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryTransactions.ForeColor = System.Drawing.Color.White;
            this.btnInventoryTransactions.Location = new System.Drawing.Point(49, 395);
            this.btnInventoryTransactions.Name = "btnInventoryTransactions";
            this.btnInventoryTransactions.Size = new System.Drawing.Size(180, 63);
            this.btnInventoryTransactions.TabIndex = 4;
            this.btnInventoryTransactions.Text = "Inventory Transactions";
            // 
            // panelKPIs
            // 
            this.panelKPIs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelKPIs.Controls.Add(this.lblTitle);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 0);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Padding = new System.Windows.Forms.Padding(10);
            this.panelKPIs.Size = new System.Drawing.Size(1510, 100);
            this.panelKPIs.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(638, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Welcome, Admin";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.BackColor = System.Drawing.Color.LimeGreen;
            this.lblTotalProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalProducts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProducts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalProducts.Location = new System.Drawing.Point(258, 122);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(221, 103);
            this.lblTotalProducts.TabIndex = 2;
            this.lblTotalProducts.Text = "Total Products: 0";
            this.lblTotalProducts.Click += new System.EventHandler(this.lblTotalProducts_Click);
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.BackColor = System.Drawing.Color.Blue;
            this.lblTotalStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalStock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalStock.Location = new System.Drawing.Point(745, 122);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(215, 103);
            this.lblTotalStock.TabIndex = 3;
            this.lblTotalStock.Text = "Total Stock: 0";
            this.lblTotalStock.Click += new System.EventHandler(this.lblTotalStock_Click);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.BackColor = System.Drawing.Color.Yellow;
            this.lblTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalValue.Location = new System.Drawing.Point(258, 262);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(409, 86);
            this.lblTotalValue.TabIndex = 4;
            this.lblTotalValue.Text = "Inventory Value: Rs 0";
            // 
            // lblAvgStock
            // 
            this.lblAvgStock.BackColor = System.Drawing.Color.Orange;
            this.lblAvgStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAvgStock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgStock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAvgStock.Location = new System.Drawing.Point(976, 122);
            this.lblAvgStock.Name = "lblAvgStock";
            this.lblAvgStock.Size = new System.Drawing.Size(198, 103);
            this.lblAvgStock.TabIndex = 5;
            this.lblAvgStock.Text = "Avg Stock: 0";
            // 
            // lblLowStock
            // 
            this.lblLowStock.BackColor = System.Drawing.Color.Red;
            this.lblLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowStock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLowStock.Location = new System.Drawing.Point(495, 122);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(233, 103);
            this.lblLowStock.TabIndex = 6;
            this.lblLowStock.Text = "Low Stock: 0";
            // 
            // lblHighestProduct
            // 
            this.lblHighestProduct.Location = new System.Drawing.Point(0, 0);
            this.lblHighestProduct.Name = "lblHighestProduct";
            this.lblHighestProduct.Size = new System.Drawing.Size(100, 23);
            this.lblHighestProduct.TabIndex = 10;
            // 
            // chartStock
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea1);
            this.chartStock.Location = new System.Drawing.Point(257, 394);
            this.chartStock.Name = "chartStock";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Name = "Stock";
            dataPoint1.AxisLabel = "Product A";
            dataPoint2.AxisLabel = "Product B";
            dataPoint3.AxisLabel = "Product C";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            this.chartStock.Series.Add(series1);
            this.chartStock.Size = new System.Drawing.Size(400, 250);
            this.chartStock.TabIndex = 8;
            title1.Name = "Title1";
            title1.Text = "Stock by Product";
            this.chartStock.Titles.Add(title1);
            // 
            // chartTrend
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTrend.ChartAreas.Add(chartArea2);
            this.chartTrend.Location = new System.Drawing.Point(1079, 398);
            this.chartTrend.Name = "chartTrend";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Trend";
            dataPoint4.AxisLabel = "Jan";
            dataPoint5.AxisLabel = "Feb";
            dataPoint6.AxisLabel = "Mar";
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chartTrend.Series.Add(series2);
            this.chartTrend.Size = new System.Drawing.Size(400, 250);
            this.chartTrend.TabIndex = 9;
            title2.Name = "Title1";
            title2.Text = "Stock Trend Over Time";
            this.chartTrend.Titles.Add(title2);
            // 
            // chartCategory
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCategory.ChartAreas.Add(chartArea3);
            this.chartCategory.Location = new System.Drawing.Point(673, 521);
            this.chartCategory.Name = "chartCategory";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Name = "Category";
            dataPoint7.AxisLabel = "Category A";
            dataPoint8.AxisLabel = "Category B";
            dataPoint9.AxisLabel = "Category C";
            series3.Points.Add(dataPoint7);
            series3.Points.Add(dataPoint8);
            series3.Points.Add(dataPoint9);
            this.chartCategory.Series.Add(series3);
            this.chartCategory.Size = new System.Drawing.Size(400, 250);
            this.chartCategory.TabIndex = 10;
            title3.Name = "Title1";
            title3.Text = "Stock by Category";
            this.chartCategory.Titles.Add(title3);
            // 
            // chartRisk
            // 
            chartArea4.Name = "ChartArea1";
            this.chartRisk.ChartAreas.Add(chartArea4);
            this.chartRisk.Location = new System.Drawing.Point(681, 262);
            this.chartRisk.Name = "chartRisk";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Risk";
            dataPoint10.AxisLabel = "Product A";
            dataPoint11.AxisLabel = "Product B";
            dataPoint12.AxisLabel = "Product C";
            series4.Points.Add(dataPoint10);
            series4.Points.Add(dataPoint11);
            series4.Points.Add(dataPoint12);
            this.chartRisk.Series.Add(series4);
            this.chartRisk.Size = new System.Drawing.Size(400, 250);
            this.chartRisk.TabIndex = 11;
            title4.Name = "Title1";
            title4.Text = "Low Stock Risk";
            this.chartRisk.Titles.Add(title4);
            // 
            // lblHighestValueProduct
            // 
            this.lblHighestValueProduct.BackColor = System.Drawing.Color.Gray;
            this.lblHighestValueProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighestValueProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestValueProduct.ForeColor = System.Drawing.Color.Black;
            this.lblHighestValueProduct.Location = new System.Drawing.Point(1191, 122);
            this.lblHighestValueProduct.Name = "lblHighestValueProduct";
            this.lblHighestValueProduct.Size = new System.Drawing.Size(374, 103);
            this.lblHighestValueProduct.TabIndex = 24;
            this.lblHighestValueProduct.Text = "Highest Value Product: None";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::RetailIQAnalytics.Properties.Resources.icons8_stock_40;
            this.pictureBox7.Location = new System.Drawing.Point(807, 160);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(53, 53);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 18;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::RetailIQAnalytics.Properties.Resources.icons8_low_price_40;
            this.pictureBox6.Location = new System.Drawing.Point(564, 160);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(53, 53);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::RetailIQAnalytics.Properties.Resources.icons8_product_40;
            this.pictureBox5.Location = new System.Drawing.Point(337, 160);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(53, 53);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::RetailIQAnalytics.Properties.Resources.icons8_average_price_40;
            this.pictureBox8.Location = new System.Drawing.Point(1043, 160);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(53, 53);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 19;
            this.pictureBox8.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(807, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Low stock Risk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Stock by Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1164, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Stock Trend Over Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(771, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Stock by Category";
            // 
            // ExecutiveDashboardForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1510, 783);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lblHighestValueProduct);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.chartTrend);
            this.Controls.Add(this.lblTotalStock);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblAvgStock);
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.lblHighestProduct);
            this.Controls.Add(this.chartStock);
            this.Controls.Add(this.chartCategory);
            this.Controls.Add(this.chartRisk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExecutiveDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Executive Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchIcon)).EndInit();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureSearchIcon;
        private Label lblTitle;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
