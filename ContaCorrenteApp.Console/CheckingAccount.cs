namespace ContaCorrenteApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    internal class CheckingAccount
    {
        public string UserName { get; set; }
        public double Balance { get; set; }
        public int IdAccount { get; set; }
        public double DebitLimit { get; set; }
        static public List<Transactions> TransactionList { get; set; }

        public CheckingAccount()
        {
            List<Transactions> TransactionList = new List<Transactions>();
        }

        private double sumDebit()
        {
            double result = 0;

            foreach (Transactions t in TransactionList)
            {
                if (t.Transaction < 0)
                    result += Math.Abs(t.Transaction);
            }
            return result;
        }

        public void withdraw(double withdraw)
        {
            if (DebitLimit == 0 || sumDebit() < DebitLimit)
            {
                Transactions t = new Transactions();
                Balance -= withdraw;

                t.Transaction = -withdraw;
                t.Date = DateTime.Now.ToString("dd/MM/yyyy");
                t.Time = DateTime.Now.ToString("HH:mm:ss tt");
                TransactionList.Add(t);
            }
        }

        public void deposit(double deposit)
        {
            Transactions t = new Transactions();
            Balance += deposit;

            t.Transaction = deposit;
            t.Date = DateTime.Now.ToString("dd/MM/yyyy");
            t.Time = DateTime.Now.ToString("HH:mm:ss tt");
            TransactionList.Add(t);
        }

        public void transfereTo(CheckingAccount account, double transference)
        {
            Transactions t = new Transactions();
            account.Balance += transference;
            Balance -= transference;

            t.Transaction = -transference;
            t.Date = DateTime.Now.ToString("dd/MM/yyyy");
            t.Time = DateTime.Now.ToString("HH:mm:ss tt");
            TransactionList.Add(t);
        }

        public void showBalance()
        {
            Console.WriteLine(" \n------------------------------");
            Console.WriteLine($"\n Saldo em conta: {Balance}");
            Console.WriteLine("\n ------------------------------");
        }

        // Mostra o extrato
        public void showStatement()
        {
            // Mostra os débitos
            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine(" DÉBITOS");
            Console.WriteLine("\n ---------------------------------------");

            foreach (Transactions t in TransactionList)
            {
                if (t.Transaction < 0)
                {
                    Console.WriteLine($" {t.Date} {t.Time}: {t.Transaction}");
                } 
            }

            Console.WriteLine("\n ---------------------------------------");

            // Mostra entrada de crédito
            Console.WriteLine("\n ---------------------------------------");
            Console.WriteLine(" ENTRADA DE CRÉDITO");
            Console.WriteLine("\n ---------------------------------------");

            foreach (Transactions t in TransactionList)
            {
                if (t.Transaction > 0)
                {
                    Console.WriteLine($" {t.Date} {t.Time}: {t.Transaction}");
                }
            }

            Console.WriteLine("\n ---------------------------------------");
        }
    }
}
