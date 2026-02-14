namespace CryptoTracker.WPF.Helpers.QueryParameters
{
    internal abstract class PaginationQueryParams : BaseQueryParams
    {
        public int? PerPage { get; set; }
        public int? Page { get; set; }
    }
}
