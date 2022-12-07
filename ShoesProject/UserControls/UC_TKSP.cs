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
    public partial class UC_TKSP : UserControl
    {
        string getDataAction = "getDataAction";
        string FilterDataAction = "FilterDataAction";
        string year1 = "2022";
        string year2 = "2022";
        string month1 = "";
        string month2 = "";
        public UC_TKSP()
        {
            InitializeComponent();
        }

        private void UC_TKSP_Load(object sender, EventArgs e)
        {
            loadTableChart(getDataAction);
            comboboxMonth();
        }

        private void loadTableChart(string action)
        {
            DataTable data = new DataTable();
            if (action == getDataAction)
                data = DAO_TKSP.Instance.getChart();
            if (action == FilterDataAction)
                data = DAO_TKSP.Instance.filterDate(month1, month2, txtYear1.Text, txtYear2.Text);

            ChartTable.DataSource = data;
            loadChart(data);
        }

        private void loadChart(DataTable data)
        {
            //chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tên Sản Phẩm";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
            for( int i = 0; i < data.Rows.Count; i++)
            {
                chart1.Series["TKSP"].Points.AddXY(data.Rows[i][2], data.Rows[i][0]);
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
