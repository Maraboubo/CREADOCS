using ApiCreadocs.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Repository
{
    public class IdentificationRepository : InterfaceIdentificationRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public IdentificationRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public Identification GetIdentif()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT geoNamesUserName FROM IDENTIFICATION WHERE id_identif = 1";
            return connection.QueryFirstOrDefault<Identification>(requete);
        }
    }
}
