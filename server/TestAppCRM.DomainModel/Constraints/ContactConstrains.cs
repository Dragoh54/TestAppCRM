namespace TestAppCRM.DomainModel.Constraints;

public static class ContactConstrains
{
    public const int NAME_MAX_LENGTH = 256;
    public const int MOBILE_PHONE_MAX_LENGTH = 20;
    public const int JOBTITLE_MAX_LENGTH = 256;

    public const string MOBILE_PHONE_REGEX = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
}