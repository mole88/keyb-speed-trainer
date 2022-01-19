using System.Collections.ObjectModel;

namespace KeyboardSpeedSimulator
{
    class CustomTexts
    {
        public static ObservableCollection<Text> Texts { get; set; } = new();
        static public Text SelectedText { get; set; }
    }
}
