using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;


namespace road
{
    public partial class Form1 : Form
    {

        public double _xInterval = 5;

        public Form1()
        {
            InitializeComponent();
            comboBoxInsert();
            limitcount_box.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private string filePath = "";
        private void open_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                filepath_Box.Clear();
                filepath_Box.Text = OFD.FileName;
                filePath = OFD.FileName;
            }
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            List<string> gid = new List<string>();
            List<string> ampid = new List<string>();
            List<string> dates = new List<string>();

            int addNum = 0;
            if (filePath != "")
            {
                string excel_sheet = ConfigurationManager.AppSettings["excel_Sheet"];

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(Filename: @filePath);
                Excel.Worksheet worksheet1 = (Excel.Worksheet)workbook.Worksheets.get_Item("excel_sheet");
                application.Visible = false;
                Excel.Range range = worksheet1.UsedRange;

                for (int i = 4; i <= range.Columns.Count; i++)
                {
                    string date = Convert.ToString(range.Cells[2, i].value);
                    for(int j = 0; j < date_combo.Items.Count; j++)
                    {
                        date_combo.Items[j].ToString();
                        if (date_combo.Items[j].ToString() == date)
                        {
                            addNum++;
                        }
                    }
                    dates.Add(date.Substring(0, 10));
                }

                string strConn = @"Server=localhost;Database=rodcell;Uid=root;Pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    string insertQuery = "";
                    for (int i = 4 + addNum; i < range.Columns.Count; ++i)
                    {
                        for (int j = 3; j <= range.Rows.Count; ++j)
                        {
                            insertQuery = string.Format("INSERT INTO roadcell(Group_ID, AMP_ID, Date_, Count) VALUES('{0}', '{1}', '{2}', '{3}')",
                                Convert.ToString(range.Cells[j, 2].value2), Convert.ToString(range.Cells[j, 3].value2), dates[i - 4], Convert.ToString(range.Cells[j, i].value2));
                            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
                DeleteObject(worksheet1);
                DeleteObject(workbook);
                application.Quit();
                DeleteObject(application);
                comboBoxInsert();
                MessageBox.Show("완료");
            }
        }

        private void DeleteObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("메모리 할당을 해제하는 중 문제가 발생하였습니다." + ex.ToString(), "경고!");
            }
            finally
            {
                GC.Collect();
            }
        }

        private void comboBoxInsert()
        {
            string strConn = @"Server=localhost;Database=rodcell;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string selectQuery = "SELECT DISTINCT Date_ FROM roadcell";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                date_combo.Items.Clear();
                while (rdr.Read())
                {
                    date_combo.Items.Add(rdr["Date_"]);
                }
                date_combo.SelectedIndex = 0;
                rdr.Close();
                conn.Close();
            }
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            ChartArea ca1 = this.mChart.ChartAreas[0];
            Series sr1 = this.mChart.Series[0];

            sr1.ChartType = SeriesChartType.Column;

            if (mChart.Series[0] != null)
            {
                mChart.Series.Clear();
            }
            string str_Con = ConfigurationManager.AppSettings["SDIP"];
            string strConn = @str_Con;
            int limitNum;
            int checkNum=0;
            if(limitcount_box.Text == "")
            {
                limitNum = 0;
            }
            else
            {
                limitNum = Convert.ToInt32(limitcount_box.Text);
            }

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                string date = date_combo.SelectedItem.ToString();
                mChart.Series.Add(date.Substring(0, 10));
                conn.Open();
                string selectQuery = string.Format("select Group_ID, AMP_ID, count from roadcell where Date_ = '{0}'", date.Substring(0,10));
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int check = (int)rdr["count"];
                    if(check > limitNum) {
                        string id = string.Format("{0}_{1}", rdr["Group_ID"], rdr["AMP_ID"]);
                        mChart.Series[0].Points.AddXY(id, rdr["count"]);
                        mChart.Series[0].Points[checkNum].ToolTip = id;
                        checkNum++;
                    }
                }
                rdr.Close();
                conn.Close();
            }

            //ca1.AxisX.ScrollBar.IsPositionedInside = false;
            //
            //ca1.AxisX.Minimum = _xInterval / 2d;
            ////ca1.AxisX.Maximum = sr1.Points.Count() * _xInterval + _xInterval / 2d;
            //
            //for (int i = 0; i < sr1.Points.Count; i++)
            //{
            //    DataPoint dp = sr1.Points[i]; // customLabel 위치 및 내용 지정
            //    ca1.AxisX.CustomLabels.Add((0.5d + i) * _xInterval, (1.5d + i) * _xInterval, dp.XValue.ToString()); 
            //}
            //
            //ca1.AxisX.MinorTickMark.Interval = _xInterval; 
            //ca1.AxisX.MinorTickMark.IntervalOffset = _xInterval / 2d; // minor tick mark 이동시킴 
            //
            //ca1.AxisX.MajorTickMark.IntervalOffset = _xInterval / 2d; // major tick mark 이동시킴
            //this.zoom_Check.Checked = true; // radiobutton 설정 초기화 
            //
            ////zoom 기능 활성화
            //ca1.AxisX.ScaleView.Zoomable = true; 
            //ca1.CursorX.IsUserEnabled = true; 
            //ca1.CursorX.IsUserSelectionEnabled = true; 
            //
            //this.mChart.ChartAreas[0].CursorX.Interval = _xInterval; // 커서 선택 단위를 막대그래프 한개씩 함.
            //this.mChart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = _xInterval; // scrollbar 버튼 누를때, 막대그래프 한개씩 이동시킴
            //this.mChart.ChartAreas[0].AxisX.IsMarginVisible = false; 
            //this.mChart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true; 
            //this.mChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;

        }

        private void limitcount_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        //private void mChart_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        //{
        //    if (this.mChart.ChartAreas[0].AxisX.ScaleView.ViewMinimum % _xInterval == 0)
        //    {
        //        this.mChart.ChartAreas[0].AxisX.ScaleView.Position -= _xInterval / 2d;
        //        this.mChart.ChartAreas[0].AxisX.ScaleView.Size += _xInterval;
        //    } 
        //}

        //private void zoom_Check_CheckedChanged(object sender, EventArgs e)
        //{
        //   if (zoom_Check.Checked) // Zoom checkbutton 선택된 경우.
        //   { 
        //       this.mChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true; 
        //       this.mChart.ChartAreas[0].CursorX.IsUserEnabled = true; 
        //       this.mChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true; 
        //   } 
        //   else 
        //   { 
        //       this.mChart.ChartAreas[0].AxisX.ScaleView.Zoomable = false; 
        //       this.mChart.ChartAreas[0].CursorX.IsUserEnabled = false; 
        //       this.mChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false; 
        //   }
        //}
    }
}
