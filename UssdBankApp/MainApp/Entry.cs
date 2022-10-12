using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UssdBankApp.UI;

namespace UssdBankApp.MainApp
{
    class Entry
    {
        static void Main(string[] args)
        {
            
            AtmApp atmApp = new AtmApp();
            atmApp.InitializeData();
            atmApp.Run();

            

        }
    }
}
