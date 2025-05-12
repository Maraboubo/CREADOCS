using System.Data;

namespace ApiCreadocs.Repository
{
    public interface InterfaceConnexion
    {
        IDbConnection CreateConnexion();
    }
}
