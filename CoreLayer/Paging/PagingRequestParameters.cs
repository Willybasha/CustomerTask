namespace CoreLayer.Paging
{
  public abstract class PagingRequestParameters
  {
        const int maxPageSize = 4;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 4;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
  }

}

