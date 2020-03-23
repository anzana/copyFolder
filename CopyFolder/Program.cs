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
            //string source = @"C:\Users\James\Desktop\Danphe\source";
            //string dest = @"C:\Users\James\Desktop\Danphe\destination";
            Console.WriteLine("Enter Source Path: ");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination Path: ");
            string dest = Console.ReadLine();

            Copy(source, dest);
            Console.WriteLine("\r\nEnd of program");
            Console.ReadKey();
        }

        public static void Copy(string sourceDirectory, string destDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diDest = new DirectoryInfo(destDirectory);

            CopyAll(diSource, diDest);
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
