using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSim.Console
{
    static class ConsoleEx
    {
        private static Color BackgroundDefault = Color.Black;
        private static Color ForegroundDefault = Color.White;

        private const string BackgroundHashCode = "48";
        private const string ForegroundHashCode = "38";
        private static string ColorHash(Color color, string hash) =>
            $"\x1b[{hash};2;{color.R};{color.G};{color.B}m";

        private static string BackgroundColorHash(Color color)
            => ColorHash(color, BackgroundHashCode);

        private static string ForegroundColorHash(Color color)
            => ColorHash(color, ForegroundHashCode);

        public static string Format(string text, Color backgroundColor, Color foregroundColor)
            =>
            $"{BackgroundColorHash(backgroundColor)}" +
            $"{ForegroundColorHash(foregroundColor)}" +
            $"{text}" +
            $"{BackgroundColorHash(BackgroundDefault)}" +
            $"{ForegroundColorHash(ForegroundDefault)}";

    }
}
