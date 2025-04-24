namespace ContaCorrenteApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    internal class Menu
    {
        public void showErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine($"\n Erro! {message}");
            Console.WriteLine(" Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void showMenuManagementAccounts()
        {
            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine(" GESTÃO DE CONTA CORRENTE");
            Console.WriteLine("\n ---------------------------------------");

            Console.WriteLine(" 1 - Criar nova conta corrente");
            Console.WriteLine(" 2 - Entrar em conta corrente");
            Console.WriteLine(" 3 - Sair");
            Console.WriteLine("\n Escolha uma das opções acima: ");
        }

        public void showMenuAccount(CheckingAccount account)
        {
            string userName = account.UserName.ToUpper();

            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine($" CONTA CORRENTE DE {userName}");
            Console.WriteLine($" ID: {account.IdAccount}");
            Console.WriteLine("\n ---------------------------------------");

            Console.WriteLine(" 1 - Saque");
            Console.WriteLine(" 2 - Depósito");
            Console.WriteLine(" 3 - Consulta de saldo");
            Console.WriteLine(" 4 - Emissão de extrato");
            Console.WriteLine(" 5 - Transferência");
            Console.WriteLine(" 6 - Sair");
            Console.WriteLine("\n Escolha uma das opções acima: ");
        }
    }
}
