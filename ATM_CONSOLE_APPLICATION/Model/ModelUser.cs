using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.View.Information;
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
        public ModelUser()
        {
            
        }       
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string user, string password, string email, string phone, DateTime created_at, string role, string status_user)
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
        public static bool IsRegister(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "INSERT HIGH_PRIORITY INTO user(full_name, Date_Of_Birth, gender, cmnd_cccd, Address, username, password, email, number_phone) VALUES (@fullname, @dateofbirth, @gender, @cmnd_cccd, @address, @username, @password, @email, @numberphone);";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@fullname", modelBank_Account.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", modelBank_Account.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", modelBank_Account.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", modelBank_Account.Address);
                mySqlCommand.Parameters.AddWithValue("@username", modelBank_Account.Username);
                mySqlCommand.Parameters.AddWithValue("@password", modelBank_Account.Password);
                mySqlCommand.Parameters.AddWithValue("@email", modelBank_Account.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", modelBank_Account.Phone);
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
                modelBank_Account.GetList_All_Bank_User();
                DBHelper.Close();
            }
        }
        public static bool Update_Information(ModelBank_Account modelBank_Account)
        {
            try
            {
                string query = "UPDATE user SET full_name = @fullname, Date_Of_Birth = @dateofbirth, gender = @gender, cmnd_cccd = @cmnd_cccd, Address = @address, email = @email, number_phone = @numberphone WHERE id_user = @iduser;";
                using MySqlCommand mySqlCommand = new MySqlCommand(query, DBHelper.Open());
                mySqlCommand.Parameters.AddWithValue("@iduser", modelBank_Account.ID_User);
                mySqlCommand.Parameters.AddWithValue("@fullname", modelBank_Account.FullName);
                mySqlCommand.Parameters.AddWithValue("@dateofbirth", modelBank_Account.DateOfBirth);
                mySqlCommand.Parameters.AddWithValue("@gender", modelBank_Account.Gender);
                mySqlCommand.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.CMND_CCCD);
                mySqlCommand.Parameters.AddWithValue("@address", modelBank_Account.Address);
                mySqlCommand.Parameters.AddWithValue("@email", modelBank_Account.Email);
                mySqlCommand.Parameters.AddWithValue("@numberphone", modelBank_Account.Phone);
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
                DBHelper.Close();
            }
        }
        public static int Select_ID_User(ModelUser modelBank_Account)
        {
            try
            {
                string query = "SELECT user.id_user FROM user WHERE user.username = @username AND user.email = @email AND user.cmnd_cccd = @cmnd_cccd";
                using MySqlCommand command = new MySqlCommand(query, DBHelper.Open());
                command.Parameters.AddWithValue("@username", modelBank_Account.Username);
                command.Parameters.AddWithValue("@email", modelBank_Account.Email);
                command.Parameters.AddWithValue("@cmnd_cccd", modelBank_Account.CMND_CCCD);
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
        public ModelUser GetUser(MySqlDataReader reader)
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
