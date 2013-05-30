using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ViewWeaver.Extensions;

namespace ViewWeaver
{
	public class EventAutoWirer<TView>
	{
		private readonly TView _view;
		private readonly Object _presenter;
		private readonly IDictionary<EventInfo, Delegate> _eventData;

		public const string HandlerPrefix = "On";

		public EventAutoWirer(TView view, Object presenter)
		{
			Check.Argument(view, "view");
			Check.Argument(presenter, "presenter");

			_view = view;
			_presenter = presenter;
			_eventData = new Dictionary<EventInfo, Delegate>();
		}

		public void Wire()
		{
			HookUpViewEvents();
		}

		public void Unwire()
		{
			foreach (var pair in _eventData)
			{
				pair.Key.RemoveEventHandler(_view, pair.Value);
			}
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
						.ToDictionary(x => x.Name, x => x);
		}

		private IDictionary<string, MethodInfo> GetPresenterEventHandlers(ICollection<string> actionProperties)
		{
			return _presenter.GetType()
							 .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
							 .Where(x => actionProperties.Contains(x.Name.Substring(HandlerPrefix.Length)))
							 .ToDictionary(x => x.Name, x => x);
		}

		private MethodInfo GetTheEventHandler(string viewDefinedEvent, IDictionary<string, MethodInfo> presenterEventHandlers, EventInfo eventInfo)
		{
			var handlerName = String.Format("{0}{1}", HandlerPrefix, viewDefinedEvent);

			if (!presenterEventHandlers.ContainsKey(handlerName))
			{
				throw new MissingEventHandlerException(eventInfo.Name, handlerName, _presenter.GetType().FullName);
			}

			return presenterEventHandlers[handlerName];
		}

		private Delegate WireUpTheEventAndEventHandler(EventInfo eventInfo, MethodInfo methodInfo)
		{
			var newDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, _presenter, methodInfo);
			eventInfo.AddEventHandler(_view, newDelegate);

			return newDelegate;
		}

	}
}
