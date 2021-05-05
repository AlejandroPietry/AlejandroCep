using Domain.Models;
using Repository.DbContextFolder;
using System.Linq;

namespace Repository.RepositoryFolder
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IbgeMunicipio GetMunicipioByIbge(int ibge)
        {
            return context.ibgeMunicipios.Where(x => x.id == ibge).FirstOrDefault();
        }

        public void SaveMunicipio(IbgeMunicipio ibgeMunicipio)
        {
            context.ibgeMunicipios.Add(ibgeMunicipio);
            context.SaveChanges();
        }

        public User GetUser(User user)
        {
            return context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == x.Password);
        }

        public LogLogin GetLogLogin(int userId)
        {
            return context.Logs_Login.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).FirstOrDefault();
        }
        public void SetLogLogin(int userId)
        {
            context.Logs_Login.Add(new LogLogin { UserId = userId });
            context.SaveChangesAsync();
        }
        public void DeleteLogLogin(int userId)
        {
            LogLogin logLogin = GetLogLogin(userId);
            context.Logs_Login.Remove(logLogin);
            context.SaveChanges();
        }

        #region Tudo relacionando com o token do usuario
        public void AddTokenInUserToken(JwtToken jwtToken)
        {
            context.jwtTokens.Add(jwtToken);
            context.SaveChangesAsync();
        }

        public JwtToken GetSingleActiveUserToken(int userId)
        {
            return context.jwtTokens.Where(x => x.UserId == userId && x.IsUsed == true).SingleOrDefault();
        }

        public void BlockedJwtToken(JwtToken jwtToken)
        {
            jwtToken.IsUsed = false;
            context.jwtTokens.Update(jwtToken);
            context.SaveChangesAsync();
        }

        public void AddJwtToken(string token, int userId)
        {
            context.jwtTokens.Add(new JwtToken
            {
                Token = token,
                UserId = userId,
                IsUsed = true
            });
            context.SaveChangesAsync();
        }

        public JwtToken CheckTokenStatus(string token)
        {
            return context.jwtTokens.Where(x => x.Token == token).SingleOrDefault();
        }
        #endregion
    }
}