using Microsoft.Extensions.Logging;
using Sample.OpenTelemetry.Core.Dtos;
using Sample.OpenTelemetry.Core.Repositories.Interfaces;

namespace Sample.OpenTelemetry.Core.Services
{
    public class BankService : IBankService
    {
        private readonly ILogger<BankService> _logger;
        private readonly IBankRepository _bankRepository;

        public BankService(ILogger<BankService> logger, IBankRepository bankRepository)
        {
            _logger = logger;
            _bankRepository = bankRepository;
        }

        public async Task<Bank> GetBankAsync(int bankId)
        {
            return await _bankRepository.GetBankAsync(bankId);
        }

        public async Task<ICollection<Bank>> ListBanksAsync()
        {
            return await _bankRepository.ListBanksAsync();
        }
    }
}
