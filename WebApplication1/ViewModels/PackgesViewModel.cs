namespace WebApplication1.ViewModels
{
    public class PackgesViewModel
    {
        public string Name { get; set; }
        public bool Limited { get; set; } = true;
        public string ProviderName { get; set; }
        public decimal Price { get; set; }
    }
}
