using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution
{
    public abstract class RandomFileGenerator
    {
        private readonly string workingDirectory;

        private readonly string fileExtension;

        protected RandomFileGenerator(string workingDirectory, string fileExtension)
        {
            this.workingDirectory = workingDirectory;
            this.fileExtension = fileExtension;
        }
        
        public string WorkingDirectory => workingDirectory;

        public string FileExtension => fileExtension;

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);
                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);
        protected abstract void WriteBytesToFile(string fileName, byte[] content);
    }


    public class RandomCharsFileGenerator : RandomFileGenerator
    {
        public RandomCharsFileGenerator() : base("Files with random chars", ".txt") { }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        protected override void WriteBytesToFile(string fileName, byte[] content)
        {
            if (Directory.Exists(WorkingDirectory) == false)
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }

    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        public RandomBytesFileGenerator() : base("Files with random bytes", ".txt") { }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }


        protected override void WriteBytesToFile(string fileName, byte[] content)
        {
            if (Directory.Exists(WorkingDirectory) == false)
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
