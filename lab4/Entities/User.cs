namespace lab4.Entities
{

    public class UserJson
    {
        public string name { get; set; } = "";
    }

    public class User
    {
        // PK
        public string Name { get; set; } = "";

        // Children
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<UserMonth>? UserMonths { get; set; }

        public User(string name)
        {
            this.Name = name;
        }

        public UserJson toJSON()
        {
            return new UserJson{name=this.Name};
        }
    }
}
