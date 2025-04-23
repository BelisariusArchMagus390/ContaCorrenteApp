namespace ContaCorrenteApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CheckingAccount
    {
        public double Balance { get; set; }
        public int IdAccount { get; set; }
        public double DebitLimit { get; set; }
        public Transactions[] Transactions { get; set; }

        public void Withdraw(double withdraw)
        {
            
        }

        public void Deposit(double deposit)
        {
            Balance += deposit;
        }

        public void TransfereTo(CheckingAccount account, double transference)
        {
            account.Balance += transference;
        }

        public void ShowStatement()
        {

        }
    }
}
