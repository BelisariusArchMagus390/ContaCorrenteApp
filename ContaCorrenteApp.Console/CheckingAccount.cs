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
        public double Balance { get; set; }
        public int IdAccount { get; set; }
        public double DebitLimit { get; set; }
        public List<Transactions> Transaction { get; set; }
        private Transactions t = new Transactions();

        private double sumDebit()
        {
            double result = 0;

            foreach (Transactions t in Transaction)
            {
                if (t.Transaction < 0)
                    result += Math.Abs(t.Transaction);
            }
            return result;
        }

        public void Withdraw(double withdraw)
        {
            if (DebitLimit == 0 || sumDebit() < DebitLimit)
            {
                Balance -= withdraw;

                t.Transaction = -withdraw;
                t.Date = DateTime.Now.ToString("dd/MM/yyyy");
                t.Time = DateTime.Now.ToString("HH:mm:ss tt");
                Transaction.Add(t);
            }
        }

        public void Deposit(double deposit)
        {
            Balance += deposit;

            t.Transaction = deposit;
            t.Date = DateTime.Now.ToString("dd/MM/yyyy");
            t.Time = DateTime.Now.ToString("HH:mm:ss tt");
            Transaction.Add(t);
        }

        public void TransfereTo(CheckingAccount account, double transference)
        {
            account.Balance += transference;
            Balance -= transference;

            t.Transaction = -transference;
            t.Date = DateTime.Now.ToString("dd/MM/yyyy");
            t.Time = DateTime.Now.ToString("HH:mm:ss tt");
            Transaction.Add(t);
        }

        public void showBalance()
        {
            Console.WriteLine(" \n------------------------------");
            Console.WriteLine($"\n Saldo em conta: {Balance}");
            Console.WriteLine("\n ------------------------------");
        }


        public void ShowStatement()
        {
            
        }
    }
}
