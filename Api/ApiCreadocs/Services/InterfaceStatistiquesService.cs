using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceStatistiquesService
    {
        Statistiques GetStatistiquesInter(int id_agence, int id_inter);
    }
}
