namespace Fire_Emblem_Common.Exceptions;

public class FileProcessingException : Exception
{
    public FileProcessingException(string message) : base(message) { }
    
    public FileProcessingException(string message, Exception innerException) 
        : base(message, innerException) { }
}