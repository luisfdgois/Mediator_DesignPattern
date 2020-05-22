using AppConsole.Chat;
using AppConsole.Pattern;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new Mediator();

            Participant luis = new Participant("Luis");
            Participant fernando = new Participant("Fernando");

            mediator.Register(luis);
            mediator.Register(fernando);

            luis.Send("Fernando", "Bom dia!");
        }
    }
}
