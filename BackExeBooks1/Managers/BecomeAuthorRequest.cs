using BackExeBooks1.Models;
using System.ComponentModel.DataAnnotations;

namespace BackExeBooks1.Managers
{
    public class BecomeAuthorRequest
    {
        public string Name { get; set; }
        public string Familiya { get; set; }
        public string Otchestvo { get; set; }
        public double procent { get; set; }
        public int UserId { get; set; }
    }
}
