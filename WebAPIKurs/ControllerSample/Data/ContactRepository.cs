using ControllerSample.Models;
using System.Collections.Concurrent;

namespace ControllerSample.Data
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<string, Contact> _contacts =
            new ConcurrentDictionary<string, Contact>();

        public ContactRepository()
        {
            Add(new Contact { FirstName = "Nancy", LastName = "Davolio" });
        }

        public void Add(Contact contact)
        {
            //Guid id = Guid.NewGuid();

            contact.ID = Guid.NewGuid().ToString(); //5B7EEBC0-E655-40C5-A97F-67A4319E1CDE
            _contacts[contact.ID] = contact;
        }

        public Contact Get(string id)
        {
            _contacts.TryGetValue(id, out Contact contact);
            return contact;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public Contact Remove(string id)
        {
            _contacts.TryRemove(id, out Contact contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.ID] = contact;
        }
    }
}
