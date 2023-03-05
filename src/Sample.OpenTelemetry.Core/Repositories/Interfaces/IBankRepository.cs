using Refit;
using Sample.OpenTelemetry.Core.Dtos;

namespace Sample.OpenTelemetry.Core.Repositories.Interfaces
{
    public interface IBankRepository
    {
        [Get("/banks/v1")]
        Task<ICollection<Bank>> ListBanksAsync();

        [Get("/banks/v1/{code}")]
        Task<Bank> GetBankAsync(int code);
    }
}
