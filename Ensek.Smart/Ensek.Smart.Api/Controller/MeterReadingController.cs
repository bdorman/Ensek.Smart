using Ensek.Smart.Api.Model;
using Ensek.Smart.Api.Service;
using Ensek.Smart.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.Smart.Api.Controller
{
    [ApiController]
    public class MeterReadingController(SmartDatabaseContext smartDatabaseContext, ICsvService csvService) : ControllerBase
    {
        [HttpPost]
        [Route("meter-reading-uploads")]
        public async Task<MeterReadingUploadResult> Post(IFormFile file)
        {
            var results = new MeterReadingUploadResult();
            var meterReadings = csvService.ReadCsv<MeterReading>(file.OpenReadStream());

            foreach (var meterReading in meterReadings)
            {
                if (meterReading.MeterReadValue < 0 || meterReading.MeterReadValue > 99999)
                {
                    results.Failure++;
                    continue;
                }

                var account = smartDatabaseContext.Accounts.SingleOrDefault(x => x.AccountId == meterReading.AccountId);
                if (account == null || account.MeterReadings.Any(existing => existing.MeterReadingDateTime >= meterReading.MeterReadingDateTime))
                {
                    results.Failure++;
                    continue;
                }

                await smartDatabaseContext.MeterReadings.AddAsync(new()
                {
                    AccountId = meterReading.AccountId,
                    MeterReadingDateTime = meterReading.MeterReadingDateTime,
                    MeterReadValue = meterReading.MeterReadValue.ToString("00000"),
                });
                await smartDatabaseContext.SaveChangesAsync();

                results.Success++;
            }

            return results;
        }
    }
}