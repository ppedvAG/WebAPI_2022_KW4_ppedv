using ControllerSample.Models;

namespace ControllerSample.Data
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Get(string key);
        Contact Remove(string key);
        void Update(Contact contact);
    }
}
