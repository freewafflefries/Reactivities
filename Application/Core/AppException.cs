namespace Application.Core
{
    public class AppException
    {
        public AppException(int stateCode, string message, string details = null)
        {
            StateCode = stateCode;
            Message = message;
            Details = details;
        }

        public int StateCode { get; set; }
        public string Message { get; set; }
        public string Details {get; set; }
    }
}