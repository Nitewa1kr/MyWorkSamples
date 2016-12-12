using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace NewUsersVERBs.Models
{
    public class NewUsers
    {
        [Key]
        public int UserID { get; set; }
        public string UserHandle { get; set; }
        public string UserPass { get; set; }
        public DateTime JoinDate { get; set; }
    }
}