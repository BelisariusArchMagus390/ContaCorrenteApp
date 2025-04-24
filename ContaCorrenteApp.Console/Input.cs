namespace ContaCorrenteApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Input
    {
        public void showErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine($"\n Erro! {message}");
            Console.WriteLine(" Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
