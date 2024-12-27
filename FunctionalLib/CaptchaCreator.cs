using System;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Size = System.Drawing.Size;
namespace AutoDbClassLibrary
{
    public class CaptchaCreater
    {
        private static readonly Random _random = new Random();
        private static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static Color GetRandomColor(int begin = 0, int end = 255)
        {
            return Color.FromArgb(_random.Next(begin, end + 1), _random.Next(begin, end + 1), _random.Next(begin, end + 1));
        }
        public static string GetRandomText(int length)
        {
            var text = new char[length];
            for (var i = 0; i < length; i++)
            {
                text[i] = _chars[_random.Next(_chars.Length)];
            }
            return new string(text);
        }
        public static Bitmap GetSimpleCaptcha(int length) => GetSimpleCaptcha(GetRandomText(length));
        public static Bitmap GetSimpleCaptcha(string str)
        {
            Font font = new Font("Georgia", 20);
            Size textSize = TextRenderer.MeasureText(str, font);
            Bitmap img = new Bitmap((int)3 * textSize.Width, (int)(textSize.Height * 1.5));
            using (Graphics graphics = Graphics.FromImage(img))
            {
                graphics.Clear(Color.White);
                int x = 0;
                int y = (img.Height - textSize.Height) / 2;
                foreach (char lett in str)
                {
                    int lettX = x + (textSize.Width / str.Length);
                    graphics.DrawString(lett.ToString(), font, new SolidBrush(GetRandomColor(0, 255)), lettX, y);
                    x += (int)(textSize.Width / str.Length * 2);
                }
                AddLines(graphics);
            }
            return img;
        }
        public static AddLines(Graphics graphics)
        {
            for (int i = 0; i < _random.Next(2, 5); i++)
            {
                int x1 = _random.Next(img.Width);
                int y1 = _random.Next(img.Height);
                x2 = _random.Next(img.Width);
                int y2 = _random.Next(img.Height);
                graphics.DrawLine(GetRandomColor(0, 100), x1, y1, x2, y2);
            }
        }
    }
}
