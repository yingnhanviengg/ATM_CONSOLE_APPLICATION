using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public class ModelUser
    {
        public int ID_User { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CMND_CCCD { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime created_at { get; set; }
        public string role { get; set; }    
        public string status_user { get; set; }       
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD ,string address, string user, string password, string email, string phone, DateTime created_at, string role, string status_user)
        {
            this.ID_User = id_user;
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Username = user;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
            this.created_at = created_at;
            this.role = role;
            this.status_user = status_user;
        }
        public ModelUser()
        {

        }
        public static bool IsRegister(string fullname, string gender, DateTime DateOfBirth, string Address, string CMND_CCCD, string user, string pass, string email, string phone)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO user(full_name, Date_Of_Birth, gender, cmnd_cccd, Address, username, password, email, number_phone) VALUES (@fullname, @dateofbirth, @gender, @cmnd_cccd, @address, @username, @password, @email, @numberphone);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@fullname", fullname);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", Address);
                mySqlCommand.Parameters.AddWithValue("@username", user);
                mySqlCommand.Parameters.AddWithValue("@password", pass);
                mySqlCommand.Parameters.AddWithValue("@email", email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", phone);
                if (mySqlCommand.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                ModelBank_Account.GetList_All_Bank_User();
                DBHelper.Close();
            }
        }
        public static int Select_ID_User(string user, string email, string cmnd_cccd)
        {
            try
            {
                string query = "SELECT user.id_user FROM user WHERE user.username = @username AND user.email = @email AND user.cmnd_cccd = @cmnd_cccd";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@cmnd_cccd", cmnd_cccd);
                using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        return mySqlDataReader.GetInt32("id_user");
                    }
                    else
                    {
                        return 0;
                    }                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                DBHelper.Close();
            }
        }
        public static void GetListUser()
        {
            Controller.ControllerBank_User.ListUsers.Clear();
            string query = "SELECT user.* FROM user;";
            using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    Controller.ControllerBank_User.ListUsers.Add(GetUser(mySqlDataReader));
                }
            }
            DBHelper.Close();
        }
        public static ModelUser GetUser(MySqlDataReader reader)
        {
            ModelUser user = new ModelUser(
                reader.GetInt32("id_user"),
                reader.GetString("full_name"),
                reader.GetDateTime("Date_Of_Birth"),
                reader.GetString("gender"),
                reader.GetString("cmnd_cccd"),
                reader.GetString("Address"),
                reader.GetString("username"),
                reader.GetString("password"),
                reader.GetString("email"),
                reader.GetString("number_phone"),
                reader.GetDateTime("created_at"),
                reader.GetString("role"),
                reader.GetString("status_user")
                );
            return user;
        }
    }
}
