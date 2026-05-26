namespace TestAppCRM.DomainModel.Exceptions;

public class AlreadyExistsException(string message) : Exception(message);