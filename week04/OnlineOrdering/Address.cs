using System;

// The Address class holds all the location details for a customer.
// It also knows how to tell us if it is in the USA, and how to print itself.
public class Address
{
    // All member variables are private (encapsulation!)
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Constructor: sets all four fields when we create the address
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Getters and setters so other classes can read or change the fields safely
    public string GetStreetAddress()
    {
        return _streetAddress;
    }

    public void SetStreetAddress(string streetAddress)
    {
        _streetAddress = streetAddress;
    }

    public string GetCity()
    {
        return _city;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public string GetStateOrProvince()
    {
        return _stateOrProvince;
    }

    public void SetStateOrProvince(string stateOrProvince)
    {
        _stateOrProvince = stateOrProvince;
    }

    public string GetCountry()
    {
        return _country;
    }

    public void SetCountry(string country)
    {
        _country = country;
    }

    // Returns true if the address is in the USA, otherwise false.
    // We ignore upper/lower case so "usa" and "USA" both work.
    public bool IsInUsa()
    {
        return _country.Trim().ToUpper() == "USA";
    }

    // Puts the whole address into one string, using new lines like on a real label
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
