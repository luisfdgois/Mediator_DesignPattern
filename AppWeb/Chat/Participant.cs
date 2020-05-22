using System;

namespace AppWeb.Chat
{
    public class Participant
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Participant(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void Notify(string nameFrom, DateTime time, string message)
        {
            Console.WriteLine($"{nameFrom} às {time.ToString("hh mm ss")} \n {message}");
        }
    }
}
