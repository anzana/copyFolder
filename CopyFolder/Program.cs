using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFolder
{
    class CopyOneFolderToAnother
    {
        static void Main()
        {
            Console.WriteLine("How many files you want to copy?");
            int num =  Convert.ToInt32(Console.ReadLine());
            List<string> source = new List<string>();

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter Source Path: ");
                source.Add(Console.ReadLine()); 
            }

            Console.WriteLine("Enter Destination Path: ");
            string dest = Console.ReadLine();

            Copy(source, dest);
            Console.WriteLine("\r\nEnd of program");
            Console.ReadKey();
        }

        public static void Copy(List<string> pathList, string destDirectory)
        {
            string sourceDirectory;


            DirectoryInfo dirSource;
            DirectoryInfo dirTarget = new DirectoryInfo(destDirectory);

            for (int i = 0; i < pathList.Count; i++)
            {
                sourceDirectory = pathList.ElementAt(i);
                
                dirSource = new DirectoryInfo(sourceDirectory);

                CopyAll(dirSource, dirTarget);
            }

        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo dest)
        {
            if (!dest.Exists)
            {
                try
                {
                    Directory.CreateDirectory(dest.FullName);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            try
            {
                foreach (FileInfo fi in source.GetFiles()) // returns a file list from the current directory 
                {
                    Console.WriteLine(@"Copying {0}\{1}", dest.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(dest.FullName, fi.Name), true);
                }

                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) //GetDirectories returns the subdirectories of the current directory
                {
                    DirectoryInfo nextDestSubDir = dest.CreateSubdirectory(diSourceSubDir.Name); // create a subdirectory or subdirectories on the specified path
                    CopyAll(diSourceSubDir, nextDestSubDir);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }
}
