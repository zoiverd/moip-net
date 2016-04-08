namespace Moip.Net.Assinaturas
{
    public class PreferencesRetry
    {
        public int FirstTry { get; set; }
        public int SecondTry { get; set; }
        public int ThirdTry { get; set; }
        public RetryFinallyType Finally { get; set; }

        public enum RetryFinallyType
        {
            CANCEL,
            SUSPEND
        }
    }
}
