namespace Arch.Core.Authentication.Impl
{
    public class TokenUser : ITokenUser
    {
        public TokenUser(int id, string subject, string audience, string uniqueName)
        {
            Id = id;
            Subject = subject;
            Audience = audience;
            UniqueName = uniqueName;
        }

        public int Id { get; }
        public string Subject { get; }
        public string Audience { get; }
        public string UniqueName { get; }
    }
}
