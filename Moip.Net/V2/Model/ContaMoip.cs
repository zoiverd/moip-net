namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Estrutura de Conta Moip que irá receber valores do pagamento
    /// </summary>
    public class ContaMoip
    {
        public string Login { get; set; }
        public string Fullname { get; set; }
        public string Id { get; set; }
    }
}