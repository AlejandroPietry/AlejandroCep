using Domain.Models;

namespace Repository.RepositoryFolder
{
    public interface IRepository
    {
        IbgeMunicipio GetMunicipioByIbge(int ibge);
        void SaveMunicipio(IbgeMunicipio ibgeMunicipio);
        User GetUser(User user);
        LogLogin GetLogLogin(int userId);
        void SetLogLogin(int userId);
        void DeleteLogLogin(int userId);
        JwtToken GetSingleActiveUserToken(int userId);
        void BlockedJwtToken(JwtToken jwtToken);
        void AddJwtToken(string token, int userId);
        JwtToken CheckTokenStatus(string token);
    }
}
