using Domain.Models;
using Repository.RepositoryPattern;

namespace Service.RecoveryPasswordService.cs
{
    public class RecoveryPasswordService : IRecoveryPasswordService
    {
        private readonly IRepository<UrlRecoveryPassword> _repository;

        public RecoveryPasswordService(IRepository<UrlRecoveryPassword> repository)
        {
            _repository = repository;
        }
        public void Insert(UrlRecoveryPassword recoveryPassword)
        {
            _repository.Insert(recoveryPassword);
        }
    }
}
