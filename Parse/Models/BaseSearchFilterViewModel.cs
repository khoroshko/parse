namespace Parse.Models
{
    public enum DisplayViewListType
    {
        List = 1,
        Large = 2,
    }

    public class BaseSearchFilterViewModel
    {
        #region Page part
        public int Page { get; set; }

        private int _pageSize = ProjectConst.PageSize;
        public int PageSize { get { return _pageSize; } set { _pageSize = value; } }

        #endregion
    }
}