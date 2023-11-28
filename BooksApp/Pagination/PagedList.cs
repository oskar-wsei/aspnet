namespace BooksApp.Pagination;

public class PagedList<TItem> : List<TItem>
{
    public int TotalItems { get; }
    public int TotalPages { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public bool IsFirst { get; }
    public bool IsLast { get; }
    public bool HasPrevious { get; }
    public bool HasNext { get; }

    private PagedList()
    {
    }

    private PagedList(int capacity)
    {
    }

    public PagedList(IEnumerable<TItem> collection, int totalItems, int pageNumber, int pageSize) :
        base(collection)
    {
        TotalItems = totalItems;
        TotalPages = TotalItems / pageSize + (TotalItems % pageSize > 0 ? 1 : 0);
        PageNumber = Math.Clamp(pageNumber, 1, TotalPages);
        PageSize = pageSize;
        IsFirst = PageNumber <= 1;
        IsLast = PageNumber >= TotalPages;
        HasPrevious = !IsFirst;
        HasNext = !IsLast;
    }
}