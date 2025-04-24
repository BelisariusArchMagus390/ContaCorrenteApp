namespace ContaCorrenteApp.Console
{
    using System;
    internal class Program
    {
        static CheckingAccount account = new CheckingAccount();
        static Menu menu = new Menu();
        static Input input = new Input();
        static Dictionary<string, CheckingAccount> accountList = new Dictionary<string, CheckingAccount>();
        static void Main(string[] args)
        {
            bool ifExit = false;
            while(ifExit == false)
            {
                menu.showMenuManagementAccounts();
                char option = Console.ReadLine()[0];

                switch (option)
                {
                    case '1':
                        
                        break;

                    case '2':

                        break;

                    case '3':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }   
            }
        }

        
    }
}
