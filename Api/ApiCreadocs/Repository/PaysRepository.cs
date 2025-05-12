using Dapper;
using System.Data;

namespace ApiCreadocs.Repository
{
    public class PaysRepository : InterfacePaysRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;

        public PaysRepository(InterfaceConnexion connection)
        {
            _interfaceConnection = connection;
        }


        public void GetOrCreateCountry(string countryCode, string countryName)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            // Vérifier si le countryCode existe déjà
            string selectQuery = "SELECT countryCode FROM PAYS WHERE countryCode = @CountryCode";
            var existingCountryCode = connection.QueryFirstOrDefault<string>(selectQuery, new { CountryCode = countryCode });

            // Si le countryCode n'existe pas, l'insérer dans la table PAYS
            if (existingCountryCode == null)
            {
                string insertQuery = "INSERT INTO PAYS (countryCode, countryName) VALUES (@CountryCode, @CountryName)";
                connection.Execute(insertQuery, new { CountryCode = countryCode, CountryName = countryName });
            }
        }

        //public int GetOrCreateCountry(string countryCode, string countryName)
        //{
        //    using var connection = _interfaceConnection.CreateConnexion();
        //    string selectQuery = "SELECT id_pays FROM PAYS WHERE countryCode = @CountryCode";
        //    var existingCountryId = connection.QueryFirstOrDefault<int?>(selectQuery, new { CountryCode = countryCode });

        //    if (existingCountryId.HasValue)
        //    {
        //        return existingCountryId.Value;
        //    }

        //    string insertQuery = "INSERT INTO PAYS (countryCode, countryName) VALUES (@CountryCode, @CountryName); SELECT CAST(SCOPE_IDENTITY() as int)";
        //    return connection.QuerySingle<int>(insertQuery, new { CountryCode = countryCode, CountryName = countryName });
        //}
    }
}
