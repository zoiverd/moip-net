using System;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Boleto é um título bancário utilizado no Brasil como meio de pagamento. O título é emitido no momento da finalização do checkout e pode ser pago na rede bancária.
    /// </summary>
    public class Boleto
    {
        public string LineCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public LinhasInstrucao InstructionLines { get; set; }
        public string LogoUri { get; set; }
    }
}