using FriendOrganiser.Model;
using FriendOrganiserUI.ViewModels;
using System.Collections;
using System.ComponentModel;

namespace FriendOrganiserUI.Wrappers
{
    public class FriendWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        public FriendWrapper(Friend model)
        {
            Model = model;
        }

        public Friend Model { get; set; }
        public int Id { get { return Model.Id; } }
        public string FirstName
        {
            get { return Model.FirstName; }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty(nameof(FirstName));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.IsNullOrWhiteSpace(FirstName)) 
                    {
                        AddError(propertyName, "First name cannot be null or empty");
                    }
                    break;

                case nameof(LastName):
                    if (string.IsNullOrWhiteSpace(LastName))
                    {
                        AddError(propertyName, "Last name cannot be null or empty");
                    }
                    break;

                case nameof(Email):
                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        AddError(propertyName, "Email cannot be null or empty");
                    }
                    break;

            }
        }

        public string LastName
        {
            get { return Model.LastName; } 
            set
            { 
                Model.LastName = value; 
                OnPropertyChanged();
                ValidateProperty(nameof(LastName));
            }
        }

        public string Email
        {
            get { return Model.Email; }
            set
            {
                Model.Email = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Email));
            }
        }

        private Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorsByPropertyName.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            List<string>? result;
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
               result =  _errorsByPropertyName[propertyName];
            }
            else
            {
                result = null;
            }

            return result;
        }

        private void OnErrorsChanged(string propertyName)
        {
            // "this" being the sending object, the object instantiated with the type defined in this class
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
            }
        }
    }
}
