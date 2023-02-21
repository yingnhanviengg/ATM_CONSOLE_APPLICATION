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
        public ModelUser(string username, string password)
        {
            this.Username = username;   
            this.Password = password;
        }
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string email, string phone)
        {
            this.ID_User = id_user;
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }
        public ModelUser(string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string user, string password, string email, string phone)
        {
            this.FullName = fullname;
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
            this.CMND_CCCD = CMND_CCCD;
            this.Address = address;
            this.Username = user;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
        }
        public ModelUser(int id_user, string fullname, DateTime dateofbirth, string gender, string CMND_CCCD, string address, string user, string password, string email, string phone)
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
        }
        public ModelUser(int iD_User, string fullName, DateTime dateOfBirth, string gender, string cMND_CCCD, string address, string username, string password, string email, string phone, DateTime created_at, string role, string status_user) : this(iD_User, fullName, dateOfBirth, gender, cMND_CCCD, address, username, password, email, phone)
        {
            this.created_at = created_at;
            this.role = role;
            this.status_user = status_user;
        }
        public ModelUser(string fullname, string cmnd_cccd, string email, string phone)
        {
            this.FullName = fullname;
            this.CMND_CCCD = cmnd_cccd;
            this.Email= email;
            this.Phone = phone;
        }
        public ModelUser GetUser(MySqlDataReader reader)
        {
            ModelUser uss = new ModelUser(
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
            return uss;
        }
    }
}
