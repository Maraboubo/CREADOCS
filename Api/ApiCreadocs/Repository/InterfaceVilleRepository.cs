namespace ApiCreadocs.Repository
{
    public interface InterfaceVilleRepository
    {
        int GetOrCreateCity(string postalCode, string placeName, string countryCode);
    }
}
