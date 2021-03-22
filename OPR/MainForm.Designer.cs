
namespace OPR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "1,4,-2,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, "10,8,3,2");
            this.funcTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limitsGridView = new System.Windows.Forms.DataGridView();
            this.Left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Right = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.limitsRemoveButton = new System.Windows.Forms.Button();
            this.x1ltextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.criteriaComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.righttextBox = new System.Windows.Forms.TextBox();
            this.signcomboBox = new System.Windows.Forms.ComboBox();
            this.lefttextBox = new System.Windows.Forms.TextBox();
            this.limitsEditButton = new System.Windows.Forms.Button();
            this.x2utextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.x2ltextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.x1utextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.par1TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.par2TextBox = new System.Windows.Forms.TextBox();
            this.methodcomboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.resultlabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.limitsGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // funcTextBox
            // 
            this.funcTextBox.BackColor = System.Drawing.Color.White;
            this.funcTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funcTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.funcTextBox.Location = new System.Drawing.Point(87, 24);
            this.funcTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.funcTextBox.Name = "funcTextBox";
            this.funcTextBox.Size = new System.Drawing.Size(232, 25);
            this.funcTextBox.TabIndex = 0;
            this.funcTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "F(x1, x2) =";
            // 
            // limitsGridView
            // 
            this.limitsGridView.AllowUserToAddRows = false;
            this.limitsGridView.AllowUserToResizeRows = false;
            this.limitsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.limitsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.limitsGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.limitsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.limitsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.limitsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.limitsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.limitsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Left,
            this.Sign,
            this.Right});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.limitsGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.limitsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.limitsGridView.EnableHeadersVisualStyles = false;
            this.limitsGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.limitsGridView.Location = new System.Drawing.Point(22, 31);
            this.limitsGridView.Margin = new System.Windows.Forms.Padding(0);
            this.limitsGridView.MultiSelect = false;
            this.limitsGridView.Name = "limitsGridView";
            this.limitsGridView.ReadOnly = true;
            this.limitsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.limitsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.limitsGridView.RowHeadersWidth = 27;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(2);
            this.limitsGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.limitsGridView.RowTemplate.Height = 26;
            this.limitsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.limitsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.limitsGridView.Size = new System.Drawing.Size(297, 133);
            this.limitsGridView.TabIndex = 3;
            this.limitsGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.limitsGridView_CellMouseDoubleClick);
            // 
            // Left
            // 
            this.Left.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Left.FillWeight = 104.8919F;
            this.Left.HeaderText = "Левая часть";
            this.Left.Name = "Left";
            this.Left.ReadOnly = true;
            this.Left.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sign
            // 
            this.Sign.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Sign.FillWeight = 73.28065F;
            this.Sign.HeaderText = "Знак";
            this.Sign.MinimumWidth = 50;
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            this.Sign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sign.Width = 50;
            // 
            // Right
            // 
            this.Right.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Right.FillWeight = 121.8274F;
            this.Right.HeaderText = "Правая часть";
            this.Right.MinimumWidth = 50;
            this.Right.Name = "Right";
            this.Right.ReadOnly = true;
            this.Right.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Критерий";
            // 
            // limitsRemoveButton
            // 
            this.limitsRemoveButton.BackColor = System.Drawing.SystemColors.Control;
            this.limitsRemoveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitsRemoveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.limitsRemoveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.limitsRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limitsRemoveButton.Location = new System.Drawing.Point(325, 139);
            this.limitsRemoveButton.Name = "limitsRemoveButton";
            this.limitsRemoveButton.Size = new System.Drawing.Size(86, 25);
            this.limitsRemoveButton.TabIndex = 8;
            this.limitsRemoveButton.Text = "Удалить";
            this.limitsRemoveButton.UseVisualStyleBackColor = false;
            this.limitsRemoveButton.Click += new System.EventHandler(this.limitsRemoveButton_Click);
            // 
            // x1ltextBox
            // 
            this.x1ltextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1ltextBox.Location = new System.Drawing.Point(464, 31);
            this.x1ltextBox.Name = "x1ltextBox";
            this.x1ltextBox.Size = new System.Drawing.Size(45, 23);
            this.x1ltextBox.TabIndex = 9;
            this.x1ltextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "x1 min";
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Location = new System.Drawing.Point(398, 25);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(111, 23);
            this.criteriaComboBox.TabIndex = 13;
            this.criteriaComboBox.SelectedIndexChanged += new System.EventHandler(this.criteriaComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.righttextBox);
            this.groupBox1.Controls.Add(this.signcomboBox);
            this.groupBox1.Controls.Add(this.lefttextBox);
            this.groupBox1.Controls.Add(this.limitsEditButton);
            this.groupBox1.Controls.Add(this.x2utextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.x2ltextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.x1utextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.limitsGridView);
            this.groupBox1.Controls.Add(this.limitsRemoveButton);
            this.groupBox1.Controls.Add(this.x1ltextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 215);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ограничения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "№";
            // 
            // righttextBox
            // 
            this.righttextBox.Location = new System.Drawing.Point(230, 170);
            this.righttextBox.Name = "righttextBox";
            this.righttextBox.Size = new System.Drawing.Size(89, 23);
            this.righttextBox.TabIndex = 22;
            this.righttextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // signcomboBox
            // 
            this.signcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signcomboBox.FormattingEnabled = true;
            this.signcomboBox.Location = new System.Drawing.Point(179, 170);
            this.signcomboBox.Name = "signcomboBox";
            this.signcomboBox.Size = new System.Drawing.Size(45, 23);
            this.signcomboBox.TabIndex = 21;
            // 
            // lefttextBox
            // 
            this.lefttextBox.Location = new System.Drawing.Point(47, 170);
            this.lefttextBox.Name = "lefttextBox";
            this.lefttextBox.Size = new System.Drawing.Size(126, 23);
            this.lefttextBox.TabIndex = 20;
            this.lefttextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // limitsEditButton
            // 
            this.limitsEditButton.BackColor = System.Drawing.SystemColors.Control;
            this.limitsEditButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.limitsEditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.limitsEditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.limitsEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limitsEditButton.ForeColor = System.Drawing.Color.Black;
            this.limitsEditButton.Location = new System.Drawing.Point(325, 168);
            this.limitsEditButton.Name = "limitsEditButton";
            this.limitsEditButton.Size = new System.Drawing.Size(86, 25);
            this.limitsEditButton.TabIndex = 19;
            this.limitsEditButton.Text = "Добавить";
            this.limitsEditButton.UseVisualStyleBackColor = false;
            this.limitsEditButton.Click += new System.EventHandler(this.limitsEditButton_Click);
            // 
            // x2utextBox
            // 
            this.x2utextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2utextBox.Location = new System.Drawing.Point(464, 117);
            this.x2utextBox.Name = "x2utextBox";
            this.x2utextBox.Size = new System.Drawing.Size(45, 23);
            this.x2utextBox.TabIndex = 15;
            this.x2utextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "x2 max";
            // 
            // x2ltextBox
            // 
            this.x2ltextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2ltextBox.Location = new System.Drawing.Point(464, 88);
            this.x2ltextBox.Name = "x2ltextBox";
            this.x2ltextBox.Size = new System.Drawing.Size(45, 23);
            this.x2ltextBox.TabIndex = 13;
            this.x2ltextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "x2 min";
            // 
            // x1utextBox
            // 
            this.x1utextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1utextBox.Location = new System.Drawing.Point(464, 59);
            this.x1utextBox.Name = "x1utextBox";
            this.x1utextBox.Size = new System.Drawing.Size(45, 23);
            this.x1utextBox.TabIndex = 11;
            this.x1utextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "x1 max";
            // 
            // par1TextBox
            // 
            this.par1TextBox.Location = new System.Drawing.Point(207, 62);
            this.par1TextBox.Name = "par1TextBox";
            this.par1TextBox.Size = new System.Drawing.Size(54, 23);
            this.par1TextBox.TabIndex = 17;
            this.par1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Шаг для перебора по сетке";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.funcTextBox);
            this.groupBox2.Controls.Add(this.criteriaComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 65);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Функция";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(398, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "Оптимизировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.par2TextBox);
            this.groupBox3.Controls.Add(this.methodcomboBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.par1TextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 143);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Количество случайных точек\r\n";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // par2TextBox
            // 
            this.par2TextBox.Location = new System.Drawing.Point(207, 93);
            this.par2TextBox.Name = "par2TextBox";
            this.par2TextBox.Size = new System.Drawing.Size(54, 23);
            this.par2TextBox.TabIndex = 19;
            this.par2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // methodcomboBox
            // 
            this.methodcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.methodcomboBox.FormattingEnabled = true;
            this.methodcomboBox.Location = new System.Drawing.Point(67, 29);
            this.methodcomboBox.Name = "methodcomboBox";
            this.methodcomboBox.Size = new System.Drawing.Size(442, 23);
            this.methodcomboBox.TabIndex = 15;
            this.methodcomboBox.SelectedIndexChanged += new System.EventHandler(this.methodcomboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Метод";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.chart);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.resultlabel);
            this.groupBox4.Location = new System.Drawing.Point(558, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(380, 445);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результат";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(343, 275);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "x1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(21, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "x2";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.BackColor = System.Drawing.Color.DarkGray;
            this.chart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.LabelAutoFitMaxFontSize = 9;
            chartArea3.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea3.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90)));
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisX.TitleForeColor = System.Drawing.SystemColors.Highlight;
            chartArea3.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisY.LabelAutoFitMaxFontSize = 9;
            chartArea3.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea3.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)));
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea3.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.TitleForeColor = System.Drawing.SystemColors.Highlight;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(6, 31);
            this.chart.Name = "chart";
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.SystemColors.Highlight;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            dataPoint5.BorderWidth = 0;
            dataPoint5.Color = System.Drawing.Color.Transparent;
            dataPoint5.IsEmpty = true;
            series3.Points.Add(dataPoint5);
            series3.Points.Add(dataPoint6);
            series3.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series3.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series3.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Round;
            series3.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.Box;
            series3.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series3.SmartLabelStyle.IsOverlappedHidden = false;
            series3.SmartLabelStyle.MaxMovingDistance = 0D;
            series3.YValuesPerPoint = 4;
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(336, 276);
            this.chart.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(20, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(341, 25);
            this.button2.TabIndex = 22;
            this.button2.Text = "Показать таблицу точек\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // resultlabel
            // 
            this.resultlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultlabel.Location = new System.Drawing.Point(20, 310);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(341, 77);
            this.resultlabel.TabIndex = 21;
            this.resultlabel.Text = "F{x1, x2)";
            this.resultlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBox1);
            this.groupBox5.Location = new System.Drawing.Point(12, 468);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(926, 228);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "История";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(22, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(885, 182);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 708);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оптимизация функций";
            ((System.ComponentModel.ISupportInitialize)(this.limitsGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox funcTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView limitsGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button limitsRemoveButton;
        private System.Windows.Forms.TextBox x1ltextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox criteriaComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox par1TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox x2utextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox x2ltextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox x1utextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox righttextBox;
        private System.Windows.Forms.ComboBox signcomboBox;
        private System.Windows.Forms.TextBox lefttextBox;
        private System.Windows.Forms.Button limitsEditButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Left;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn Right;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox methodcomboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label resultlabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox par2TextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

