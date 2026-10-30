namespace MoviesAPI.Models
{
    public class Result(bool isSuccess, string message)
    {
        public readonly bool IsSuccess = isSuccess;
        public readonly string Message = message;
    }
}
