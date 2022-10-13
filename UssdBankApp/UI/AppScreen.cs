using AtmApp.Domain.Entities;
using UssdBankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;   
using UssdBankApp.Domain.Entities;

namespace UssdBankApp.UI
{
    public static class AppScreen
    {
        public const string cur = "N ";
        public static void Welcome()
        {
            // clears the console screen m
            Console.Clear();

            // sets the title of the console window
            Console.Title = "My Atm App";
            // set the text color or foreground color to cyan
            Console.ForegroundColor = ConsoleColor.Cyan;


            //set the welcome messagem
            Console.WriteLine("\n\n**************** Welcome To My Atm App *******************\n");

            Console.WriteLine("Please enter your User Id");
            Console.WriteLine("Note: Actual Atm machine will accept and validate physical Atm Card read card number and validate it.");

            Utilities.PressEnterContinue();
        }
        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.UserId = Validator.Convert<long>("Your UserId");
            tempUserAccount.CardPin = Convert.ToInt32(Utilities.GetSecretInput("Enter your card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking User Id and PIN...");
            Utilities.PrintDotAnimation();
            
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utilities.PrintMessage("Your account is locked. please visit the nearest branch to unlock your account. Thank you.", true);
           // Utilities.PressEnterContinue();
            Environment.Exit(1);
        }

        internal static void WelcomeCustomer(string fullname)
        {
            Console.WriteLine($"Welcome back,{fullname}");
            Utilities.PressEnterContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("******* My Atm App Menu *******");
            Console.WriteLine(":                             :");
            Console.WriteLine("1. Account Balance            :");
            Console.WriteLine("2. Cash Deposit               :");
            Console.WriteLine("3. Withdrawal                 :");
            Console.WriteLine("4. Transfer                   :");
            Console.WriteLine("5. Transactions               :");
            Console.WriteLine("6. Logout                     :");
        }

        internal static void LogOutProcess()
        {
            Console.WriteLine("Thank you for using My Atm App.");
            Utilities.PrintDotAnimation();
            //Utilities.PrintMessage("You have successfully logged out. " +
            //            "Please Protect your UserId to avoid unauthorize withdrawal.");
            Console.Clear();
        }

          internal static int SelectAmount()
        {
            Console.WriteLine("");
            Console.WriteLine(":1.{0}500      5.{0}10,000", cur);
            Console.WriteLine(":2.{0}1000     6.{0}15,000", cur);
            Console.WriteLine(":3.{0}2000     7.{0}20,000", cur);
            Console.WriteLine(":4.{0}5000     8.{0}40,000", cur);
            Console.WriteLine(":0.Other");
            Console.WriteLine("");

            int selectedAmount = Validator.Convert<int>("option:");
            switch (selectedAmount)
            {
                case 1:
                    return 500;
                    break;
                case 2:
                    return 1000;
                    break;
                case 3:
                    return 2000;
                    break;
                case 4:
                    return 5000;
                    break;
                case 5:
                    return 10000;
                    break;
                case 6:
                    return 15000;
                    break;
                case 7:
                    return 20000;
                    break;
                case 8:
                    return 40000;
                    break;
                case 0:
                    return 0;
                    break;
                default:
                    Utilities.PrintMessage("Invalid input. Try again.", false);
                    return -1;
                    break;
            }
          }

           internal InternalTransfer InternalTransferForm()
        {
            var internalTransfer = new InternalTransfer();
            internalTransfer.ReciepeintBankAccountNumber = Validator.Convert<long>("recipient's account number:");
            internalTransfer.TransferAmount = Validator.Convert<decimal>($"amount {cur}");
            internalTransfer.RecipientBankAccountName = Utilities.GetUserInput("recipient's name:");
            return internalTransfer;
        }  
    } 
}
