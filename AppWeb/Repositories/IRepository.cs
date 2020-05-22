using AppWeb.Chat;
using System.Collections.Generic;

namespace AppWeb.Repositories
{
    public interface IRepository
    {
        List<Participant> Get();
        void Add(Participant participant);
    }
}
