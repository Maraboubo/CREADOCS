namespace ApiCreadocs.Repository
{
    public interface InterfacePaysRepository
    {
        void GetOrCreateCountry(string countryCode, string countryName);
    }
}
