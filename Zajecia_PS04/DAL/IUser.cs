using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_PS04.Models;

namespace Zajecia_PS04.DAL
{
    public interface IUser
    {
        public List<SiteUser> List();
        public SiteUser Get(int _id);
        public int Add(SiteUser _siteuser);
        public int Delete(int _id);
        public int Update(SiteUser _siteuser);
    }
}
