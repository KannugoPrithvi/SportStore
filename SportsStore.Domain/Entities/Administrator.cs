using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastLogin { get; set; }
        public bool IsActive { get; set; }
        public string Group { get; set; }

        public virtual ICollection<AdministratorRole> AdministratorRoles { get; set; }
    }
}
