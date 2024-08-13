namespace WinFormsApp {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            time = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            inputHeight = new TextBox();
            inputMines = new TextBox();
            label2 = new Label();
            inputWidth = new TextBox();
            NewGame = new Button();
            comboBox1 = new ComboBox();
            field = new TableLayoutPanel();
            timer = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            TLP_Custom = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            TLP_Custom.SuspendLayout();
            SuspendLayout();
            // 
            // time
            // 
            time.AutoSize = true;
            time.Dock = DockStyle.Fill;
            time.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            time.Location = new Point(3, 47);
            time.Name = "time";
            time.Size = new Size(273, 47);
            time.TabIndex = 7;
            time.Text = "00:00:00";
            time.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(267, 41);
            label5.TabIndex = 6;
            label5.Text = "Бомбы: 0";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 58);
            label3.Name = "label3";
            label3.Size = new Size(66, 30);
            label3.TabIndex = 7;
            label3.Text = "Мины:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 29);
            label1.TabIndex = 5;
            label1.Text = "Высота:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputHeight
            // 
            inputHeight.Dock = DockStyle.Left;
            inputHeight.Location = new Point(75, 3);
            inputHeight.Name = "inputHeight";
            inputHeight.Size = new Size(56, 23);
            inputHeight.TabIndex = 2;
            // 
            // inputMines
            // 
            inputMines.Dock = DockStyle.Left;
            inputMines.Location = new Point(75, 61);
            inputMines.Name = "inputMines";
            inputMines.Size = new Size(56, 23);
            inputMines.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(66, 29);
            label2.TabIndex = 6;
            label2.Text = "Ширина:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputWidth
            // 
            inputWidth.Dock = DockStyle.Left;
            inputWidth.Location = new Point(75, 32);
            inputWidth.Name = "inputWidth";
            inputWidth.Size = new Size(56, 23);
            inputWidth.TabIndex = 3;
            // 
            // NewGame
            // 
            NewGame.Anchor = AnchorStyles.None;
            NewGame.FlatAppearance.BorderSize = 0;
            NewGame.FlatStyle = FlatStyle.Flat;
            NewGame.Image = Properties.Resources.start_button;
            NewGame.Location = new Point(288, 7);
            NewGame.Name = "NewGame";
            NewGame.Size = new Size(92, 86);
            NewGame.TabIndex = 0;
            NewGame.UseVisualStyleBackColor = true;
            NewGame.Click += NewGame_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Простой", "Средний", "Сложный", "Задать вручную" });
            comboBox1.Location = new Point(11, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // field
            // 
            field.Anchor = AnchorStyles.None;
            field.ColumnCount = 1;
            field.ColumnStyles.Add(new ColumnStyle());
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            field.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            field.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            field.Location = new Point(89, 201);
            field.Margin = new Padding(1);
            field.Name = "field";
            field.RowCount = 2;
            field.RowStyles.Add(new RowStyle());
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            field.Size = new Size(495, 375);
            field.TabIndex = 1;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += Timer1_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel1.Controls.Add(field, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(674, 671);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.Size = new Size(668, 100);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(NewGame, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(668, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(time, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(386, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(279, 94);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(label5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(273, 41);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(TLP_Custom, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(279, 94);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // TLP_Custom
            // 
            TLP_Custom.ColumnCount = 2;
            TLP_Custom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLP_Custom.ColumnStyles.Add(new ColumnStyle());
            TLP_Custom.Controls.Add(label3, 0, 2);
            TLP_Custom.Controls.Add(label1, 0, 0);
            TLP_Custom.Controls.Add(inputMines, 1, 2);
            TLP_Custom.Controls.Add(inputHeight, 1, 0);
            TLP_Custom.Controls.Add(label2, 0, 1);
            TLP_Custom.Controls.Add(inputWidth, 1, 1);
            TLP_Custom.Dock = DockStyle.Fill;
            TLP_Custom.Location = new Point(142, 3);
            TLP_Custom.Name = "TLP_Custom";
            TLP_Custom.RowCount = 3;
            TLP_Custom.RowStyles.Add(new RowStyle());
            TLP_Custom.RowStyles.Add(new RowStyle());
            TLP_Custom.RowStyles.Add(new RowStyle());
            TLP_Custom.Size = new Size(134, 88);
            TLP_Custom.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 671);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сапёр 2.0";
            Load += Form_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            TLP_Custom.ResumeLayout(false);
            TLP_Custom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel field;
        private ComboBox comboBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox inputMines;
        private TextBox inputWidth;
        private TextBox inputHeight;
        private System.Windows.Forms.Timer timer;
        private Label label5;
        private Button NewGame;
        private Label time;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel TLP_Custom;
        private TableLayoutPanel tableLayoutPanel6;
    }
}
