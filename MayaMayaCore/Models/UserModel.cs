using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMayaCore.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime LastLogin { get; set; }
        public List<string> Roles { get; set; }
    }
}
