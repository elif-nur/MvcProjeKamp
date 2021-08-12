using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin Find(string username, string password)
        {
            return _adminDal.Find(username, password);
        }

        public Admin GetById(int adminId)
        {
            return _adminDal.Get(x => x.AdminId == adminId);
        }

        public List<Admin> List()
        {
            return _adminDal.List();
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
