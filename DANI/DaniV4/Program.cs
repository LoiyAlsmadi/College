using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace DaniV4
{
    class Program
    {
        static public List<Words> list = new List<Words>();
        static public List<string> foundlist = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                //Create Menu for user
                Console.WriteLine("Press:\nD => Talk To DANI \nE => To Exit\n");
                string talk = Console.ReadLine();//Read user input

                if (talk == "d" || talk == "D")
                {
                    //Clear screen
                    Console.Clear();
                    Console.WriteLine("LOAD (y or n)");
                    string load = Console.ReadLine();

                    if (load == "Y" || load == "y")
                    {
                        Load loadFile = new Load();
                    }

                    //Call method Play()
                    Play();
                }
                else if (talk == "e" || talk == "E")
                {
                    //Exit
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        //Implement method Play()
        static void Play()
        {
            //Clear screen
            Console.Clear();
            bool tts = false;//text to speech
            Console.WriteLine("To exit at any time type in 'quit'");
            Console.WriteLine("To turn on TTS type 'ttson', to turn off type 'ttsoff'");
            Console.Write("\nDani: hello im dani");
            while (true)
            {
                Console.Write("\nUser: ");
                string line = Console.ReadLine().ToLower();//Read user input
                if (line.IndexOf("quit") != -1)
                {
                    //If user types quit then exit to main menu
                    Exit exit = new Exit();
                    break;
                }
                else if (line.IndexOf("ttson") != -1)
                {
                    tts = true;
                }
                else if (line.IndexOf("ttsoff") != -1)
                {
                    tts = false;
                }
                else
                {
                    string[] array = line.Split(' ');//split the string line into an array

                    for (int i = 0; i < array.Length; i++)//iterate through array
                    {
                        //Create new word
                        Words word = new Words();
                        word.Word = array[i];//copy contents of array[i] to word.Word

                        if (list.Exists(x => x.Word == word.Word) == false) // Check if word doesn't exist in list.
                        {
                            list.Add(word);//Add word to list
                            string wordIndex = list.IndexOf(word).ToString();//Find index of word in list
                            foundlist.Add(wordIndex);//Add the index to the foundlist

                            //Call method IndexNextWord(word, array, i) with arguments
                            IndexNextWord(word, array, i);
                        }
                        else // if word exists 
                        {
                            //Call method IndexNextWord(word, array, i) with arguments
                            IndexNextWord(word, array, i);
                        }
                    }

                    //Call the method Display()
                    Display(tts);
                }
            }
        }

        //Implement the method IndexNextWord()
        static void IndexNextWord(Words word, string[] array, int i)
        {
            int index = 0;
            //Get the index of found word
            for (int j = 0; j < list.Count(); j++)
            {
                if (list[j].ToString() == word.Word)
                {
                    index = j;
                }
            }

            if ((i + 1) < array.Count())//if there is a word after the current word
            {
                i = i + 1;//next word
                word.Word = array[i].ToLower();//copy contents of array[i] to word.Word
                if (list.Exists(x => x.Word == word.Word) == false) //Check if word doesn't exist in list.
                {
                    list.Add(word);//Add word to list
                    string wordIndex = list.IndexOf(word).ToString();//Find index of word in list
                    foundlist.Add(wordIndex);//Add the index to the foundlist
                }

                //Find index of where the next word is stored in the list
                string foundIndex = "";
                for (int j = 0; j < list.Count(); j++)
                {
                    if (list[j].ToString() == word.Word)
                    {
                        foundIndex = j.ToString();
                    }
                }

                foundlist[index] = foundlist[index] + "," + foundIndex;
                //Add the index of next word to the word found in the foundlist 
                //ie 1,6 where 1 is index of found word and 6 is index of next word
            }
        }

        //Implement the method Display()
        static void Display(bool tts)
        {
            Words word = new Words();
            Random random = new Random();
            int randomNumber = 0;
            string display = "";

            randomNumber = random.Next(0, list.Count());//Get random number between 0 to list.count()
            display = list[randomNumber].ToString();//Using the randomNumber as index, copy the word into display

            //Copy randomNumber to num
            int num = randomNumber;

            while (true)
            {
                //Create temparry to store the indexs
                string[] temparray = null;
                temparray = foundlist[num].Split(',');//Using the num as index, copy contents to temparry, splitting at ','

                //Check if the word has a link to another word
                //If the is 2 or more numbers in temparray, because the first number is the index of the intial word
                if (temparray.Count() >= 2)
                {
                    int randomIndex = random.Next(1, temparray.Count());//Get random number between 0 to temparray.count()
                    int numberIndex = int.Parse(temparray[randomIndex]);//using randomIndex as an index, copy number in temparray to numberIndex (parsing it to an int)

                    if (display.IndexOf(list[numberIndex].ToString()) == -1)
                    {
                        display = display + " " + list[numberIndex];//Add next word to display
                    }

                    num = numberIndex;//make num equal to numberIndex, and when while loop repeats the above gets executed again
                }
                else//if not then break;
                {
                    break;
                }
            }
            
            Console.Write("Dani: ");
            Console.Write(display);//Output the final string

            Speak(display, tts);
        }

        //Implement method Speak()
        static void Speak(string display, bool speak)
        {
            if (speak == true)
            {
                //Initialize a new instance of the SpeechSynthesizer.
                SpeechSynthesizer synth = new SpeechSynthesizer();

                //Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();
                synth.Rate = 0;
                synth.SpeakAsync(display);
            }
        }
    }
}
