namespace BusinessEntities.Response
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ErrorCode { get; set; }
        public DateTimeOffset LogDate { get; set; }
    }
}
