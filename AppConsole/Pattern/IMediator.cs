namespace AppConsole.Pattern
{
    public interface IMediator
    {
        void Register(Component component);
        void Send(object from, object to, object message);
    }
}
