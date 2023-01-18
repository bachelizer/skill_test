namespace skill_test.Interfaces;

public interface ISmtp
{
     public bool SendMail(string lastName, string emailAddress);
}