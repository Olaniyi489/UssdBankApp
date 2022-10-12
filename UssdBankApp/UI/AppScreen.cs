using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UssdBankApp.Domain.Entities;

namespace UssdBankApp.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
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
            Console.WriteLine("\nChecking card number and PIN...");
            Utilities.PrintDotAnimation();
            //AppScreen.LoginProgress();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utilities.PrintMessage("Your account is locked. please visit the nearest branch to unlock your account. Thank you.", true);
            Utilities.PressEnterContinue();
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
    } 
}
