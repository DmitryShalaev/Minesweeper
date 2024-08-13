namespace WinFormsApp {
    public partial class Player : Form {
        public Player() {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
            if(e.newState == 8) {
                Close();
            }

        }
    }
}
