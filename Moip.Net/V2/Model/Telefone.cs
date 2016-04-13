namespace Moip.Net.V2.Model
{
    public class Telefone
    {
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return string.Format("+{0} ({1}) {2}", CountryCode, AreaCode, Number);
        }
    }
}