using System;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Interfaces;
using ViewWeaver.Specs.TestData.Mvp;

namespace ViewWeaver.Specs.EventMapperSpecs
{
	public class When_passed_a_null_view : AutoWirerSpecBase<IEmptyView>
	{
		Because of = () => ex = Catch.Exception(() => eventHook = new EventMapper<IEmptyView>(null, new EmptyPresenter()));

		It should_throw_a_null_argument_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_passed_a_null_presenter : AutoWirerSpecBase<IEmptyView>
	{
		Because of = () => ex = Catch.Exception(() => eventHook = new EventMapper<IEmptyView>(new EmptyView(), null));

		It should_throw_a_null_argument_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_passed_a_view_with_no_events : AutoWirerSpecBase<IEmptyView>
	{
		private static EmptyPresenter presenter;

		Establish context = () =>
		{
			view = new EmptyView();
			presenter = new EmptyPresenter();
			eventHook = new EventMapper<IEmptyView>(view, presenter);
		};

		Because of = () => ex = Catch.Exception(() => eventHook.Wire());

		It should_not_do_anything = () => ex.ShouldBeNull();
	}

	public class When_passed_a_view_with_one_matching_event : AutoWirerSpecBase<IOneEventView>
	{
		private static OneEventPresenter presenter;

		Establish context = () =>
		{
			view = new OneEventView();
			presenter = new OneEventPresenter();
			eventHook = new EventMapper<IOneEventView>(view, presenter);
		};

		Because of = () => ex = Catch.Exception(() => eventHook.Wire());

		It should_hook_the_even_to_the_handler = () => ((OneEventView)view).SaveSubscribers().Count().ShouldEqual(1);
	}

	public class When_passed_a_view_with_an_event_not_in_the_interface : AutoWirerSpecBase<IOneEventView>
	{
		private static OneEventPresenter presenter;

		Establish context = () =>
		{
			view = new OneDefinedEventView();
			presenter = new OneEventPresenter();
			eventHook = new EventMapper<IOneEventView>(view, presenter);
		};

		Because of = () => ex = Catch.Exception(() => eventHook.Wire());

		It should_hook_the_defined_event = () => ((OneDefinedEventView)view).SaveSubscribers().Count().ShouldEqual(1);
		It shouldnt_hook_the_undefined_event = () => ((OneDefinedEventView)view).CancelSubscribers().Count().ShouldEqual(0);
	}

	public class When_passed_a_presenter_without_a_handler_for_an_event : AutoWirerSpecBase<IOneEventView>
	{
		private static NoEventPresenter presenter;

		Establish context = () =>
		{
			view = new OneEventView();
			presenter = new NoEventPresenter();
			eventHook = new EventMapper<IOneEventView>(view, presenter);
		};

		Because of = () => ex = Catch.Exception(() => eventHook.Wire());

		It should_throw_a_missing_handler_exception = () => ex.ShouldBeOfType<MissingEventHandlerException>();
	}

	public class When_unwiring_events : AutoWirerSpecBase<IOneEventView>
	{
		private static OneEventPresenter presenter;

		Establish context = () =>
			{
				view = new OneEventView();
				presenter = new OneEventPresenter();
				eventHook = new EventMapper<IOneEventView>(view, presenter);
				eventHook.Wire();
			};

		Because of = () => eventHook.Unwire();

		It should_remove_subsciptions_to_events = () => ((OneEventView) view).SaveSubscribers().Count().ShouldEqual(0);
	}
}
