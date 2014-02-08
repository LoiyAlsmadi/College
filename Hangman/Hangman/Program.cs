using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Words word = new Words();
                int q = 0;
                string[] lines = System.IO.File.ReadAllLines("text.txt");
                word.Guess = new string[lines.Length];
                foreach (string line in lines)
                {
                    word.Guess[q] = line;
                    q++;
                }

                Random random = new Random();
                int randomNumber = random.Next(0, 100);

                word.Under = new string[word.Guess[randomNumber].Length];

                for (int i = 0; i < word.Guess[randomNumber].Length; i++)
                {
                    word.Under[i] = "_";
                }

                int lives = 6;
                int num = 0;
                int z = 0;
                string quit;
                string[] wrong = new string[7];

                Console.WriteLine("\nDo you wan to play? y/n");
                quit = Console.ReadLine().ToLower();

                if (quit == "n")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (quit == "y")
                {
                    Console.Clear();
                    while (lives != 0)
                    {
                        Console.Write("\n---------------------------------");
                        Console.Write("\nThe word: ");
                        for (int k = 0; k < word.Guess[randomNumber].Length; k++)
                        {
                            Console.Write(word.Under[k] + ",");
                        }
                        Console.WriteLine("\nLives Left: " + lives);
                        Console.Write("\nLetters Guessed Wrong: ");
                        for (int l = 0; l < 7; l++)
                        {
                            Console.Write(wrong[l] + ",");
                        }
                        Console.WriteLine("\nPlease enter in a letter:");

                        string letter = Console.ReadLine().ToLower();
                        bool found = false;

                        if (word.Guess[randomNumber] == letter)
                        {
                            found = true;
                        }
                        else
                        {
                            int ind = 0;

                            foreach (string check in word.Under)
                            {
                                if (check == letter)
                                {
                                    ind = 1;
                                }
                            }
                            foreach (string check2 in wrong)
                            {
                                if (check2 == letter)
                                {
                                    ind = 1;
                                }
                            }

                            if (ind == 0)
                            {
                                int index = word.Guess[randomNumber].IndexOf(letter);
                                if (index == -1)
                                {
                                    Console.WriteLine("\nNot Found");
                                    wrong[z] = letter;
                                    z++;
                                    lives = lives - 1;
                                }
                                else
                                {
                                    int j = 0;

                                    while ((j = word.Guess[randomNumber].IndexOf(letter, j)) != -1)
                                    {
                                        word.Under[j] = letter;
                                        j++;
                                        num++;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nletter already entered");
                            }
                        }

                        if (num == word.Guess[randomNumber].Length || found==true)
                        {
                            Console.WriteLine("\nCongrats! You Won!");
                            Console.Write("The Word Was: " + word.Guess[randomNumber]);
                            break;
                        }
                        else if (lives == 0)
                        {
                            Console.WriteLine("\nSorry You Lost!");
                            Console.Write("The Word Was: " + word.Guess[randomNumber]);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nWrong Input!");
                }
            }

            Console.ReadLine();
        }
    }
}
