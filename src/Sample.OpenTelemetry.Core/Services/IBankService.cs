using Sample.OpenTelemetry.Core.Dtos;

namespace Sample.OpenTelemetry.Core.Services
{
    public interface IBankService
    {
        Task<ICollection<Bank>> ListBanksAsync();
        Task<Bank> GetBankAsync(int bankId);
    }
}
