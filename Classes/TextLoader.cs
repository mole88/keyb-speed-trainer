using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace KeyboardSpeedSimulator
{
    static class TextLoader
    {
        public static string LoadText(string path)
        {
            try
            {
                string text;
                using (StreamReader sr = new(path, Encoding.Default))
                    text = sr.ReadToEnd();

                text = new Regex(@"\s+").Replace(text, " ");
                return text;
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }
    }
}
