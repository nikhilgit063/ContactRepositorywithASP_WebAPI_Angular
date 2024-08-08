using MajorProjctAPI.Model;
using System.Reflection.Metadata.Ecma335;

namespace MajorProjctAPI.iInterface
{
    public interface IContactRepository
    {
        Task<ReturnType<string>> AddContact(User user);
        Task<ReturnType<User>> get();
        Task<ReturnType<string>> UserContact_Delete(User user);
       // ReturnType<string> UpdateContact(User user);


    }
}
