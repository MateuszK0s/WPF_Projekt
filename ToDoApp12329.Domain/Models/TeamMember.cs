using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp12329.Domain.Models
{
    public class TeamMember : DomainModel
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }

        public string MemberFullName
        {
            get
            {
                return $"{MemberName} {MemberSurname}";
            }
        }
    }
}
