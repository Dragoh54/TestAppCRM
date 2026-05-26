namespace TestAppCRM.DomainModel.Exceptions;

public class BadRequestException(string message) : Exception(message);