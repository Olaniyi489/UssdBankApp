﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UssdBankApp.UI
{
    public static class Utilities
    {
        private static CultureInfo culture = new CultureInfo("IG-US");
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);
                isPrompt = false;
                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length == 6)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\nPlease enter 6 digits.", false);
                        isPrompt = true;
                        input.Clear();
                        continue;
                        
                    }

                }
                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write(asterics + "*");
                }
            }
            return input.ToString();
        }
        public static void favColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void PrintMessage(string msg, bool success = true)
            {
                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(msg);
                //Console.ResetColor();
                 favColor();
                // PressEnterContinue();

            }
            public static string GetUserInput(string prompt)
            {
                Console.WriteLine($"Enter {prompt}");
                return Console.ReadLine();
            }

            public static void PrintDotAnimation(int timer = 10)
            {

                for (int i = 0; i < timer; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(200);
                }
                Console.Clear();

            }
            public static void PressEnterContinue()
            {
                Console.WriteLine("\n\nPress Enter to continue....\n");
                Console.ReadLine();
            }
            
            public static string FormatAmount(decimal amt)
            {
                return String.Format(culture, "{0:C2}", amt);
            }
        
    }
}

