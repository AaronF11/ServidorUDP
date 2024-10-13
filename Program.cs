using ServidorUDP.Class;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServidorUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = 6789;
            Servidor servidorUDP = new Servidor(puerto);

            Console.WriteLine("Presione 's' para iniciar el servidor, 'd' para detenerlo, 'p' para apagar");
            ConsoleKeyInfo tecla;

            while (true)
            {
                tecla = Console.ReadKey(true);

                if (tecla.KeyChar == 's')
                {
                    servidorUDP.Iniciar();
                }
                else if (tecla.KeyChar == 'd')
                {
                    servidorUDP.Detener();
                }
                else if (tecla.KeyChar == 'p')
                {
                    servidorUDP.Apagar();
                    break;
                }
            }
        }
    }
}