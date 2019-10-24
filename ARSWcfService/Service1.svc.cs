using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ARSWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string AddUser(InsertUser user)
        {
            string message;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into UserTable (Firstname, Lastname, Email, UserPassword, IsAdmin, Gender, UserName) values(@FirstName, @LastName, @Email, @UserPassword, @IsAdmin, @Gender, @UserName)", con);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                int response = cmd.ExecuteNonQuery();
                if (response == 1)
                {
                    message = "Successfully Inserted";
                }
                else
                {
                    message = "Failed to insert";
                }
                con.Close();
                return message;
            }
            catch (Exception e)
            {
                con.Close();
                return e.Message;
            }

        }

        public string AddFlight(InsertFlight flight)
        {
            string message;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string command = "Insert into FlightTable (FlightNumber, DepartureAirport, ArrivalAirport, DepartureTime, ArrivalTime, DepartureDate, FirstClassPrice, EconomyClassPrice, SeatingCapacity) " +
                    "values(@FlightNumber, @DepartureAirport, @ArrivalAirport, @DepartureTime, @ArrivalTime, @DepartureDate, @FirstClassPrice, @EconomyClassPrice, @SeatingCapacity)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                cmd.Parameters.AddWithValue("@DepartureAirport", flight.DepartureAirport);
                cmd.Parameters.AddWithValue("@ArrivalAirport", flight.ArrivalAirport);
                cmd.Parameters.AddWithValue("@DepartureTime", flight.DepartureTime);
                cmd.Parameters.AddWithValue("@ArrivalTime", flight.ArrivalTime);
                cmd.Parameters.AddWithValue("@DepartureDate", flight.DepartureDate);
                cmd.Parameters.AddWithValue("@FirstClassPrice", flight.FirstClassPrice);
                cmd.Parameters.AddWithValue("@EconomyClassPrice", flight.EconomyClassPrice);
                cmd.Parameters.AddWithValue("@SeatingCapacity", flight.SeatingCapacity);

                int response = cmd.ExecuteNonQuery();
                if (response == 1)
                {
                    message = "Successfully Inserted";
                }
                else
                {
                    message = "Failed to insert";
                }
                con.Close();
                return message;
            }
            catch (Exception e)
            {
                con.Close();
                return e.Message;
            }
        }

        public DataTable GetSignInCredentials(string username, string password)
        {
            DataTable dataTable = new DataTable("UserTable");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string command = "SELECT UserPassword, UserName, IsAdmin FROM UserTable WHERE UserPassword = '" + password +"' AND UserName = '"+ username + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@UserPassword", password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                con.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                con.Close();
                return dataTable;
            }

        }

        public DataTable GetAllFlights()
        {
            DataTable dataTable = new DataTable("FlightTable");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string command = "SELECT * FROM FlightTable";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                con.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                con.Close();
                return dataTable;
            }
        }

        public DataTable GetMyFlights(string username)
        {
            DataTable dataTable = new DataTable("SeatTable");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string command = "SELECT * FROM SeatTable JOIN FlightTable ON SeatTable.FlightNumber = FlightTable.FlightNumber WHERE SeatTable.Username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                con.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                con.Close();
                return dataTable;
            }
        }

        public DataTable GetSelectedSeats(string flightNumber)
        {
            DataTable dataTable = new DataTable("SeatTable");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string command = "SELECT SeatNumber FROM SeatTable WHERE FlightNumber = '" + flightNumber + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                con.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                con.Close();
                return dataTable;
            }
        }

        public string AddSeat(InsertSeat seat)
        {
            string message;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ARSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into SeatTable ( Username, SeatNumber, FlightNumber) values(@Username, @SeatNumber, @FlightNumber)", con);
                cmd.Parameters.AddWithValue("@SeatNumber", seat.SeatNumber);
                cmd.Parameters.AddWithValue("@FlightNumber", seat.FlightNumber);
                cmd.Parameters.AddWithValue("@UserName", seat.Username);
                

                int response = cmd.ExecuteNonQuery();
                if (response == 1)
                {
                    message = "Successfully Inserted";
                }
                else
                {
                    message = "Failed to insert";
                }
                con.Close();
                return message;
            }
            catch (Exception e)
            {
                con.Close();
                return e.Message;
            }
        }

    }
}
