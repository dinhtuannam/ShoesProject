using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_Customer
    {
        string id;
        string username;
        string password;
        string status;
        string role;
        string fullname;
        string phone;
        string email;
        string address;

        public DTO_Customer(string id_, string username_, string password_, string status_, string role_, string fullname_, string phone_, string email_, string address_)
        {
            id = id_;
            username = username_;
            password = password_;
            status = status_;   
            role = role_;   
            fullname = fullname_;   
            phone = phone_; 
            email = email_; 
            address = address_; 
        }

        public DTO_Customer()
        {
            id = "";
            username = "";
            password = "";
            status = "";
            role = "";
            fullname = "";
            phone = "";
            email = "";
            address = "";
        }

        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => status; set => status = value; }
        public string Role { get => role; set => role = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
    }
}
