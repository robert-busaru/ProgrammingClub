namespace ProgrammingClub.Helpers
{
    public class ErrorMessageEnum
    {
        public enum ErrorMessage
        {
            NotFound = 404,
            InternalServerError = 500,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403
        }
        public static string GetErrorMessage(ErrorMessage error)
        {
            return error switch
            {
                ErrorMessage.NotFound => "Resource not found.",
                ErrorMessage.InternalServerError => "An internal server error occurred.",
                ErrorMessage.BadRequest => "Bad request.",
                ErrorMessage.Unauthorized => "Unauthorized access.",
                ErrorMessage.Forbidden => "Access forbidden.",
                _ => "An unknown error occurred."
            };
        }
    }
}
