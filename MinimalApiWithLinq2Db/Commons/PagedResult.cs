namespace MinimalApiWithLinq2Db.Commons
{
    public record PagedResult<T>(int TotalCount, ICollection<T> Items) where T : class
    {
    }
}
