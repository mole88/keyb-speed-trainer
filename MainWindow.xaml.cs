using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KeyboardSpeedSimulator
{
    public partial class MainWindow : Window
    {
        string folderPath = @"Texts\RusTexts";
        Stopwatch sw = new();
        int mistakes = 0;
        public Window statWindow;
        public Window customTextWindow;
        Queue<string> lines = new();

        public MainWindow()
        {
            InitializeComponent();
            BestCharsPerMinLabel.Text = Properties.Settings.Default.bestCharsPerMin.ToString() + " chars/min";
            BestWordsPerMinLabel.Text = Properties.Settings.Default.bestWordsPerMin.ToString() + " words/min";
            BestMisPerLineLabel.Text = Properties.Settings.Default.bestMisPerLine.ToString() + " mis/line";
            AutoBcspCheckBox.IsChecked = Properties.Settings.Default.autoBcsp;

            if (Properties.Settings.Default.kBoardLang == "Rus")
            {
                ChangeLangButton_Click(new object(), new RoutedEventArgs());
                folderPath = @"Texts\EngTexts";
            }
            else
                folderPath = @"Texts\RusTexts";

            TextToStrings(RandomTextSelect());
            MainTextBox.Focus();
        }
        private string RandomTextSelect()
        {
            Random random = new();
            int numderOfFile = random.Next(Directory.GetFiles(folderPath).Length);

            return TextLoader.LoadText($@"{folderPath}\Text{numderOfFile}.txt");
        }
        private void TextToStrings(string text)
        {
            string[] words = text.Split();
            int maxLength = 80;
            int lastWord = 0;
            string currentLine = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                if ((currentLine + words[i]).Length >= maxLength)
                {
                    lines.Enqueue(currentLine);
                    currentLine = string.Empty;
                }
                currentLine += words[i] + " ";
                lastWord = i;
            }

            currentLine = string.Empty;
            for (int i = lastWord; i < words.Length; i++)
                currentLine += words[i] + " ";

            lines.Enqueue(currentLine);
            UpdateLines();
        }
        private void UpdateLines()
        {
            do
            {
                FirstStringLabel.Text = SecondStringLabel.Text;
                SecondStringLabel.Text = ThirdStringLabel.Text;
                ThirdStringLabel.Text = lines.Count != 0 ? lines.Dequeue() : string.Empty;
            } while (FirstStringLabel.Text == string.Empty);
        }
        private void Timed()
        {
            int charsInLine = FirstStringLabel.Text.Length;
            int wordsInLine = FirstStringLabel.Text.Count(c => c == ' ');

            int charsPerMin = (int)(charsInLine / (sw.Elapsed.TotalSeconds / 60));
            int wordsPerMin = (int)(charsInLine / (sw.Elapsed.TotalSeconds / 60) / 6);
            //average length of russian word ~ 7 ch. Average length of english word ~ 5 ch.
            //average of 7 & 5 = 6

            if (charsPerMin > Properties.Settings.Default.bestCharsPerMin)
                Properties.Settings.Default.bestCharsPerMin = charsPerMin;

            if (wordsPerMin > Properties.Settings.Default.bestWordsPerMin)
                Properties.Settings.Default.bestWordsPerMin = wordsPerMin;

            if (mistakes < Properties.Settings.Default.bestMisPerLine)
                Properties.Settings.Default.bestMisPerLine = mistakes;

            Properties.Settings.Default.totalChars += (ulong)charsInLine;
            Properties.Settings.Default.totalWords += (ulong)wordsInLine;
            Properties.Settings.Default.totalMis += (ulong)mistakes;
            Properties.Settings.Default.totalLines++;
            Properties.Settings.Default.totalTime += sw.Elapsed;

            DisplayResults(charsPerMin, wordsPerMin, Properties.Settings.Default.bestCharsPerMin,
                Properties.Settings.Default.bestWordsPerMin, Properties.Settings.Default.bestMisPerLine);

            Properties.Settings.Default.Save();
        }
        private void DisplayResults(int charsPerMin, int wordsPerMin, int bestCharsPerMin,
        int bestWordsPerMin, int bestMisPerLine)
        {
            CharsPerMinLabel.Text = charsPerMin.ToString() + " chars/min";
            WordsPerMinLabel.Text = wordsPerMin.ToString() + " words/min";
            MisPerLineLabel.Text = mistakes + " mis/line";

            BestCharsPerMinLabel.Text = bestCharsPerMin.ToString() + " chars/min";
            BestWordsPerMinLabel.Text = bestWordsPerMin.ToString() + " words/min";
            BestMisPerLineLabel.Text = bestMisPerLine.ToString() + " mis/line";
        }

        private async void MainTextBox_Changed(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainTextBox.Text == FirstStringLabel.Text.Remove(MainTextBox.Text.Length))
                {
                    MainTextBox.Background = Brushes.White;
                    sw.Start();
                }
                else
                {
                    MainTextBox.Background = Brushes.Gray;
                    mistakes++;

                    if (AutoBcspCheckBox.IsChecked == true)
                    {
                        await Task.Delay(100);
                        MainTextBox.Text = FirstStringLabel.Text.Remove(MainTextBox.Text.Length - 1);
                        MainTextBox.CaretIndex = MainTextBox.Text.Length;
                    }
                }
            } catch{}

            if (MainTextBox.Text == string.Empty)
            {
                mistakes = 0;
                sw.Reset();
            }

            if (MainTextBox.Text == FirstStringLabel.Text)
            {
                sw.Stop();
                Timed();
                if (lines.Count == 0)
                {
                    MainTextBox.Text = string.Empty;
                    TextToStrings(RandomTextSelect());
                }
                else
                {
                    UpdateLines();
                    MainTextBox.Text = string.Empty;
                }
            }
        }
        private void ClearStrings()
        {
            FirstStringLabel.Text = string.Empty;
            SecondStringLabel.Text = string.Empty;
            ThirdStringLabel.Text = string.Empty;
        }
        private void PrepForNewText()
        {
            MainTextBox.Text = string.Empty;
            lines.Clear();
            ClearStrings();
            MainTextBox.Focus();
        }
        private void CustomTextButton_Click(object sender, RoutedEventArgs e)
        {
            statWindow = new CustomTextWindow { Owner = this };
            statWindow.ShowDialog();

            if (CustomTexts.SelectedText != null)
            {
                PrepForNewText();
                TextToStrings(TextLoader.LoadText(CustomTexts.SelectedText.Path));
                MainTextBox.Focus();
            }
        }
        private void NewTextButton_Click(object sender, RoutedEventArgs e)
        {
            PrepForNewText();
            TextToStrings(RandomTextSelect());
        }
        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            if (customTextWindow == null)
            {
                statWindow = new StatisticsWindow { Owner = this };
                statWindow.Show();
            }
        }
        private void ChangeLangButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeLangButton.Content.ToString() == "Rus")
            {
                EngImage.Visibility = Visibility.Collapsed;
                RusImage.Visibility = Visibility.Visible;
                folderPath = @"Texts\RusTexts";
                ChangeLangButton.Content = "Eng";
            }
            else
            {
                EngImage.Visibility = Visibility.Visible;
                RusImage.Visibility = Visibility.Collapsed;
                folderPath = @"Texts\EngTexts";
                ChangeLangButton.Content = "Rus";
            }
            MainTextBox.Focus();
            HideKeybButton.Content = "Hide";
        }
        private void HideKeybButton_Click(object sender, RoutedEventArgs e)
        {
            if (HideKeybButton.Content.ToString() == "Hide")
            {
                HideKeybButton.Content = "Show";
                RusImage.Visibility = Visibility.Hidden;
                EngImage.Visibility = Visibility.Hidden;
            }
            else
            {
                HideKeybButton.Content = "Hide";
                RusImage.Visibility = Visibility.Visible;
                EngImage.Visibility = Visibility.Visible;
            }
            MainTextBox.Focus();
        }
        private void AutoBcspCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text = string.Empty;
            MainTextBox.Focus();
        }
        protected override void OnClosed(EventArgs e)
        {
            Properties.Settings.Default.autoBcsp = (bool)AutoBcspCheckBox.IsChecked;
            Properties.Settings.Default.kBoardLang = ChangeLangButton.Content.ToString();
            Properties.Settings.Default.Save();
            base.OnClosed(e);
        }
    }
}
