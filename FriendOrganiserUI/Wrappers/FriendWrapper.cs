using FriendOrganiser.Model;

namespace FriendOrganiserUI.Wrappers
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }
        public int Id { get { return Model.Id; } }
        public string FirstName
        {
            get { return GetValue<string>(nameof(FirstName)); }
            set
            {
                SetValue(value);
            }
        }

        public string LastName
        {
            get { return GetValue<string>(nameof(LastName)); } 
            set
            {
                SetValue(value);
            }
        }

        public string Email
        {
            get { return GetValue<string>(nameof(Email)); }
            set
            {
                SetValue(value);
            }
        }
        
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.IsNullOrWhiteSpace(FirstName))
                    {
                        yield return "First name cannot be empty";
                    }
                    break;

                case nameof(LastName):
                    if (string.IsNullOrWhiteSpace(LastName))
                    {
                        yield return "Last name cannot be empty";
                    }
                    break;

                case nameof(Email):
                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        yield return "Email cannot be empty";
                    }
                    break;

            }
        }
    }

}
