using CsvHelper.Configuration.Attributes;

namespace Ensek.Smart.Api.Model
{
    public class MeterReading
    {
        public int AccountId { get; set; }

        [Format("dd/MM/yyyy HH:mm")]
        public DateTime MeterReadingDateTime { get; set; }

        public int MeterReadValue { get; set; }
    }
}
