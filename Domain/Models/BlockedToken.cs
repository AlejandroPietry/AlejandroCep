using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BlockedToken
    {
        public int Id { get; set; }
        public string JwtToken { get; set; }
    }
}
