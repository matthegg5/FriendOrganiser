using FriendOrganiserUI.ViewModels;
using System.Collections;
using System.ComponentModel;

namespace FriendOrganiserUI.Wrappers
{
    public class NotifyDataErrorInfoBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorsByPropertyName.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            List<string>? result;
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                result = _errorsByPropertyName[propertyName];
            }
            else
            {
                result = null;
            }

            return result;
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            // "this" being the sending object, the object instantiated with the type defined in this class
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string error)
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

        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
            }
        }
    }
}
