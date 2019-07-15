using Envision.MDM.Location.Domain.Common;


namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserInfo(int id, string firstName,string lastName, string userName, string password)
        {
            id = Id;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
        }
    }
}
