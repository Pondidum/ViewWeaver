using System;
using System.Windows.Forms;
using Machine.Specifications;
using ViewWeaver.Helpers;

namespace ViewWeaver.Specs.Helpers.GridPopulation.ControlStateSpecs
{
	namespace GetState
	{
		public class When_passed_a_null_control : ControlStateSpecBase
		{
			Because of = () => ex = Catch.Exception(() => ControlState.GetState(null));
			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_visible_enabled_control : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = true, Enabled = true };
			Because of = () => state = ControlState.GetState(control);
			It should_contain_no_flags = () => state.ShouldEqual(ControlState.States.Default);
		}

		public class When_passed_a_hidden_enabled_control : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = false, Enabled = true };
			Because of = () => state = ControlState.GetState(control);
			It should_be_hidden = () => state.ShouldEqual(ControlState.States.Hidden);
		}

		public class When_passed_a_visible_disabled_control : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = true, Enabled = false };
			Because of = () => state = ControlState.GetState(control);
			It should_be_disabled = () => state.ShouldEqual(ControlState.States.Disabled);
		}

		public class When_passed_a_hidden_disabled_control : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = false, Enabled = false };
			Because of = () => state = ControlState.GetState(control);
			It should_be_disabled_and_hidden = () => state.ShouldEqual(ControlState.States.Disabled | ControlState.States.Hidden);
		}
	}
}
