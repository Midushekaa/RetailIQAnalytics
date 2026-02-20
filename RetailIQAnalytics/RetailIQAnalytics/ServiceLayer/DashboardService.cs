using System.Data;
using RetailIQAnalytics.DataLayer;

namespace RetailIQAnalytics.ServiceLayer
{
    public class DashboardService
    {
        private DatabaseHelper dbHelper = new DatabaseHelper(); // Your DB helper class

        // ================= KPIs =================
        public DataTable LoadKPIs()
        {
            // Executes the stored procedure to get all executive KPIs
            return dbHelper.ExecuteProcedure("sp_GetExecutiveKPIs");
        }

        public DataTable LoadHighestValueProduct()
        {
            // Calls KPI SP and extracts only the highest value product
            DataTable dt = dbHelper.ExecuteProcedure("sp_GetExecutiveKPIs");

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("ProductName", typeof(string));

            if (dt.Rows.Count > 0)
            {
                dtResult.Rows.Add(dt.Rows[0]["HighestValueProduct"]);
            }

            return dtResult;
        }

        // ================= Stock Charts =================
        public DataTable LoadStockByProduct()
        {
            // Returns ProductName and StockQuantity for column chart
            return dbHelper.ExecuteProcedure("sp_StockByProduct");
        }

        // ================= Inventory Trend =================
        public DataTable LoadTrend()
        {
            // Returns inventory value change per month
            string query = @"
                SELECT 
                    DATENAME(MONTH, T.TransactionDate) AS Month,
                    SUM(T.QuantityChange * P.UnitPrice) AS ValueChange
                FROM InventoryTransactions T
                INNER JOIN Products P ON T.ProductID = P.ProductID
                GROUP BY DATENAME(MONTH, T.TransactionDate), MONTH(T.TransactionDate)
                ORDER BY MONTH(T.TransactionDate)";

            return dbHelper.ExecuteQuery(query);
        }

        // ================= Category Distribution =================
        public DataTable LoadCategoryDistribution()
        {
            // Returns stock distribution by category for pie chart
            return dbHelper.ExecuteProcedure("sp_CategoryDistribution");
        }

        // ================= Risk Analysis =================
        public DataTable LoadRiskAnalysis()
        {
            // Returns count of Low vs Healthy stock products for doughnut chart
            return dbHelper.ExecuteProcedure("sp_RiskAnalysis");
        }
    }
}
