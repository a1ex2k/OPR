using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OPR
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        internal void Populate(List<Point> list)
        {
            dgr.Columns.Add("x1", "x1");
            dgr.Columns.Add("x2", "x2");
            dgr.Columns.Add("y", "y");
            dgr.Columns["x1"].DataPropertyName = "X1";
            dgr.Columns["x2"].DataPropertyName = "X2";
            dgr.Columns["y"].DataPropertyName = "Y";
            dgr.DataSource = list;
            dgr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        internal void Populate(GridBruteForce opt)
        {
            var x1 = opt.X1Array; var x2 = opt.X2Array; var res = opt.Result;

            dgr.ColumnCount = x1.Length;
            dgr.RowCount = x2.Length;
            for (int j = 0; j < x2.Length; j++)
            {
                if (x2[j] == res.X2) dgr.Rows[j].HeaderCell.Style.BackColor = SystemColors.Highlight;
                dgr.Rows[j].HeaderCell.Value = x2[j].ToString();
            }

            for (int i = 0; i < x1.Length; i++)
            {
                dgr.Columns[i].HeaderCell.Value = x1[i].ToString();
                if (x1[i] == res.X1) dgr.Columns[i].HeaderCell.Style.BackColor = SystemColors.Highlight;
                dgr.Columns[i].Width = 45;
                for (int j = 0; j < x2.Length; j++)
                {
                    dgr[i, j].Value = opt.Matrix[i, j];
                    if (opt.Input.CheckRestrictions(x1[i], x2[j]))
                        dgr[i, j].Style.BackColor = Color.LightGreen;
                }
            }
        }
    }
}

