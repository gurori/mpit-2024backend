namespace mpit.Core.Models
{
    public class User
    {
        public User() { }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
    }
}
