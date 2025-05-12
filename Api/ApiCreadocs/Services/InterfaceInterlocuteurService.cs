using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceInterlocuteurService
    {
        IEnumerable<Interlocuteur> GetAllInterlocuteurs();
        Interlocuteur GetInterlocuteurById(int id);
        //void CreateInterlocuteur(Interlocuteur interlocuteur);
        Interlocuteur CreateInterlocuteur(Interlocuteur interlocuteur);
        void UpdateInterlocuteur(Interlocuteur interlocuteur);
        //void UpdateInterlocuteur(Interlocuteur interlocuteur);
        void DeleteInterlocuteur(int id);
        Interlocuteur GetUserByEmailAndPassword(string email,string password);
    }
}
