using Domain.Models;

namespace Service.RecoveryPasswordService.cs
{
    public interface IRecoveryPasswordService
    {
        void Insert(UrlRecoveryPassword recoveryPassword);
    }
}
