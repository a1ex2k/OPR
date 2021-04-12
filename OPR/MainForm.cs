using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OPR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDefaults();
        }
        private void LoadDefaults()
        {
            signcomboBox.Items.AddRange(new object[] { "<", "<=", "==", ">=", ">" });
            criteriaComboBox.Items.AddRange(new object[] { "Минимум", "Максимум" });
            signcomboBox.SelectedIndex = 3;
            x1ltextBox.Text = "0";
            x1utextBox.Text = "10";
            x2ltextBox.Text = "-5";
            x2utextBox.Text = "5";
            par1TextBox.Text = "0.2";
            textBox4.Text = "0.2";
            par2TextBox.Text = "500";
            textBox1.Text = "0.0001";
            funcTextBox.Text = "(x1-2)^2+(x2-1)^2";
            textBox3.Text = "10";
            textBox2.Text = "3";
            limitsGridView.Rows.Add(); limitsGridView.Rows.Add();
            limitsGridView[0, 0].Value = "x1-2*x2+1"; limitsGridView[1, 0].Value = ">="; limitsGridView[2, 0].Value = "2";
            limitsGridView[0, 1].Value = "x1+4*x2"; limitsGridView[1, 1].Value = ">="; limitsGridView[2, 1].Value = "3";
            methodcomboBox.Items.AddRange(new object[] { "Прямого перебора по сетке", "Монте-Кaрло", "Хука-Дживса", "Штрафных Функций" });
            criteriaComboBox.SelectedIndex = methodcomboBox.SelectedIndex = 0;
        }
        private int EditingRowIndex = -1;
        private int method = 0;
        private Optimize.BasicData.Criteria crit;
        private TableForm TableForm;
        private string logstr = "";

        Optimize.BasicData PrepareValues()
        {
            Optimize.BasicData data = null;
            try
            {
                var func = new MathExpr(funcTextBox.Text);
                logstr += $"y={funcTextBox.Text}\u2192{criteriaComboBox.Text}";
                var restr = new MathExpr[limitsGridView.Rows.Count];
                for (int i = 0; i < limitsGridView.Rows.Count; i++)
                {
                    string expr = limitsGridView[0, i].Value.ToString() + limitsGridView[1, i].Value.ToString() + limitsGridView[2, i].Value.ToString();
                    logstr += ", " + expr;
                    restr[i] = new MathExpr(expr);
                }
                double x1min, x1max, x2min, x2max;
                x1min = Double.Parse(x1ltextBox.Text);
                x1max = Double.Parse(x1utextBox.Text);
                x2min = Double.Parse(x2ltextBox.Text);
                x2max = Double.Parse(x2utextBox.Text);
                Double.Parse(par1TextBox.Text);
                Double.Parse(textBox4.Text);
                Double.Parse(textBox3.Text);
                Double.Parse(textBox2.Text);
                uint.Parse(par2TextBox.Text);
                double par_eps = Double.Parse(textBox1.Text);

                var bounds = new Optimize.BasicData.VarBounds(x1min, x1max, x2min, x2max);
                logstr += " " + bounds;

                data = new Optimize.BasicData(func, crit, restr, bounds);
            }
            catch
            {
                MessageBox.Show("Не удалось обработать введённые данные. Процесс отменён.");
                logstr += "  -  Неудача!";
            }
            return data;
        }


        public void Run()
        {
            Optimize.BasicData data = PrepareValues();
            if (data == null) return;
            SetChartArea(data.Bounds);
            Plotting.Isolines(data).ForEach(s => chart.Series.Add(s));

            Optimize opt;
            switch (method)
            {
                case 0:
                    double par_step = Double.Parse(par1TextBox.Text);
                    double par_step2 = Double.Parse(textBox4.Text);
                    opt = new GridBruteForce(data, par_step);
                    logstr = $"{methodcomboBox.Text}, Шаг: {par_step} - " + logstr; break;
                case 1:
                    uint par_count = uint.Parse(par2TextBox.Text);
                    opt = new MonteCarlo(data, par_count);
                    logstr = $"{methodcomboBox.Text} - " + logstr; break;
                case 2:
                    double par_eps = Double.Parse(textBox1.Text);
                    Point startPoint = null;
                    if (enableStartPoint.Checked == true)
                    {
                        double x1_0 = Double.Parse(textBox3.Text);
                        double x2_0 = Double.Parse(textBox2.Text);
                        startPoint = new Point(x1_0, x2_0, data.Function.Calc(x1_0, x2_0));
                    }
                    par_step = Double.Parse(par1TextBox.Text);
                    par_step2 = Double.Parse(textBox4.Text);
                    opt = new HookeJeeves(data, par_eps, par_step, par_step2, startPoint);
                    logstr = $"{methodcomboBox.Text}, Точность: {par_eps} " + logstr; break;
                case 3: return; break;
                default: return; break;
            }

            try
            {
                opt.RunOptimization();
                resultlabel.Text = $"{opt.Result}\r\nДлительность: {opt.Duration} мс, {opt.Iterations} итер.";
                logstr = $"y({opt.Result.X1},{opt.Result.X2})={opt.Result.Y}, {opt.Duration} мс, {opt.Iterations} итер. - " + logstr;
                chart.Series.Add(Plotting.PlacePoint(opt.Result, Color.Crimson));

                TableForm = new TableForm();
                if (method == 2) chart.Series.Add(Plotting.PlacePoints(((HookeJeeves)opt).Points, "path", Color.Black, 3, MarkerStyle.Star5, SeriesChartType.Line));
                Parallel.Invoke(() =>
                {
                    switch (method)
                    {
                        case 0: TableForm.Populate((GridBruteForce)opt); break;
                        case 1: TableForm.Populate(((MonteCarlo)opt).Points); break;
                        case 2: TableForm.Populate(((HookeJeeves)opt).Points); break;
                        case 3: return; break;
                        default: break;
                    }
                });
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Не удалось найти точки, удовлетворяющие ограничениям");
                resultlabel.Text = "-";
                logstr += "  -  Неудача!";
            }
            listBox1.Items.Add(logstr + "\t\t");
            logstr = "";
        }

        private void SetChartArea(Optimize.BasicData.VarBounds bounds)
        {
            chart.Series.Clear();
            chart.Series.Add("Null");
            //chart.Series["Null"].Points.AddXY(0, 0);
            chart.ChartAreas[0].AxisX.Maximum = bounds.X1Upper;
            chart.ChartAreas[0].AxisX.Minimum = bounds.X1Lower;
            chart.ChartAreas[0].AxisY.Maximum = bounds.X2Upper;
            chart.ChartAreas[0].AxisY.Minimum = bounds.X2Lower;
            chart.ChartAreas[0].AxisX.Interval = MathExpr.Round(bounds.X1Interval / 20);
            chart.ChartAreas[0].AxisY.Interval = MathExpr.Round(bounds.X2Interval / 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  var st = new Stopwatch();
            //  st.Start();

            Run();

            //  st.Stop();
            // var mmm = st.ElapsedMilliseconds;
        }
        private void limitsRemoveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in limitsGridView.SelectedRows)
            {
                try { limitsGridView.Rows.RemoveAt(row.Index); }
                catch { }
            }
        }
        private void limitsGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lefttextBox.Text = limitsGridView[0, e.RowIndex].Value.ToString();
            righttextBox.Text = limitsGridView[2, e.RowIndex].Value.ToString();
            signcomboBox.Text = limitsGridView[1, e.RowIndex].Value.ToString();
            EditingRowIndex = e.RowIndex;
            label8.Text = (e.RowIndex + 1).ToString();
            limitsEditButton.Text = "Сохранить";
            limitsGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void limitsEditButton_Click(object sender, EventArgs e)
        {
            if (lefttextBox.Text.Trim().Length > 0 && righttextBox.Text.Trim().Length > 0)
            {
                if (EditingRowIndex == -1) EditingRowIndex = limitsGridView.Rows.Add();
                limitsGridView[0, EditingRowIndex].Value = lefttextBox.Text;
                limitsGridView[2, EditingRowIndex].Value = righttextBox.Text;
                limitsGridView[1, EditingRowIndex].Value = signcomboBox.Text;
                EditingRowIndex = -1;
                lefttextBox.Clear(); righttextBox.Clear();
                limitsEditButton.Text = "Добавить";
                label8.Text = "№";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (TableForm != null) TableForm.ShowDialog();
        }
        private void methodcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (methodcomboBox.SelectedIndex)
            {
                case 0: method = 0; break;
                case 1: method = 1; break;
                case 2: method = 2; break;
                case 3: method = 3; break;
            }
        }
        private void criteriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (criteriaComboBox.SelectedIndex)
            {
                case 0: crit = Optimize.BasicData.Criteria.Minimum; break;
                case 1: crit = Optimize.BasicData.Criteria.Maximum; break;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void enableStartPoint_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}




