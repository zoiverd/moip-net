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
                var msg = "";
                if (!string.IsNullOrEmpty(Message))
                {
                    msg += Message + (Errors.Length > 0 ? Environment.NewLine : "");
                }

                msg += string.Join(Environment.NewLine, Errors.Select(x => x.Description).ToArray());

                return msg;
            }
        }

    }

}
