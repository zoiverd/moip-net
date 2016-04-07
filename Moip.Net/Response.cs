using System.Net;

namespace Moip.Net
{
    /// <summary>
    /// Estrutura de retorno de mensagens do Moip
    /// </summary>
    public struct Response
    {
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Alertas da mensagem, se existirem
        /// </summary>
        public ResponseDetail[] Alerts { get; set; }

    }

}
