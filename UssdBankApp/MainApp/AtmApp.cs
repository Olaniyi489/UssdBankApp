using System;
using System.Collections.Generic;
using System.Threading;
using UssdBankApp.Domain.Entities;
using UssdBankApp.Domain.Enums;
using UssdBankApp.Domain.Interfaces;
using UssdBankApp.UI;

namespace UssdBankApp.MainApp 
{
   public class AtmApp:IUserLogin,IUserAccountActions
   {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void Run()
        {
            AppScreen.Welcome();
            CheckUserIdAndPassword();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);
            AppScreen.DisplayAppMenu();
            ProcessMenuOption();
        }
        public void InitializeData() 
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id=1, FullName = "Salami Waris", AccountNumber= 308088, UserId=155666, CardPin=252525, /*TotalLogin=3,*/ AccountBalance=5000.00m, IsLocked=false},
                new UserAccount{Id=2, FullName = "Babatunde Oloja", AccountNumber=203065, UserId=157654, CardPin=252566,/* TotalLogin=3,*/ AccountBalance=10000.00m, IsLocked=false},
                new UserAccount{Id=3, FullName = "John Salako", AccountNumber= 319765, UserId=145276, CardPin=252983,/* TotalLogin=3,*/ AccountBalance=700.00m, IsLocked=true},
            };
        }
        
        public void CheckUserIdAndPassword()
        {
            bool isCorrectLogin = false;
            while(isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach(UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.UserId.Equals(selectedAccount.UserId))
                    {
                        selectedAccount.TotalLogin++;

                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if(selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                            
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utilities.PrintMessage("\n Invalid card number or Pin.", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }

                    }
                    Console.Clear();


                }

            }

        }

        private void ProcessMenuOption()
        {
            switch(Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.CheckBalance:
                    Console.WriteLine("Checking account balance...");
                    break;
                case (int)AppMenu.PlaceDepsoit:
                    Console.WriteLine("Placing deposit...");
                    break;
                case (int)AppMenu.MakeWithdrawal:
                    Console.WriteLine("Making withdrawal...");
                    break;
                case (int)AppMenu.InternalTranfer:
                    Console.WriteLine("Making internal transfer...");
                    break;
                case (int)AppMenu.ViewTransaction:
                    Console.WriteLine("Viewing transactions...");
                    break;
                case (int)AppMenu.Logout:
                    AppScreen.LogOutProcess();
                    Utilities.PrintMessage("You have successfully logged out. " +
                       "Please Protect your UserId to avoid unauthorize withdrawal.");
                    Run();
                    break;
                default:
                    Utilities.PrintMessage("Invalid Option.", false);
                    break;
            }
        }

        public void CheckBalance()
        {
            Utilities.PrintMessage($"Your account balance is: {selectedAccount.AccountBalance}");
        }
         public void PlaceDeposit()
        {

        }
         public void MakeWithDrawal()
        {

        }

   }
}
        