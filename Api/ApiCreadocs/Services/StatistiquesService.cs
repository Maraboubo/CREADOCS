using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class StatistiquesService : InterfaceStatistiquesService
    {
        private readonly InterfaceStatistiquesRepository _interfaceStatistiquesRepository;
        public StatistiquesService(InterfaceStatistiquesRepository interfaceStatistiquesRepository)
        {
            _interfaceStatistiquesRepository = interfaceStatistiquesRepository;
        }
        public Statistiques GetStatistiquesInter(int id_agence, int id_inter)
        {
            var (nbContrat, nomAgence) = _interfaceStatistiquesRepository.GetAgenceMaxContrats();
            var (nbrContratAgence, nomDagence) = _interfaceStatistiquesRepository.GetAgenceNbContrats(id_agence);
            var (valTotaleContatsAssu, nomDeAgence) = _interfaceStatistiquesRepository.GetValContratsAssu(id_agence);
            var (prenomCli, nomCli) = _interfaceStatistiquesRepository.GetMeilleurClientAgence(id_agence);
            var (nomAssu, nbContrMax) = _interfaceStatistiquesRepository.GetMeilleurTypeContrat(id_agence);
            var (nbContrInter, nomInter) = _interfaceStatistiquesRepository.GetNombreContratInterlocuteur(id_inter);
            var (valTotContrInter, nomDinter) = _interfaceStatistiquesRepository.GetValeurTotaleContratInterlocuteur(id_inter);
            var (prenomTopCliInter, nomTopCliInter, nbContrCliMax) = _interfaceStatistiquesRepository.GetMeilleurClientInterlocuteur(id_inter);

            var statistiques = new Statistiques
            {
                agenceMaxContrat = $"{nomAgence}",
                nbContratAgenceMax = nbContrat,
                nbContratAgence = nbrContratAgence,
                valeurTotaleContratAssu = valTotaleContatsAssu,
                topClientAgence = $"{prenomCli} {nomCli}",
                topContratAgence = $"{nomAssu}",
                nbTopContratAgence = nbContrMax,
                nbContratInter = nbContrInter,
                valTotalContratInter = valTotContrInter,
                topClientInter = $"{prenomTopCliInter} {nomTopCliInter}",
                nbContrTopCli = nbContrCliMax
            };

            return statistiques;
        }
    }
}
