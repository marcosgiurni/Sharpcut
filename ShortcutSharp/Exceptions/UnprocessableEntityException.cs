namespace Sharpcut.Exceptions
{
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException()
            : base("Shortcut was unable to process the request. Check if the content you are trying" +
                  " to create already exists.")
        {
        }

        public UnprocessableEntityException(string? message) 
            : base(message)
        {
        }

        public UnprocessableEntityException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}
