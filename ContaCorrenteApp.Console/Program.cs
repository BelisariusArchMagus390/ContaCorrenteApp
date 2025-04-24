namespace ContaCorrenteApp.Console
{
    using System;
    internal class Program
    {
        static Menu menu = new Menu();
        static Input input = new Input();
        static Dictionary<int, CheckingAccount> accountList = new Dictionary<int, CheckingAccount>();
        static CheckingAccount generalAccount = new CheckingAccount();
        static void Main(string[] args)
        {
            bool ifExit = false;
            while(ifExit == false)
            {
                Console.Clear();

                menu.showMenuManagementAccounts();
                char option = Console.ReadLine()[0];

                switch (option)
                {
                    case '1':
                        createAccount();
                        break;

                    case '2':
                        enterAccount();
                        operationsAccount();
                        break;

                    case '3':
                        listCreatedAccounts();
                        break;

                    case '4':
                        ifExit = true;
                        break;

                    default:
                        input.showErrorMessage(" Essa opção não existe.");
                        break;
                }   
            }
        }

        static int createIdAccount()
        {
            Random randomId = new Random();
            int id = 0;

            while (true)
            {
                id = randomId.Next(100, 200);

                bool equal = false;
                foreach (var i in accountList)
                {
                    if (i.Value.IdAccount == id)
                        equal = true;
                }

                if (equal == false)
                    break;
            }
            return id;
        }

        static void createAccount()
        {
            CheckingAccount account = new CheckingAccount();

            Console.Clear();
            Console.Write("\n Nome do usuário da conta: ");
            account.UserName = Console.ReadLine();

            account.Balance = input.verifyDoubleValue("\n Saldo da conta: ");
            account.DebitLimit = input.verifyDoubleValue("\n Limite da conta: ");

            int id = createIdAccount();
            account.IdAccount = id;

            accountList.Add(account.IdAccount, account);

            Console.Clear();
            Console.WriteLine(" \n Conta criada com sucesso!");
            Console.WriteLine($"\n Nome do usuário da conta: {account.UserName}");
            Console.WriteLine($" Id da conta: {id}");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        static void listCreatedAccounts()
        {
            Console.Clear();
            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine("\n LISTA DE CONTAS CRIADAS");
            Console.WriteLine("\n ---------------------------------------\n");

            foreach (var account in accountList)
            {
                Console.WriteLine($" Nome: {account.Value.UserName}  ID: {account.Key}");
            }

            Console.WriteLine("\n ---------------------------------------");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        static void enterAccount()
        {
            while (true)
            {
                int id = input.verifyIntValue("\n Entre com o ID da conta: ");

                if (accountList.TryGetValue(id, out generalAccount))
                {
                    break;
                }
                else
                    input.showErrorMessage(" Essa conta não existe.");
            }
        }

        static CheckingAccount findAccount(CheckingAccount tranferenceAccount)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\n Entre com o ID da conta que fará a transferência: ");
                int id = int.Parse(Console.ReadLine());

                if (accountList.TryGetValue(id, out tranferenceAccount))
                {
                    break;
                }
                else
                    input.showErrorMessage(" Essa conta não existe.");
            }

            return tranferenceAccount;
        }

        static void operationsAccount()
        {
            bool ifExit = false;
            while (ifExit == false)
            {
                Console.Clear();

                menu.showMenuAccount(generalAccount);
                char option = Console.ReadLine()[0];

                switch (option)
                {
                    case '1':
                        Console.Clear();
                        double valueWithdraw = input.verifyDoubleValue("\n Digite o valor a ser sacado: ");
                        generalAccount.withdraw(valueWithdraw);
                        break;

                    case '2':
                        Console.Clear();
                        double valueDeposit = input.verifyDoubleValue("\n Digite o valor a ser depositado: ");
                        generalAccount.deposit(valueDeposit);
                        break;

                    case '3':
                        Console.Clear();
                        generalAccount.showBalance();
                        Console.WriteLine("\n Aperte ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case '4':
                        Console.Clear();
                        generalAccount.showStatement();
                        Console.WriteLine("\n Aperte ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case '5':
                        Console.Clear();
                        CheckingAccount tranferenceAccount = new CheckingAccount();
                        tranferenceAccount = findAccount(tranferenceAccount);

                        Console.Clear();
                        double valueTransference = input.verifyDoubleValue($"\n Digite o valor a ser transferido para {tranferenceAccount.UserName}: ");
                        generalAccount.transfereTo(tranferenceAccount, valueTransference);
                        break;

                    case '6':
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
