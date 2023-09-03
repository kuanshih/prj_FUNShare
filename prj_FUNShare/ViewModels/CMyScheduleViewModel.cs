namespace prj_FUNShare.ViewModels
{
    public class CMyScheduleViewModel
    {
        public string ProductName { get; set; }
        public string Feature { get; set; }
        public int orderId { get; set; }
        public DateTime? beginTime { get; set; }
        public DateTime? endTime { get; set; }
        public string OrderStatus { get; set; }

        public string location { get; set; }
    }
}
