using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class AdministratorRole
    {
        public int AdministratorRoleID { get; set; }
        public int AdministratorID { get; set; }
        public int RoleID { get; set; }
        public string Group { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Role Role { get; set; }
    }
}
