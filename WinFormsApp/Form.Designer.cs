namespace WinFormsApp {
    partial class Form {
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            groupBox1 = new GroupBox();
            time = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
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
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(time);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(NewGame);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(650, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // time
            // 
            time.AutoSize = true;
            time.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            time.Location = new Point(463, 55);
            time.Name = "time";
            time.Size = new Size(73, 20);
            time.TabIndex = 7;
            time.Text = "00:00:00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(522, 23);
            label5.Name = "label5";
            label5.Size = new Size(16, 17);
            label5.TabIndex = 6;
            label5.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(460, 23);
            label4.Name = "label4";
            label4.Size = new Size(60, 17);
            label4.TabIndex = 5;
            label4.Text = "Бомбы:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(inputHeight);
            groupBox2.Controls.Add(inputMines);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(inputWidth);
            groupBox2.Location = new Point(140, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(128, 100);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 75);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 7;
            label3.Text = "Мины:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 5;
            label1.Text = "Высота:";
            // 
            // inputHeight
            // 
            inputHeight.Location = new Point(56, 17);
            inputHeight.Name = "inputHeight";
            inputHeight.Size = new Size(56, 23);
            inputHeight.TabIndex = 2;
            // 
            // inputMines
            // 
            inputMines.Location = new Point(56, 71);
            inputMines.Name = "inputMines";
            inputMines.Size = new Size(56, 23);
            inputMines.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 48);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 6;
            label2.Text = "Ширина:";
            // 
            // inputWidth
            // 
            inputWidth.Location = new Point(56, 44);
            inputWidth.Name = "inputWidth";
            inputWidth.Size = new Size(56, 23);
            inputWidth.TabIndex = 3;
            // 
            // NewGame
            // 
            NewGame.FlatAppearance.BorderSize = 0;
            NewGame.FlatStyle = FlatStyle.Flat;
            NewGame.Image = Properties.Resources.start_button;
            NewGame.Location = new Point(285, 10);
            NewGame.Name = "NewGame";
            NewGame.Size = new Size(92, 86);
            NewGame.TabIndex = 0;
            NewGame.UseVisualStyleBackColor = true;
            NewGame.Click += NewGame_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Простой", "Средний", "Сложный", "Задать вручную" });
            comboBox1.Location = new Point(8, 16);
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
            field.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            field.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            field.Location = new Point(12, 106);
            field.Name = "field";
            field.RowCount = 2;
            field.RowStyles.Add(new RowStyle());
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            field.Size = new Size(650, 550);
            field.TabIndex = 1;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += Timer1_Tick;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 671);
            Controls.Add(field);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сапёр 2.0";
            Load += Form_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel field;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox inputMines;
        private TextBox inputWidth;
        private TextBox inputHeight;
        private System.Windows.Forms.Timer timer;
        private Label label4;
        private Label label5;
        private Button NewGame;
        private Label time;
    }
}
