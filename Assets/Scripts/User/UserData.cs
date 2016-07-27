using System;

namespace User.Detail
{
    [Serializable]
    public class GeoData
    {
        public string lat = "-00.0000";
        public string lng = "00.0000";
    }

    [Serializable]
    public class AddressData
    {
        public string street = "initial street";
        public string suite = "initial suite";
        public string city = "initial city";
        public string zipcode = "00000-00000";
        public GeoData geo = new GeoData();
    }

    [Serializable]
    public class CompanyData
    {
        public string name = "initial company";
        public string catchPhrase = "Catchy Phrase";
        public string bs = "Initial bs";
    }

    [Serializable]
    public class UserData
    {
        public int id = -1;
        public string name = "initial";
        public string username = "initial";
        public string email = "initial@mail";
        public AddressData address = new AddressData();
        public string phone = "0-000-000-0000 x00000";
        public string website = "initial.org";
        public CompanyData company = new CompanyData();

        public override string ToString()
        {
            return name + " " + username + " " + id;
        }
    }
}