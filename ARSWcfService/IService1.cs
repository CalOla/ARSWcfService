using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ARSWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddUser(InsertUser user);

        [OperationContract]
        string AddFlight(InsertFlight flight);

        [OperationContract]
        DataTable GetSignInCredentials(string username, string password);

        [OperationContract]
        DataTable GetAllFlights();

        [OperationContract]
        DataTable GetMyFlights(string username);

        [OperationContract]
        string AddSeat(InsertSeat seat);

        [OperationContract]
        DataTable GetSelectedSeats(string flightName);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InsertUser
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        string userName = string.Empty;
        string email = string.Empty;
        string userPassword = string.Empty;
        string gender = string.Empty;
        int isAdmin = 0;


                

        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DataMember]
        public int IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

    }


    [DataContract]
    public class InsertFlight
    {
        string flightNumber = string.Empty;
        string departureAirport = string.Empty;
        string arrivalAirport = string.Empty;
        string departureTime = string.Empty;
        string arrivalTime = string.Empty;
        string departureDate = string.Empty;
        string firstClassPrice = string.Empty;
        string economyClassPrice = string.Empty;
        int seatingCapacity = 0;


        [DataMember]
        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        [DataMember]
        public string DepartureAirport
        {
            get { return departureAirport; }
            set { departureAirport = value; }
        }

        [DataMember]
        public string ArrivalAirport
        {
            get { return arrivalAirport; }
            set { arrivalAirport = value; }
        }

        [DataMember]
        public string DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        [DataMember]
        public string ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        [DataMember]
        public string DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        [DataMember]
        public string FirstClassPrice
        {
            get { return firstClassPrice; }
            set { firstClassPrice = value; }
        }

        [DataMember]
        public string EconomyClassPrice
        {
            get { return economyClassPrice; }
            set { economyClassPrice = value; }
        }

        [DataMember]
        public int SeatingCapacity
        {
            get { return seatingCapacity; }
            set { seatingCapacity = value; }
        }
    }

    [DataContract]
    public class InsertSeat
    {
        string flightNumber = string.Empty;
        string seatNumber = string.Empty;
        string username = string.Empty;

        
        [DataMember]
        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        [DataMember]
        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }


    }
