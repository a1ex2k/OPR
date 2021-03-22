using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            x1ltextBox.Text = "-2";
            x1utextBox.Text = "8";
            x2ltextBox.Text = "-5";
            x2utextBox.Text = "5";
            par1TextBox.Text = "0.2";
            par2TextBox.Text = "500";
            funcTextBox.Text = "(x1-2)^2+(x2-1)^2";
            limitsGridView.Rows.Add(); limitsGridView.Rows.Add();
            limitsGridView[0, 0].Value = "x1-2*x2+1"; limitsGridView[1, 0].Value = ">="; limitsGridView[2, 0].Value = "2";
            limitsGridView[0, 1].Value = "x1+4*x2"; limitsGridView[1, 1].Value = ">="; limitsGridView[2, 1].Value = "3";
            methodcomboBox.Items.AddRange(new object[] { "Прямого перебора по сетке", "Монте-Кaрло", "Хука-Дживса", "Штрафных Функций" });
            criteriaComboBox.SelectedIndex = methodcomboBox.SelectedIndex = 0;
        }
        private int EditingRowIndex = -1;
        private int Method;
        private Optimize.InputData.Criteria Criteria;
        private TableForm TableForm;
        private string logstr = "";

        Optimize.InputData PrepareValues()
        {
            Optimize.InputData data = null;
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
                double x1min, x1max, x2min, x2max, par_step;
                uint par_count;
                x1min = Double.Parse(x1ltextBox.Text);
                x1max = Double.Parse(x1utextBox.Text);
                x2min = Double.Parse(x2ltextBox.Text);
                x2max = Double.Parse(x2utextBox.Text);
                par_step = Double.Parse(par1TextBox.Text);
                par_count = uint.Parse(par2TextBox.Text);

                var bounds = new Optimize.InputData.VarBounds(x1min, x1max, x2min, x2max);
                logstr += " " + bounds;

                data = new Optimize.InputData(func, Criteria, restr, bounds);
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
            Optimize.InputData data = PrepareValues();
            if (data == null) return;
            SetChartArea(data.Bounds);
            Plotting.Isolines(data).ForEach(s => chart.Series.Add(s));

            double par_step = Double.Parse(par1TextBox.Text);
            uint par_count = uint.Parse(par2TextBox.Text);
            

            Optimize opt;
            switch (Method)
            {
                case 0: opt = new GridBruteForce(data, par_step); logstr = $"{methodcomboBox.Text}, Шаг: {par_step} - "+ logstr; break;
                case 1: opt = new MonteCarlo(data, par_count); logstr = $"{methodcomboBox.Text} - " + logstr; break;
                case 3: return; break;
                case 4: return; break;
                default: opt = new GridBruteForce(data, par_step); break;
            }



            try
            {
                opt.RunOptimization();
                resultlabel.Text = $"{opt.Result}\r\nДлительность: {opt.Duration} мс, {opt.Iterations} итер.";
                logstr = $"y({opt.Result.X1},{opt.Result.X2})={opt.Result.Y}, {opt.Duration} мс, {opt.Iterations} итер. - " + logstr;
                chart.Series.Add(Plotting.PlacePoint(opt.Result, Color.Crimson));

                TableForm = new TableForm();
                switch (Method)
                {
                    case 0: TableForm.Populate((GridBruteForce)opt); break;
                    case 1: TableForm.Populate(((MonteCarlo)opt).Points);  break;
                    case 3: return; break;
                    case 4: return; break;
                    default: break;
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Не удалось найти точки, удовлетворяющие ограничениям");
                resultlabel.Text = "-";
                logstr += "  -  Неудача!";
            }
            listBox1.Items.Add(logstr+"\t\t");
            logstr = "";
        }

        private void SetChartArea(Optimize.InputData.VarBounds bounds)
        {
            chart.ChartAreas[0].AxisX.Maximum = bounds.X1Upper;
            chart.ChartAreas[0].AxisX.Minimum = bounds.X1Lower;
            chart.ChartAreas[0].AxisY.Maximum = bounds.X2Upper;
            chart.ChartAreas[0].AxisY.Minimum = bounds.X2Lower;
            chart.ChartAreas[0].AxisX.Interval = MathExpr.Round(bounds.X1Interval / 20);
            chart.ChartAreas[0].AxisY.Interval = MathExpr.Round(bounds.X2Interval / 20);
            chart.Series.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
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
                case 0: label7.Text = "Шаг для перебора по сетке"; Method = 0; break;
                case 1: label7.Text = "Количество попыток поиска"; Method = 1; break;
                case 3: label7.Text = "-"; Method = 2; break;
                case 4: label7.Text = "-"; Method = 3; break;
            }
        }
        private void criteriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (criteriaComboBox.SelectedIndex)
            {
                case 0: Criteria = Optimize.InputData.Criteria.Minimum; break;
                case 1: Criteria = Optimize.InputData.Criteria.Maximum; break;
            }
        }

    }
}




