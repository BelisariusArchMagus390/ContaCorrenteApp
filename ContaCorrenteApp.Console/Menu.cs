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
        public void showMenuManagementAccounts()
        {
            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine("\n GESTÃO DE CONTA CORRENTE");
            Console.WriteLine("\n ---------------------------------------");

            Console.WriteLine("\n 1 - Criar nova conta corrente");
            Console.WriteLine(" 2 - Entrar em conta corrente");
            Console.WriteLine(" 3 - Listar contas criadas");
            Console.WriteLine(" 4 - Sair");
            Console.Write("\n Escolha uma das opções acima: ");
        }

        public void showMenuAccount(CheckingAccount account)
        {
            string userName = account.UserName.ToUpper();

            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine($"\n CONTA CORRENTE DE {userName}");
            Console.WriteLine($" ID: {account.IdAccount}");
            Console.WriteLine("\n ---------------------------------------");

            Console.WriteLine("\n 1 - Saque");
            Console.WriteLine(" 2 - Depósito");
            Console.WriteLine(" 3 - Consulta de saldo");
            Console.WriteLine(" 4 - Emissão de extrato");
            Console.WriteLine(" 5 - Transferência");
            Console.WriteLine(" 6 - Sair");
            Console.Write("\n Escolha uma das opções acima: ");
        }
    }
}
