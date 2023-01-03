namespace SynologyNet.Models.Responses
{
    public class Error
    {
        public int Code { get; set; }
        public ErrorContent Errors { get; set; }
    }

    public class ErrorContent
    {
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}
