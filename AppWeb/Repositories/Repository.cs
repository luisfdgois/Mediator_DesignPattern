using AppWeb.Chat;
using System.Collections.Generic;

namespace AppWeb.Repositories
{
    public class Repository : IRepository
    {
        private List<Participant> _participants;

        public Repository()
        {
            _participants = new List<Participant>();
        }

        public void Add(Participant participant)
        {
            _participants.Add(participant);
        }

        public List<Participant> Get()
        {
            return _participants;
        }
    }
}
