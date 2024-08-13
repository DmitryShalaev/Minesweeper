using Core;
using System;
using System.Media;
using WinFormsApp.Properties;
namespace WinFormsApp {
    public partial class Form : System.Windows.Forms.Form 
    {
        SoundPlayer start;
        SoundPlayer flag = new SoundPlayer("Res/tapok.wav");
        SoundPlayer babah = new SoundPlayer("Res/davai-po-novoi-misha.wav");
        SoundPlayer win = new SoundPlayer("Res/win.wav");
        Minesweeper minesweeper;

        int height;
        int width;
        int mines;
        int countCells;
        bool tm;
        TimeSpan elapsedTime;
        public Form() 
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            elapsedTime = new TimeSpan(0);
        }

        private void timer1_Tick(object sender, EventArgs e) 
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            time.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void MoveToCenterScreen() 
        {
            var screen = Screen.FromControl(this);
            this.Top = screen.Bounds.Height / 2 - this.Height / 2;
            this.Left = screen.Bounds.Width / 2 - this.Bounds.Width / 2;
        }

        private void DrawField(int height, int width) 
        {
            field.Controls.Clear();
            field.RowStyles.Clear();
            field.ColumnStyles.Clear();
            field.RowCount = height;
            field.ColumnCount = width;

            int buttonSize = 40;

            for(int i = 0; i < width; i++) {
                field.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, buttonSize));
                for(int j = 0; j < height; j++) {
                    if(i == 0) field.RowStyles.Add(new RowStyle(SizeType.Absolute, buttonSize));
                    Button b = new Button();
                    b.Size = new Size(buttonSize, buttonSize);
                    b.FlatStyle = FlatStyle.Flat;
                    b.Click += new EventHandler(Cell_Click!);
                    b.MouseDown += new MouseEventHandler(Cell_MouseDown!);
                    field.Controls.Add(b, i, j);
                }
            }
            ReturnOldSize();
            field.Size = new Size(buttonSize * width, buttonSize * height);
            if(field.Width > this.ClientSize.Width || field.Height > this.ClientSize.Height) {
                this.ClientSize = new Size(Math.Max(this.ClientSize.Width, field.Width) + 10, Math.Max(this.ClientSize.Height, field.Height) + groupBox1.Height);
            }

            field.Location = new Point((this.ClientSize.Width - field.Width) / 2, (this.ClientSize.Height + groupBox1.Height - field.Height) / 2);
            groupBox1.Location = new Point((this.ClientSize.Width - groupBox1.Width) / 2, 10);
        }

        private void Set(Result r) 
        {
            foreach(Result? item in r.results) 
            {
                if(item is not null) 
                {
                    Button btn = (Button)field.GetControlFromPosition(item.Y, item.X)!;
                    btn!.Click -= Cell_Click!;
                    btn!.MouseDown -= Cell_MouseDown!;
                    countCells--;
                    if(item.NumberOfBombs == 0) { btn.Image = null; btn.BackColor = Color.Gray; }
                    else btn.Text = item.NumberOfBombs.ToString();
                    Set(item);
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e) 
        {
            if (!tm) { timer.Start(); tm = true; }
            Button? b = sender as Button;
            TableLayoutPanelCellPosition position = field.GetPositionFromControl(b);
            Result res = minesweeper.CheckCell(position.Column, position.Row);

            if(res.IsBomb) 
            {
                b!.Image = Resources.bomb;
                NewGame.Image = Resources.nothehe;
                babah.Play();
                timer.Stop();
                elapsedTime = new TimeSpan(0);
                tm = false;
                for(int row = 0; row < height; row++) 
                {
                    for(int col = 0; col < width; col++) 
                    {
                        Button btn = (Button)field.GetControlFromPosition(col, row)!;
                        btn.Click -= Cell_Click!;
                        btn.MouseDown -= Cell_MouseDown!;
                        if(minesweeper.Bombs[row * width + col]) btn.Image = Resources.bomb;
                    }
                }
            }
            
            if (res.NumberOfBombs == 0) 
            {
                b!.BackColor = Color.Gray;
                Set(res);
            }
            else b!.Text = res.NumberOfBombs.ToString();
            b.Click -= Cell_Click!;
            b.MouseDown -= Cell_MouseDown!;

            countCells--;
            if(countCells == mines) 
            {
                for(int row = 0; row < height; row++) {
                    for(int col = 0; col < width; col++) {
                        Button btn = (Button)field.GetControlFromPosition(col, row)!;
                        btn.Click -= Cell_Click!;
                        if(minesweeper.Bombs[row * width + col]) btn.Image = Resources.tapok;
                    }
                }
                label5.Text = "0";
                timer.Stop();
                elapsedTime = new TimeSpan(0);
                tm = false;
                win.Play();
                MessageBox.Show("УРА, ПОБЕДА!");
            }
        }

        void Cell_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            Button? b = sender as Button;
            if (e.Button == MouseButtons.Right) 
            {
                if(b!.Image != null) 
                {
                    b.Image = null;
                    b.Click += Cell_Click!;
                    b.FlatStyle = FlatStyle.Flat;
                    label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                } 
                else 
                {
                    b.Image = Resources.tapok;
                    b.Click -= Cell_Click!;
                    flag.Play();
                    label5.Text = (Convert.ToInt32(label5.Text) - 1).ToString();
                }
            }
        }
    
        private void NewGame_Click(object sender, EventArgs e)
        {
            timer.Stop();
            tm = false;
            elapsedTime = new TimeSpan(0);
            time.Text = elapsedTime.ToString(@"hh\:mm\:ss");

            NewGame.Image = Resources.hehe;
            start = new SoundPlayer("Res/startuem.wav");
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    height = width = 9;
                    mines = 10;
                    break;
                case 1:
                    height = width = 16;
                    mines = 40;
                    start = new SoundPlayer("Res/pognali.wav");
                    break;
                case 2:
                    height = 16;
                    width = 30;
                    mines = 99;
                    start = new SoundPlayer("Res/kazahstan.wav");
                    break;
                case 3:
                    try
                    {
                        height = Convert.ToInt32(inputHeight.Text);
                        width = Convert.ToInt32(inputWidth.Text);
                        mines = Convert.ToInt32(inputMines.Text);
                    }
                    catch { MessageBox.Show("Введенные данные некорректны!"); return; }
                    break;

            }
            countCells = width * height;
            minesweeper = new(height, width, mines);
            DrawField(height, width);
            MoveToCenterScreen();
            start.Play();
            field.Enabled = true;
            label5.Text = mines.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewGame.Image = Resources.start_button;
            if (comboBox1.SelectedIndex == 3) { groupBox2.Visible = true; }
            else groupBox2.Visible = false;
        }

        private void ReturnOldSize() 
        {
            this.Size = new Size(690, 810);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            DrawField(9, 9);
            field.Enabled = false;
        }
    }
}
