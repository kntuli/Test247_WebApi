using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test247_WebApi.Models
{
    public class UserModel
    {
        public int userID { get; set; }
        //[Required(ErrorMessage = "Please enter SA Account")]
        public string username { get; set; }
        //[Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
