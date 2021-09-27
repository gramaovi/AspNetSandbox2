using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class FileOperationWithBooks
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("README.md", @"Hello");
        }

        [Fact]
        public void AppendFileTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var path = directoryInfo.Parent.Parent.Parent.Parent.ToString();
            var imgpath = path + "\\Image\\picture.png";
            Console.WriteLine(path);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "README.md"), true))
            {
                outputFile.WriteLine(@"![img](Image/picture.png)");
            }
        }

        [Fact]
        public void ReadFilesTest()
        {
            // Not working on git because file is ignored
            /*
            using (var fileStream = File.OpenRead("netSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fileStream.Read(b, 0, b.Length) > 0)
                {
                    var returnedString = temp.GetString(b);
                    Console.WriteLine(returnedString);
                }
            }
            */
        }
    }
}
