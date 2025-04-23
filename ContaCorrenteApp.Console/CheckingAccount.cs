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

        public void Withdraw()
        {

        }

        public void Deposit()
        {

        }

        public void TransfereTo()
        {

        }

        public void ShowStatement()
        {

        }
    }
}
