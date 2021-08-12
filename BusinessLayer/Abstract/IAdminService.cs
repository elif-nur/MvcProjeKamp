using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> List();
        void Add(Admin admin);
        void Delete(Admin admin);
        Admin GetById(int adminId);
        void Update(Admin admin);
        Admin Find(string username, string password);
    }
}
