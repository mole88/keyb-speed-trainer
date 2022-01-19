using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
namespace KeyboardSpeedSimulator
{
    public partial class CustomTextWindow : Window
    {
        public CustomTextWindow()
        {
            InitializeComponent();
            TextsListViewer.ItemsSource = CustomTexts.Texts;
            UpdateFileTexts();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new()
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };
            if (dlg.ShowDialog() == true)
            {
                string fileName = Path.GetFileName(dlg.FileName);
                string newPath = $"Texts/СustomTexts/{fileName}";

                Text text = new(){ Name = fileName, Path = newPath };

                bool isNewFile = true;
                foreach (var t in CustomTexts.Texts)
                {
                    if (t.Name == text.Name) isNewFile = false;
                }

                if (isNewFile)
                {
                    File.Copy(dlg.FileName, newPath);
                    CustomTexts.Texts.Add(text);
                }
                else
                    MessageBox.Show("Text with same name already exist!");
            }
        }
        private void UpdateFileTexts()
        {
            foreach (var file in Directory.GetFiles("Texts/СustomTexts"))
            {
                string fileName = Path.GetFileName(file);
                string newPath = $"Texts/СustomTexts/{fileName}";
                Text text = new Text { Name = fileName, Path = newPath };

                CustomTexts.Texts.Add(text);
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Text sText = (Text)TextsListViewer.SelectedItem;
            CustomTexts.Texts.Remove(sText);
            File.Delete(sText.Path);
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            CustomTexts.SelectedText = (Text)TextsListViewer.SelectedItem;
            Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            CustomTexts.Texts.Clear();
            ((MainWindow)Owner).MainTextBox.Focus();
            base.OnClosed(e);
        }
        
    }
}
