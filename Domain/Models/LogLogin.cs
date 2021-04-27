using System;

namespace Domain.Models
{
    public class LogLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Dta_Exp { get; set; }


        public bool IsActive()
        {
            if (DateTime.Now < Dta_Exp)
                return true;
            else
                return false;
        }
    }
}
