using System;
using System.Windows;

namespace KeyboardSpeedSimulator
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            TotalCharsLabel.Text += Properties.Settings.Default.totalChars.ToString();
            TotalWordsLabel.Text += Properties.Settings.Default.totalWords.ToString();
            TotalMistakesLabel.Text += Properties.Settings.Default.totalMis.ToString();
            TotalLinesLabel.Text += Properties.Settings.Default.totalLines.ToString();
            TotalTimeLabel.Text += Properties.Settings.Default.totalTime.ToString();
        }
        public void ResetButton_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Reset all data","Realy?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.bestCharsPerMin = 0;
                Properties.Settings.Default.bestMisPerLine = 99999;
                Properties.Settings.Default.bestWordsPerMin = 0;
                Properties.Settings.Default.totalChars = 0;
                Properties.Settings.Default.totalWords = 0;
                Properties.Settings.Default.totalMis = 0;
                Properties.Settings.Default.totalLines = 0;
                Properties.Settings.Default.totalTime = TimeSpan.Zero;

                MessageBox.Show("Restart application for refrash data.");
                Application.Current.Shutdown();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            ((MainWindow)Owner).statWindow = null;
            ((MainWindow)Owner).MainTextBox.Focus();
            base.OnClosed(e);
        }
    }
}
