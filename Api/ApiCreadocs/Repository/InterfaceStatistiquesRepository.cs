namespace ApiCreadocs.Repository
{
    public interface InterfaceStatistiquesRepository
    {
        public (int nbContrat, string nomAgence) GetAgenceMaxContrats();
        public (int nbrContratAgence, string nomDagence) GetAgenceNbContrats(int id_agence);
        public (int valTotaleContatsAssu, string nomDeAgence) GetValContratsAssu(int id_agence);
        public (string prenomCli, string nomCli) GetMeilleurClientAgence(int id_agence);
        public (string nomAssu, int nbContrMax) GetMeilleurTypeContrat(int id_agence);
        public (int nbContrInter, string nomInter) GetNombreContratInterlocuteur(int id_inter);
        public (int valTotContrInter, string nomDinter) GetValeurTotaleContratInterlocuteur(int id_inter);
        public (string prenomTopCliInter, string nomTopCliInter, int nbContrCliMax) GetMeilleurClientInterlocuteur(int id_inter);
    }
}
