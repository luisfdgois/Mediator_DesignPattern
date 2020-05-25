using MediatR;

namespace AppWeb.Communications
{
    public class Join : INotification
    {
        public string Name { get; private set; }

        public Join(string name)
        {
            Name = name;
        }
    }
}
