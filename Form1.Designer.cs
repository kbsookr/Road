
namespace road
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.limitcount_box = new System.Windows.Forms.TextBox();
            this.view_btn = new System.Windows.Forms.Button();
            this.date_combo = new System.Windows.Forms.ComboBox();
            this.insert_btn = new System.Windows.Forms.Button();
            this.open_btn = new System.Windows.Forms.Button();
            this.filepath_Box = new System.Windows.Forms.TextBox();
            this.mChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mChart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.limitcount_box);
            this.splitContainer1.Panel1.Controls.Add(this.view_btn);
            this.splitContainer1.Panel1.Controls.Add(this.date_combo);
            this.splitContainer1.Panel1.Controls.Add(this.insert_btn);
            this.splitContainer1.Panel1.Controls.Add(this.open_btn);
            this.splitContainer1.Panel1.Controls.Add(this.filepath_Box);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mChart);
            this.splitContainer1.Size = new System.Drawing.Size(764, 461);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 0;
            // 
            // limitcount_box
            // 
            this.limitcount_box.Location = new System.Drawing.Point(185, 39);
            this.limitcount_box.Name = "limitcount_box";
            this.limitcount_box.Size = new System.Drawing.Size(112, 21);
            this.limitcount_box.TabIndex = 10;
            this.limitcount_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.limitcount_box_KeyPress);
            // 
            // view_btn
            // 
            this.view_btn.Location = new System.Drawing.Point(303, 39);
            this.view_btn.Name = "view_btn";
            this.view_btn.Size = new System.Drawing.Size(90, 23);
            this.view_btn.TabIndex = 9;
            this.view_btn.Text = "확인";
            this.view_btn.UseVisualStyleBackColor = true;
            this.view_btn.Click += new System.EventHandler(this.view_btn_Click);
            // 
            // date_combo
            // 
            this.date_combo.FormattingEnabled = true;
            this.date_combo.Location = new System.Drawing.Point(12, 39);
            this.date_combo.Name = "date_combo";
            this.date_combo.Size = new System.Drawing.Size(167, 20);
            this.date_combo.TabIndex = 8;
            // 
            // insert_btn
            // 
            this.insert_btn.Location = new System.Drawing.Point(662, 12);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(90, 23);
            this.insert_btn.TabIndex = 7;
            this.insert_btn.Text = "확인";
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(567, 12);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(90, 23);
            this.open_btn.TabIndex = 6;
            this.open_btn.Text = "열기";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // filepath_Box
            // 
            this.filepath_Box.Location = new System.Drawing.Point(12, 12);
            this.filepath_Box.Name = "filepath_Box";
            this.filepath_Box.Size = new System.Drawing.Size(549, 21);
            this.filepath_Box.TabIndex = 5;
            // 
            // mChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mChart.ChartAreas.Add(chartArea1);
            this.mChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.mChart.Legends.Add(legend1);
            this.mChart.Location = new System.Drawing.Point(0, 0);
            this.mChart.Name = "mChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mChart.Series.Add(series1);
            this.mChart.Size = new System.Drawing.Size(764, 387);
            this.mChart.TabIndex = 0;
            this.mChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button view_btn;
        private System.Windows.Forms.ComboBox date_combo;
        private System.Windows.Forms.Button insert_btn;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.TextBox filepath_Box;
        private System.Windows.Forms.DataVisualization.Charting.Chart mChart;
        private System.Windows.Forms.TextBox limitcount_box;
    }
}

