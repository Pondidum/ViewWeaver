using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Interfaces;

namespace ViewWeaver.Specs
{

    public class When_passed_a_null_view : SpecBase
    {
        protected static IView view;
        protected static Presenter<IView> presenter;

        Establish context = () => view = null;
        Because of = () => ex = Catch.Exception(() => presenter = new Presenter<IView>(view));
        It should_throw_an_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
    }

    public class When_passed_a_view_with_no_events : SpecBase
    {
        protected static ViewNoEvents view;
        protected static Presenter<ViewNoEvents> presenter;

        Establish context = () => view = new ViewNoEvents();
        Because of = () => ex = Catch.Exception(() => presenter = new Presenter<ViewNoEvents>(view));
        It should_not_throw_an_exception = () => ex.ShouldBeNull();
    }

    public class When_passed_a_view_with_a_matching_private_event_handler_in_the_presenter : SpecBase
    {
        static ViewOneEvent view;
        static PresenterOnePrivateHandler presenter;

        Establish context = () => view = new ViewOneEvent();
        Because of = () => presenter = new PresenterOnePrivateHandler(view);
        It should_connect_one_subscriber = () => presenter.View.Subscribers().Count().ShouldEqual(1);
    }

    public class When_passed_a_view_with_a_matching_public_event_handler_in_the_presenter : SpecBase
    {
        static ViewOneEvent view;
        static PresenterOnePublicHandler presenter;

        Establish context = () => view = new ViewOneEvent();
        Because of = () => ex = Catch.Exception(() => presenter = new PresenterOnePublicHandler(view));
        It should_not_connect_any_subscribers = () => view.Subscribers().Count().ShouldEqual(0);
        It should_throw_an_event_handler_not_found_exception = () => ex.ShouldBeOfType<EventHandlerNotFoundException>();
    }

    public class When_a_presenter_is_disposed : SpecBase
    {
        static ViewOneEvent view;
        static PresenterOnePrivateHandler presenter;

        Establish context = () =>
                                {
                                    view = new ViewOneEvent();
                                    presenter = new PresenterOnePrivateHandler(view);
                                };
        Because of = () => presenter.Dispose();
        It should_disconnect_subscribed_events = () => presenter.View.Subscribers().Count().ShouldEqual(0);
    }


    public class ViewNoEvents : IView
    {
        public void Show() { }
    }

    public class ViewOneEvent : IView
    {
        public event EventAction ButtonClicked;
        public void Show() { }

        public Delegate[] Subscribers()
        {
            if (ButtonClicked == null)
            {
                return new Delegate[0];
            }

            return ButtonClicked.GetInvocationList();
        }
    }

    public class PresenterOnePrivateHandler : Presenter<ViewOneEvent>
    {
        public PresenterOnePrivateHandler(ViewOneEvent view) : base(view) { }
        private void OnButtonClicked() { }
    }

    public class PresenterOnePublicHandler : Presenter<ViewOneEvent>
    {
        public PresenterOnePublicHandler(ViewOneEvent view) : base(view) { }
        public void OnButtonClicked() { }
    }
}