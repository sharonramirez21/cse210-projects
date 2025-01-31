class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LiveInUSA()
    {
        return _address.IsInUsa(); // the person lives in USA?
    } 

    public string GetCustomerInfo()
    {
        return $"Customer: {_name}, Address: {_address.GetFullAddress()}";
    }
}