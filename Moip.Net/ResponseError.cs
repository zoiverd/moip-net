using System.Net;

namespace Moip.Net
{
    /// <summary>
    /// Estrutura de retorno de mensagens do Moip
    /// </summary>
    public struct ResponseError
    {
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Erros da mensagem, se existirem
        /// </summary>
        public ResponseDetail[] Errors { get; set; }

        public struct ResponseDetail
        {
            /// <summary>
            /// Descrição do alerta
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Código do alerta
            /// </summary>
            public string Code { get; set; }
        }

    }

}
