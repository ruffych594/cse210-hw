using System;

// The Customer class stores who is buying and where they live.
// The address is its own class, so Customer "has an" Address (composition).
public class Customer
{
    private string _name;
    private Address _address;

    // Constructor: a customer needs a name and an address from the start
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }

    // Tells us if the customer lives in the USA.
    // The customer doesn't check the country itself, it asks its Address.
    public bool LivesInUsa()
    {
        return _address.IsInUsa();
    }
}
