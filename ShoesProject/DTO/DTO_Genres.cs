using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_Genres
    {
        String id;
        String name;    
        String status;

        public DTO_Genres(string id_, string name_, string status_)
        {
            this.id = id_;
            this.name = name_;
            this.status = status_;
        }   

        public DTO_Genres()
        {
            id = "";
            name = "";
            status = "";
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
