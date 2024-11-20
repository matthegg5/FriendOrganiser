using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FriendOrganiserUI.Wrappers
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public T Model { get; }

        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            // using Reflection to get the property object cast as a TValue based on the given propertyName
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            // using Reflection to assign a value to a property of our Model
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged();
            ValidatePropertyInternal(propertyName, value);
        }

        private void ValidatePropertyInternal(string propertyName, object currentValue)
        {
            ClearErrors(propertyName);

            ValidateDataAnnotations(propertyName, currentValue);

            ValidateCustomErrors(propertyName);

        }

        private void ValidateDataAnnotations(string propertyName, object currentValue)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(Model) { MemberName = propertyName };

            Validator.TryValidateProperty(currentValue, validationContext, results);

            foreach (var result in results)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }

        private void ValidateCustomErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);

            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }
}
