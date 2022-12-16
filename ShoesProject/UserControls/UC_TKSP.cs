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
                data = DAO_TKSP.Instance.filterDate(month1, month2, int.Parse(txtYear1.Text.Trim()).ToString("0000"), int.Parse(txtYear2.Text.Trim()).ToString("0000"));

            ChartTable.DataSource = data;
            loadChart(data);
        }

        private void loadChart(DataTable data)
        {
            chart1.Series.Clear();
            chart1.Series.Add("TKSP");
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
            for (int i = 1; i <= 12; i++)
            {
                Array1.Add(i.ToString());
                Array2.Add(i.ToString());
            }
            txtMonthFrom.DataSource = Array1;
            txtMonthTo.DataSource = Array2;
        }

        private void txtMonthFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            month1 = txtMonthFrom.SelectedItem.ToString();
        }

        private void txtMonthTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            month2 = txtMonthTo.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMonthFrom.Text.Trim() == "" || txtMonthTo.Text.Trim() == "" || txtYear1.Text.Trim() == "" || txtYear2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng đầy đủ thông tin");
                return;
            }
            try
            {
                if (int.Parse(txtYear1.Text.Trim()) < 1900 || int.Parse(txtYear2.Text.Trim()) > 2078)
                {
                    MessageBox.Show("Vui lòng nhập năm trong khoảng 1900 đến năm 2078");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số năm hợp lệ");
                return;
            }
            if (int.Parse(txtYear1.Text) > int.Parse(txtYear2.Text))
            {
                MessageBox.Show("Vui lòng nhập năm thứ 1 bé hơn năm thứ 2");
                return;
            }
            loadTableChart(FilterDataAction);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadTableChart(getDataAction);
        }
    }
}
