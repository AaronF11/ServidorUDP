using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServidorUDP.Class
{
    /// <summary>
    /// Clase que representa un servidor UDP que reenvía mensajes a los clientes.
    /// </summary>
    class Servidor
    {
        private UdpClient _servidorUDP;
        private int _puerto;
        private CancellationTokenSource _cts;

        /// <summary>
        /// Constructor que inicializa el servidor UDP con un puerto específico.
        /// </summary>
        /// <param name="puerto">Puerto que utilizará el servidor UDP.</param>
        public Servidor(int puerto)
        {
            _puerto = puerto;
            _servidorUDP = new UdpClient(puerto);
            _cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Inicia el servidor UDP y comienza a escuchar peticiones.
        /// </summary>
        public void Iniciar()
        {
            Console.WriteLine("Servidor UDP iniciado en el puerto " + _puerto);

            Task.Run(() => EjecutarServidor(_cts.Token));
        }

        /// <summary>
        /// Detiene el servidor UDP.
        /// </summary>
        public void Detener()
        {
            _cts.Cancel();
            _servidorUDP.Close();
            Console.WriteLine("Servidor UDP detenido");
        }

        /// <summary>
        /// Apaga el servidor UDP.
        /// </summary>
        public void Apagar()
        {
            Console.WriteLine("Apagando el servidor UDP...");
            _cts.Cancel();
            _servidorUDP.Close();
        }

        private async Task EjecutarServidor(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    UdpReceiveResult resultado = await _servidorUDP.ReceiveAsync(cancellationToken);
                    string mensaje = Encoding.ASCII.GetString(resultado.Buffer);

                    Console.WriteLine("Datagrama recibido del host: " + resultado.RemoteEndPoint.Address + " desde el puerto remoto: " + resultado.RemoteEndPoint.Port);
                    Console.WriteLine("Mensaje recibido: " + mensaje);
                    Console.WriteLine();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
}