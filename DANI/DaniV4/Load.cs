using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DaniV4
{
    class Load:Program
    {
        string[] dirs = null;
        static string path = Directory.GetCurrentDirectory() + "\\";//Get current directory folder
        public Load()
        {
            try
            {
                dirs = Directory.GetFiles(path, "*.txt");//Get all the files ending with .txt and save location into dirs array
                Console.WriteLine("\nThe Files Saved:");
                
                foreach (string directory in dirs)
                {
                    Console.WriteLine(directory.Substring(path.Length));//Print all the file names available
                }

                Readfile(dirs);//Call the method Readfile with the dirs array as parameter
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());//if cannot get current directory
            }
        }
        
        static void Readfile(string[] dirs)
        {
            if (dirs[0] == "")
            {
                Console.WriteLine("\nThere are no files present");
                Console.ReadLine();
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("\nWhat File Would You Like To Load? (ie save.txt)");
                    string LoadingFile = path + Console.ReadLine();

                    if (LoadingFile.IndexOf(".txt") == -1)//If user didnt input ending to file
                    {
                        LoadingFile = LoadingFile + ".txt";//Add .txt to the file name
                    }

                    bool found = false;
                    //Look for the file in dirs array
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        if (dirs[i] == LoadingFile)
                        {
                            found = true;
                        }
                    }

                    if (found == true)
                    {
                        string[] loadArray = File.ReadAllLines(LoadingFile);//read all the lines in the file into loadArray
                        int numLines = 0;
                        for (int add = 0; add < loadArray.Length; add++)
                        {
                            numLines++;
                            Words word = new Words();
                            word.Word = loadArray[add];
                            if (loadArray[add].IndexOf("*index list*") == -1)//check if the words are finished (Save class will explain this)
                            {
                                list.Add(word);//Add word to the list
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int i = numLines + 1; i < loadArray.Length; i++)
                        {
                            foundlist.Add(loadArray[i]);//now add the indexs into the foundlist
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("File Not Found!");
                    }
                }
            }
        }
    }
}
