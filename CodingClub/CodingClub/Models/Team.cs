using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingClub.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Members { get; set; }
        public string ProjectName { get; set; }
    }
}
