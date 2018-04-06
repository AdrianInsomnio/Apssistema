public class CustomerViewModel : INotifyDataErrorInfo
{
public CustomerViewModel()
{
_propertyErrors = new Dictionary<string, IEnumerable>();
}
public string Name
{
get { return _name; }
set
{
if (ValidateName(value))
{
_name = value;
}
}
}
public int Age
{
get { return _age; }
set
{
if (ValidateAge(value))
{
_age = value;
}
}
}
public IEnumerable GetErrors(string propertyName)
{
	return _propertyErrors[propertyName];
}
public bool HasErrors
{
	get
		{
			return _propertyErrors.Count > 0;
		}
}
public void CreateCustomer()
{
		_customer = new Customer(Name, Age);
}
private bool ValidateName(string name)
    { 
	bool nameIsValid = (name.IndexOfAny(IllegalCharacters) == -1);
	IEnumerable nameErrors = null;
	if (!nameIsValid)
	{
	List<string> errors = new List<string>();
	errors.Add(string.Format("Customer name contains illegal characters ({0})",	new string(IllegalCharacters)));
	nameErrors = errors;
	}
	OnDataErrorsChanged("Name");
	_propertyErrors["Name"] = nameErrors;
	return nameIsValid;
}
private bool ValidateAge(int age)
{
	bool ageIsValid = (age >= 21);
	IEnumerable ageErrors = null;
	if (!ageIsValid)
	{
		List<string> errors = new List<string>();
		errors.Add("Customer must be over 21 to shop here");
		_propertyErrors["Age"] = errors;
	}
	OnDataErrorsChanged("Age");
	_propertyErrors["Age"] = ageErrors;
	return ageIsValid;
}
private void OnDataErrorsChanged(string propertyName)
{
if (ErrorsChanged != null)
{
	ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
}
}
public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
private string _name;
private int _age;
private IDictionary<string, IEnumerable> _propertyErrors;
private static readonly char[] IllegalCharacters = new char[] {'!', '$', '%', '_'};
private Customer _customer;
}