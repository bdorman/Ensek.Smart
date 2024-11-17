namespace Ensek.Smart.Data.Model
{
    public class Account
    {
        public int AccountId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<MeterReading> MeterReadings { get; } = new List<MeterReading>();
    }
}