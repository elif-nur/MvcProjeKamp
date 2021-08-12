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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact GetById(int contactId)
        {
            return _contactDal.Get(x=>x.ContactId==contactId);
        }

        public List<Contact> List()
        {
            return _contactDal.List();
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
