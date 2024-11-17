namespace Ensek.Smart.Api.Service
{
    public interface ICsvService
    {
        public IEnumerable<T> ReadCsv<T>(Stream file);
    }
}
