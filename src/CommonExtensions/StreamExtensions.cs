using System.IO;

namespace CommonExtensions
{
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public static Stream StringToStream(this string inputString)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(inputString);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        public static string StreamToString(this Stream input)
        {
            // convert stream to string
            input.Position = 0;
            StreamReader reader = new StreamReader(input);
            string text = reader.ReadToEnd();
            return text;
        }

    }
}
