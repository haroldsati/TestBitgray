using UnityEngine;
using System.Collections;
using User.Detail;

namespace User
{
    public class CompanyDataWrapper
    {
        private CompanyData data;

        public CompanyDataWrapper(CompanyData data)
        {
            this.data = data;
        }

        public string Name
        {
            get { return data.name; }
        }

        public string CatchPhrase
        {
            get { return data.catchPhrase; }
        }

        public string Bs
        {
            get { return data.bs; }
        }
    }
    public class GeoDataWrapper
    {
        private GeoData data;

        public GeoDataWrapper(GeoData data)
        {
            this.data = data;
        }

        public string Lat
        {
            get { return data.lat; }
        }

        public string Lng
        {
            get { return data.lng; }
        }
    }

    public class AddressDataWrapper
    {
        private AddressData data;

        public AddressDataWrapper(AddressData data)
        {
            this.data = data;
        }

        public string Street
        {
            get { return data.street; }
        }

        public string Suite
        {
            get { return data.suite; }
        }

        public string City
        {
            get { return data.city; }
        }

        public string Zipcode
        {
            get { return data.zipcode; }
        }

        public GeoDataWrapper Geo
        {
            get { return new GeoDataWrapper(data.geo); }
        }
    }

    public class UserDataWrapper
    {
        private UserData data;

        public UserDataWrapper(UserData data)
        {
            this.data = data;
        }

        public string Name
        {
            get { return data.name; }
        }

        public string Username
        {
            get { return data.username; }
        }

        public string Email
        {
            get { return data.email; }
        }

        public AddressDataWrapper Address
        {
            get { return new AddressDataWrapper(data.address); }
        }

        public string Phone
        {
            get { return data.phone; }
        }

        public string Website
        {
            get { return data.website; }
        }

        public CompanyDataWrapper Company
        {
            get { return new CompanyDataWrapper(data.company); }
        }
    }
}
