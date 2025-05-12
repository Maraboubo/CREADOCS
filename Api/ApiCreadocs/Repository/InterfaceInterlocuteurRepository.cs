using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceInterlocuteurRepository
    {
        IEnumerable<Interlocuteur> GetAll();
        Interlocuteur GetById(int id);
        //void Add(Interlocuteur interlocuteur);
        Interlocuteur Add(Interlocuteur interlocuteur);
        void Update(Interlocuteur interlocuteur);
        //void Update(Interlocuteur interlocuteur);
        void Delete(int id);
        //ImplentationConnexion
        Interlocuteur GetPass(string email, string password);
    }
}
