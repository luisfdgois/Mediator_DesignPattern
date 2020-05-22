using System;
using System.Collections.Generic;

namespace AppConsole.Pattern
{
    public class Mediator : IMediator
    {
        private Dictionary<object, Component> _components;

        public Mediator()
        {
            _components = new Dictionary<object, Component>();
        }

        public void Register(Component component)
        {
            if (!_components.ContainsValue(component))
            {
                _components[component.Id] = component;
            }

            component.Participate(this);
        }

        public void Send(object from, object to, object message)
        {
            try
            {
                var component = _components[to];
                component.Notify(from, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
