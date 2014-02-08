using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DaniV4
{
    class Exit:Program
    {
        string[] dirs = null;
        string path = Directory.GetCurrentDirectory() + "\\";
        public Exit()
        {
            Console.Clear();
            Console.WriteLine("SAVE (y or n)");
            string save = Console.ReadLine();

            if (save == "Y" || save == "y")
            {
                try
                {
                    dirs = Directory.GetFiles(path, "*.txt");//Get all the files ending with .txt and save location into dirs array
                    Console.WriteLine("\nThe Files Saved:");
                    foreach (string directory in dirs)
                    {
                        Console.WriteLine(directory.Substring(path.Length));//Print all the files availabe
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());//if cannot get current directory
                }

                Save(dirs);
            }
            else if (save == "N" || save == "n")
            {
                Console.WriteLine("Goodbye!");
            }
        }

        static void Save(string[] dirs)
        {
            while (true)
            {
                string FileUsed = Directory.GetCurrentDirectory() + "\\"; //Get the path location of current directory
                bool found = false;
                Console.WriteLine("\nFile Name? ie save.txt");
                FileUsed = FileUsed + Console.ReadLine();//Add the file name

                if (FileUsed.IndexOf(".txt") == -1)//If user didnt input ending to file
                {
                    FileUsed = FileUsed + ".txt";//Add .txt to the file name
                }

                //Look for FileUsed path in dirs array
                for (int i = 0; i < dirs.Length; i++)
                {
                    if (dirs[i] == FileUsed)
                    {
                        found = true;
                    }
                }

                bool overWrite = true;
                if (found == true)
                {
                    Console.WriteLine("\nFile Name Already Used! Overwrite? Y/N");
                    string write = Console.ReadLine();
                    if (write == "y" || write == "Y")
                    {
                        overWrite = true;
                    }
                    else
                    {
                        overWrite = false;
                    }
                }

                bool arg = false;
                if (overWrite == true)
                {
                    arg = false;
                }
                else
                {
                    FileUsed = Directory.GetCurrentDirectory() + "\\"; //Get the path location of current directory
                    Console.WriteLine("Saving To New File! New File Name?");
                    FileUsed = FileUsed + Console.ReadLine();//Add the file name

                    if (FileUsed.IndexOf(".txt") == -1)//If user didnt input ending to file
                    {
                        FileUsed = FileUsed + ".txt";//Add .txt to the file name
                    }
                }
                
                //Using StreamWriter write to a text file (FileUsed)
                //The false argument indicates to overwrite the text file
                using (StreamWriter file = new StreamWriter(FileUsed, arg))
                {
                    //write all the words in the list to the file
                    foreach (Words w in list)
                    {
                        file.WriteLine(w);
                    }
                    //then set a break to differetiate between the lists
                    file.WriteLine("*index list*");
                    //then write all the indexs to the file
                    for (int x = 0; x < foundlist.Count(); x++)
                    {
                        file.WriteLine(foundlist[x]);
                    }
                }
                break;
            }
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
    }
}
