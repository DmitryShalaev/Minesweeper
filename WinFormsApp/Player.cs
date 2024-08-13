namespace WinFormsApp {
    public partial class Player : Form {
        public Player() {
            InitializeComponent();

            byte[] videoBytes = Properties.Resources.ЧЕМПИОН;
            string tempFilePath = Path.Combine(Path.GetTempPath(), "temp.mp4");
            File.WriteAllBytes(tempFilePath, videoBytes);
            axWindowsMediaPlayer1.URL = tempFilePath;
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
            if(e.newState == 8) {
                Close();
            }
        }
    }
}
