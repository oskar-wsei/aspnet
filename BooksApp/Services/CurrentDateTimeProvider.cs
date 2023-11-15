using BooksApp.Contracts;

namespace BooksApp.Services;

public class CurrentDateTimeProvider : IDateTimeProvider
{
    public DateTime GetDate()
    {
        return DateTime.Now;
    }
}
