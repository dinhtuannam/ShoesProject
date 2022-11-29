using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_Employee
    {
        private string id;
        private string username;   
        private string password;
        private string status;
        private string permission;
        private string fullname;
        private string phone;
        private string address;
        private string email;

        public DTO_Employee(string _Id, string _Username, string _Password, string _Status, string _Permission, string _Fullname, string _Phone, string _Address, string _Email)
        {
            id = _Id;
            username = _Username;
            password = _Password;
            status = _Status;
            permission = _Permission;
            fullname = _Fullname;
            phone = _Phone;
            address = _Address;
            email = _Email;
           
        }

        public DTO_Employee()
        {
            id = "";
            username = "";
            password = "";
            status = "";
            permission = "";
            fullname = "";
            phone = "";
            email = "";
            address = "";
        }

        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => status; set => status = value; }
        public string Permission { get => permission; set => permission = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public static object Instance { get; internal set; }
    }
}
