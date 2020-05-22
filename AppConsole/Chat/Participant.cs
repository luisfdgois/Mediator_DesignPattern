using AppConsole.Pattern;

namespace AppConsole.Chat
{
    public class Participant : Component
    {
        public string Name { get; private set; }

        public Participant(string name) : base(name)
        {
            Name = name;
        }
    }
}
