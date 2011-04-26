using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ViewWeaver.Extensions;
using ViewWeaver.Interfaces;

namespace ViewWeaver
{
    public class Presenter<TView> : IDisposable where TView : class, IView
    {
        public TView View { get { return _view; }}

        public const string HandlerPrefix = "On";

        private readonly IDictionary<EventInfo, Delegate> _eventData;
        private readonly TView _view;

        private bool _disposed;

        public Presenter(TView view)
        {
            Check.Argument(view, "view");

            _view = view;
            _eventData = new Dictionary<EventInfo, Delegate>();
            _disposed = false;

            HookUpViewEvents();
        }


        private void HookUpViewEvents()
        {
            var viewDefinedEvents = GetViewDefinedEvents();
            var viewEvents = GetViewEvents(viewDefinedEvents);
            var presenterEventHandlers = GetPresenterEventHandlers(viewDefinedEvents);

            foreach (var viewDefinedEvent in viewDefinedEvents)
            {
                var eventInfo = viewEvents[viewDefinedEvent];
                var methodInfo = GetTheEventHandler(viewDefinedEvent, presenterEventHandlers, eventInfo);
                var theDelegate = WireUpTheEventAndEventHandler(eventInfo, methodInfo);

                _eventData.Add(eventInfo, theDelegate);

            }
        }

        private List<string> GetViewDefinedEvents()
        {
            return typeof(TView).GetEvents()
                                 .Select(x => x.Name)
                                 .ToList();
        }

        private IDictionary<string, EventInfo> GetViewEvents(ICollection<string> actionProperties)
        {
            return _view.GetType()
                        .GetEvents()
                        .Where(x => actionProperties.Contains(x.Name))
                        .ToDictionary(x => x.Name, x=> x);
        }

        private IDictionary<string, MethodInfo> GetPresenterEventHandlers(ICollection<string> actionProperties)
        {
            return GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => actionProperties.Contains(x.Name.Substring(HandlerPrefix.Length)))
                            .ToDictionary(x => x.Name, x => x);
        }

        private MethodInfo GetTheEventHandler(string viewDefinedEvent, IDictionary<string, MethodInfo> presenterEventHandlers, EventInfo eventInfo)
        {
            var handlerName = String.Format("{0}{1}", HandlerPrefix, viewDefinedEvent);

            if (!presenterEventHandlers.ContainsKey(handlerName))
            {
                throw new EventHandlerNotFoundException(eventInfo.Name, handlerName, GetType().FullName);
            }

            return presenterEventHandlers[handlerName];
        }

        private Delegate WireUpTheEventAndEventHandler(EventInfo eventInfo, MethodInfo methodInfo)
        {
            var newDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
            eventInfo.AddEventHandler(_view, newDelegate);

            return newDelegate;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                foreach (var pair in _eventData)
                {
                    pair.Key.RemoveEventHandler(_view, pair.Value);
                }
            }

            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}