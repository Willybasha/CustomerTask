namespace BusinessLayer.DTOS
{
    public class CustomerViewModel
    {
        public IEnumerable<CustomerResponseDTO> Customers { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
    }
}
