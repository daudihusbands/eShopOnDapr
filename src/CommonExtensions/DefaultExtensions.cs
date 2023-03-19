using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace CommonExtensions
{
    public static class DefaultExtensions
    {

        /// <summary>
        /// Deserializes the file resource.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="sourceType">Type from the source assembly.</param>
        /// <param name="resourceFileName">Name of the resource file.</param>
        /// <para name="afterDeserialize">Action to perform after deserialization.</para>
        /// <returns></returns>
        public static Stream GetResourceAsStream(string resourceFileName, Assembly assembly)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            //Get the correct resource with "Ends With" 
            var resName = resourceNames.FirstOrDefault(e =>
                e.EndsWith(resourceFileName, StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(resName))
            {
                Debug.WriteLine("Resource file {0} not found.", resName);
                throw new InvalidOperationException($"The specified resource entry [{resourceFileName}] was not found in the assembly {assembly.GetName().Name}.");
            }

            var memStream = new MemoryStream();
            using (Stream str = assembly.GetManifestResourceStream(resName))
            {
                str.CopyTo(memStream);
            }

            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }

        public static Stream GetFileAsStream(string resourceFileName, Assembly assembly)
        {


            var memStream = new MemoryStream();
            var files = assembly.GetManifestResourceNames();
            using (Stream str = assembly.GetFile(resourceFileName))
            {
                str.CopyTo(memStream);
            }

            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }

        public static Stream GetResourceFromZipFileAsStream(string zipFileName, string entryName, Assembly assembly)
        {
            var fileStream = GetResourceAsStream(zipFileName, assembly);
            var archive = new ZipArchive(fileStream, ZipArchiveMode.Read);
            var fileEntry = archive.Entries.FirstOrDefault(e => e.Name == entryName);

            var stream = fileEntry.Open();
            var mem = new MemoryStream();
            stream.CopyTo(mem);

            mem.Seek(0, SeekOrigin.Begin);

            return mem;

        }

        public static string GetResourceFromZipFileAsString(string zipFileName, string entryName, Assembly assembly)
        {
            var fileStream = GetResourceFromZipFileAsStream(zipFileName, entryName, assembly);
            return fileStream.StreamToString();

        }
    }
}
