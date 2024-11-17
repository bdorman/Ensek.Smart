﻿namespace Ensek.Smart.Data.Model
{
    public class MeterReading
    {
        public int MeterReadingId { get; set; }

        public int AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public string MeterReadValue { get; set; } = null!;

        public Account Account { get; set; } = null!;
    }
}
