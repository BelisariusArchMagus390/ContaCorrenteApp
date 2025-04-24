namespace ContaCorrenteApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Input
    {
        // mostra mensagem de erro padrão
        public void showErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine($"\n Erro! {message}");
            Console.WriteLine(" Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        // verifica se o input é um double
        public double verifyDoubleValue(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(message);
                string value = Console.ReadLine();

                if (double.TryParse(value, out double doubleValue))
                {
                    return doubleValue;
                }
                else
                    showErrorMessage(" Esse não é um valor numérico.");
            }
        }

        // verifica se o input é um int
        public int verifyIntValue(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(message);
                string value = Console.ReadLine();

                if (int.TryParse(value, out int intValue))
                {
                    return intValue;
                }
                else
                    showErrorMessage(" Esse não é um valor numérico inteiro.");
            }
        }
    }
}
