using Dapper;
using System.Data;

namespace ApiCreadocs.Repository
{
    public class VilleRepository : InterfaceVilleRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;

        public VilleRepository(InterfaceConnexion connection)
        {
            _interfaceConnection = connection;
        }

        public int GetOrCreateCity(string postalCode, string placeName, string countryCode)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string selectQuery = "SELECT id_ville FROM VILLES WHERE postalCode = @PostalCode AND placeName = @PlaceName AND countryCode = @CountryCode";
            var existingCityId = connection.QueryFirstOrDefault<int?>(selectQuery, new { PostalCode = postalCode, PlaceName = placeName, CountryCode = countryCode });

            if (existingCityId.HasValue)
            {
                return existingCityId.Value;
            }

            string insertQuery = "INSERT INTO VILLES (countryCode, postalCode, placeName) VALUES (@CountryCode, @PostalCode, @PlaceName); SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.QuerySingle<int>(insertQuery, new { CountryCode = countryCode, PostalCode = postalCode, PlaceName = placeName });

            //'SELECT CAST(SCOPE_IDENTITY() as int' renvoie la derniere valeur insérée dans une table avec auto incrémentation.
        }
    }
}
