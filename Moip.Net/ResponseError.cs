using System;
using System.Linq;
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


        public string FullMessage
        {
            get
            {
                var msg = Message;
                msg += string.Join(@"\r\n", Errors.Select(x => "- " + x.Description).ToArray());
                return msg;
            }
        }

    }

}
