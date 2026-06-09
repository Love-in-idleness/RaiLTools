using System;
using System.Text;

namespace RaiLTools
{
    /// <summary>
    /// Manages text encoding for different regional versions of game files.
    /// Supports Shift-JIS (Japanese) and GBK (Simplified Chinese) encodings.
    /// </summary>
    public class EncodingManager
    {
        public enum TextEncoding
        {
            ShiftJIS,
            GBK
        }

        private static Encoding _currentEncoding = Encoding.GetEncoding("shift_jis");
        
        public static TextEncoding CurrentEncoding { get; private set; } = TextEncoding.ShiftJIS;

        /// <summary>
        /// Sets the text encoding to use for file operations.
        /// </summary>
        /// <param name="encoding">The encoding type to use.</param>
        public static void SetEncoding(TextEncoding encoding)
        {
            CurrentEncoding = encoding;
            _currentEncoding = encoding switch
            {
                TextEncoding.ShiftJIS => Encoding.GetEncoding("shift_jis"),
                TextEncoding.GBK => Encoding.GetEncoding("gbk"),
                _ => throw new ArgumentException($"Unsupported encoding: {encoding}")
            };
        }

        /// <summary>
        /// Gets the current encoding instance.
        /// </summary>
        public static Encoding GetEncoding() => _currentEncoding;

        /// <summary>
        /// Gets a specific encoding instance.
        /// </summary>
        public static Encoding GetEncoding(TextEncoding encoding)
        {
            return encoding switch
            {
                TextEncoding.ShiftJIS => Encoding.GetEncoding("shift_jis"),
                TextEncoding.GBK => Encoding.GetEncoding("gbk"),
                _ => throw new ArgumentException($"Unsupported encoding: {encoding}")
            };
        }
    }
}
