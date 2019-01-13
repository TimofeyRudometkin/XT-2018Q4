namespace Epam.Task7._1.Users.Entities.Exception
{
    public class CriticalException : System.Exception
    {
        public CriticalException()
        {
        }

        public CriticalException(string message) : base(message)
        {
        }

        public CriticalException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
