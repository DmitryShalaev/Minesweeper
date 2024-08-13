using System.Media;

using Core;

using WinFormsApp.Properties;
namespace WinFormsApp {
    public partial class Form : System.Windows.Forms.Form {
        private SoundPlayer? start;
        private readonly SoundPlayer flag = new("Res/tapok.wav");
        private readonly SoundPlayer babah = new("Res/davai-po-novoi-misha.wav");
        private readonly SoundPlayer win = new("Res/win.wav");
        private Minesweeper? minesweeper;

        private int height;
        private int width;
        private int mines;
        private int countCells;
        private bool tm;
        private TimeSpan elapsedTime;

        public Form() {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            elapsedTime = new TimeSpan(0);
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            time.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void MoveToCenterScreen() {
            var screen = Screen.FromControl(this);
            Top = screen.Bounds.Height / 2 - Height / 2;
            Left = screen.Bounds.Width / 2 - Bounds.Width / 2;
        }

        public void EnableDoubleBuffering(Control control) {
            System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
            aProp.SetValue(control, true, null);
        }

        private void DrawField(int height, int width) {
            // Приостанавливаем компоновку и отрисовку поля
            field.SuspendLayout();
            field.Visible = false;

            field.Controls.Clear();
            field.RowStyles.Clear();
            field.ColumnStyles.Clear();
            field.RowCount = height;
            field.ColumnCount = width;

            EnableDoubleBuffering(field);

            int buttonSize = 40;

            // Устанавливаем размеры столбцов и строк
            for(int i = 0; i < width; i++) {
                if(i >= field.ColumnStyles.Count) {
                    field.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, buttonSize));
                } else {
                    field.ColumnStyles[i].Width = buttonSize;
                }
            }

            for(int j = 0; j < height; j++) {
                if(j >= field.RowStyles.Count) {
                    field.RowStyles.Add(new RowStyle(SizeType.Absolute, buttonSize));
                } else {
                    field.RowStyles[j].Height = buttonSize;
                }
            }

            // Создаем и добавляем кнопки
            for(int i = 0; i < width; i++) {
                for(int j = 0; j < height; j++) {
                    Button b;

                    if(i * height + j < field.Controls.Count) {
                        b = (Button)field.Controls[i * height + j];
                        b.Size = new Size(buttonSize, buttonSize);
                    } else {
                        b = new Button {
                            Size = new Size(buttonSize, buttonSize),
                            FlatStyle = FlatStyle.Flat
                        };
                        b.Click += new EventHandler(Cell_Click!);
                        b.MouseDown += new MouseEventHandler(Cell_MouseDown!);
                        field.Controls.Add(b, i, j);
                    }
                }
            }

            // Обновляем размеры и расположение контейнера
            ReturnOldSize();
            field.Size = new Size(buttonSize * width, buttonSize * height);
            if(field.Width > ClientSize.Width || field.Height > ClientSize.Height) {
                ClientSize = new Size(Math.Max(ClientSize.Width, field.Width) + 10, Math.Max(ClientSize.Height, field.Height) + groupBox1.Height);
            }

            field.Location = new Point((ClientSize.Width - field.Width) / 2, (ClientSize.Height + groupBox1.Height - field.Height) / 2);
            groupBox1.Location = new Point((ClientSize.Width - groupBox1.Width) / 2, 10);

            // Возобновляем компоновку и показываем поле
            field.ResumeLayout();
            field.Visible = true;
        }

        private void Set(Result r) {
            foreach(Result? item in r.results) {
                if(item is not null) {
                    var btn = (Button)field.GetControlFromPosition(item.Y, item.X)!;
                    btn!.Click -= Cell_Click!;
                    btn!.MouseDown -= Cell_MouseDown!;
                    countCells--;
                    if(item.NumberOfBombs == 0) {
                        btn.Image = null;
                        btn.BackColor = Color.Gray;
                    } else {
                        btn.Image = null;
                        btn.Text = item.NumberOfBombs.ToString();
                    }

                    Set(item);
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e) {
            if(!tm) {
                timer.Start();
                tm = true;
            }

            if(sender is not Button b) return;

            TableLayoutPanelCellPosition position = field.GetPositionFromControl(b);
            Result res = minesweeper!.CheckCell(position.Column, position.Row);

            if(res.IsBomb) {
                HandleBombClicked(b);
                return;
            }

            if(res.NumberOfBombs == 0) {
                b.BackColor = Color.Gray;
                Set(res);
            } else {
                b.Text = res.NumberOfBombs.ToString();
            }

            b.Click -= Cell_Click!;
            b.MouseDown -= Cell_MouseDown!;

            countCells--;
            if(countCells == mines) {
                HandleWin();
            }
        }

        private void HandleBombClicked(Button b) {
            b!.Image = Resources.bomb;
            NewGame.Image = Resources.nothehe;
            babah.Play();
            timer.Stop();
            elapsedTime = new TimeSpan(0);
            tm = false;

            EndGame(Resources.bomb);
        }

        private void HandleWin() {
            EndGame(Resources.tapok);

            label5.Text = "0";
            timer.Stop();
            elapsedTime = new TimeSpan(0);
            tm = false;
            win.Play();
            MessageBox.Show("УРА, ПОБЕДА!");
        }

        private void EndGame(Bitmap img) {
            for(int row = 0; row < height; row++) {
                for(int col = 0; col < width; col++) {
                    var btn = (Button)field.GetControlFromPosition(col, row)!;
                    btn.Click -= Cell_Click!;
                    btn.MouseDown -= Cell_MouseDown!;
                    if(minesweeper!.Bombs[row * width + col]) {
                        btn.Image = img;
                    }
                }
            }
        }

        private void Cell_MouseDown(object sender, MouseEventArgs e) {
            var b = sender as Button;
            if(e.Button == MouseButtons.Right) {
                if(b!.Image != null) {
                    b.Image = null;
                    b.Click += Cell_Click!;
                    b.FlatStyle = FlatStyle.Flat;
                    label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                } else {
                    b.Image = Resources.tapok;
                    b.Click -= Cell_Click!;
                    flag.Play();
                    label5.Text = (Convert.ToInt32(label5.Text) - 1).ToString();
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e) {
            timer.Stop();
            tm = false;
            elapsedTime = new TimeSpan(0);
            time.Text = elapsedTime.ToString(@"hh\:mm\:ss");

            NewGame.Image = Resources.hehe;
            start = new SoundPlayer("Res/startuem.wav");
            switch(comboBox1.SelectedIndex) {
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
                    try {
                        height = Convert.ToInt32(inputHeight.Text);
                        width = Convert.ToInt32(inputWidth.Text);
                        mines = Convert.ToInt32(inputMines.Text);
                    } catch { MessageBox.Show("Введенные данные некорректны!"); return; }

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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            NewGame.Image = Resources.start_button;
            groupBox2.Visible = comboBox1.SelectedIndex == 3;
        }

        private void ReturnOldSize() => Size = new Size(690, 810);

        private void Form_Load(object sender, EventArgs e) {
            DrawField(9, 9);
            field.Enabled = false;
        }
    }
}
