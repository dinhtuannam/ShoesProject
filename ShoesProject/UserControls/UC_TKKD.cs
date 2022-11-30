using ShoesProject.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShoesProject.UserControls
{
    public partial class UC_TKKD : UserControl
    {
        string getDataAction = "getDataAction";
        string FilterDataAction = "FilterDataAction";
        string year1 = "2022";
        string year2 = "2022";
        string month1 = "";
        string month2 = "";
        public UC_TKKD()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_TKKD_Load(object sender, EventArgs e)
        {
            chart.Titles.Add("Tổng thu nhập của các loại sản phẩm ( đơn vị Dollar )");
            loadTableChart(getDataAction);
            comboboxMonth();
        }

        private void loadTableChart(string action)
        {
            DataTable data = new DataTable();
            if(action == getDataAction)
                data = DAO_TKKD.Instance.getChart();
            if (action == FilterDataAction)
                data = DAO_TKKD.Instance.filterDate(month1, month2, txtYear1.Text, txtYear2.Text);
            
            ChartTable.DataSource = data;
            loadChart(data);
        }

        private void loadChart(DataTable data)
        {
            chart.Series.Clear();
            chart.Series.Add("s1");
            chart.Series["s1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart.Series["s1"].IsValueShownAsLabel = true;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string[] money = data.Rows[i][1].ToString().Split('.');
                string name = data.Rows[i][2].ToString();
                chart.Series["s1"].Points.AddXY(name, money[0]);
            }

        }

        private void comboboxMonth()
        {
            List<string> Array1 = new List<string>();
            Array1.Add("");
            List<string> Array2 = new List<string>();
            Array2.Add("");
            for (int i = 0; i <= 12; i++)
            {
                Array1.Add(i.ToString());
                Array2.Add(i.ToString());
            }
            txtMonthFrom.DataSource = Array1;
            txtMonthTo.DataSource = Array2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadTableChart(FilterDataAction);
        }

        private void txtMonthTo_SelectedValueChanged(object sender, EventArgs e)
        {
            month2 = txtMonthTo.SelectedItem.ToString();
        }

        private void txtMonthFrom_SelectedValueChanged(object sender, EventArgs e)
        {
            month1 = txtMonthFrom.SelectedItem.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadTableChart(getDataAction);
        }
    }
}
