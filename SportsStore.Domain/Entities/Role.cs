using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }

        public virtual ICollection<AdministratorRole> AdministratorRoles { get; set; }
    }
}
