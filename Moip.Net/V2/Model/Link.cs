namespace Moip.Net.V2.Model
{
    public class Link
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string RedirectHref { get; set; }

        public override string ToString()
        {
            return Href;
        }
    }
}