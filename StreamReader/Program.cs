using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streams
{
    class Program
    {
        static string filePath;
        static string path;

        static void Main(string[] args)
        {
            //createFolder();
            writeToFile();
            readFromFile();
            getAllFiles();
            Console.WriteLine();
            getDirectories();
            getFileNames();


                Console.ReadKey();

        }

        static string createName()
        {
            string fileNameFull = Path.GetRandomFileName();
            string[] name = fileNameFull.Split('.');
            return name[0];
        }

        static string createFolder()
        {
            string fileName = createName();
            fileName += ".txt";
            
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(folderPath, "test");
            Directory.CreateDirectory(path);

            filePath = Path.Combine(path, fileName);

            Console.WriteLine(filePath);

            return filePath;
        }

        static void writeToFile()
        {
            using (StreamWriter writer = File.CreateText(createFolder()))
            {
                writer.WriteLine("Eerste regel");
                writer.WriteLine("Tweede regel");
            }
        }

        static void readFromFile()
        {
            string content;
            using (StreamReader reader = File.OpenText(filePath))
            {
                content = reader.ReadToEnd();
            }

            Console.WriteLine(content);
        }

        static void getAllFiles()
        {
            string[] files = Directory.GetFiles(path);

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
        }

        static void getDirectories()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] directories = Directory.GetDirectories(path);

            foreach (var item in directories)
            {
                Console.WriteLine(item);
            }
        }

        static void getFileNames()
        {

            var filenames = Directory.GetFiles(path).Select(Path.GetFileName);
            foreach (var item in filenames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
