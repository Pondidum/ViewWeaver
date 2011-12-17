using System;
using Machine.Specifications;
using System.Windows.Forms;
using ViewWeaver.Helpers;

namespace ViewWeaver.Specs.Helpers.GridPopulation.ControlStateSpecs
{
	namespace SetState
	{
		public class When_passed_a_null_control : ControlStateSpecBase
		{
			Because of = () => ex = Catch.Exception(() => ControlState.SetState(null, 0));
			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_and_hidden_and_disabled_control_and_the_default_flag : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = false, Enabled = false };
			Because of = () => ControlState.SetState(control, ControlState.States.Default);
			It should_make_the_control_visible = () => control.Visible.ShouldBeTrue();
			It should_make_the_control_enabled = () => control.Enabled.ShouldBeTrue();
		}

		public class When_passed_a_visble_control_and_the_hidden_flag : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Visible = true };
			Because of = () => ControlState.SetState(control, ControlState.States.Hidden);
			It should_make_the_control_hidden = () => control.Visible.ShouldBeFalse();
		}

		public class When_passed_an_enabled_control_and_the_disable_flag : ControlStateSpecBase
		{
			Establish context = () => control = new Control() { Enabled = true };
			Because of = () => ControlState.SetState(control, ControlState.States.Disabled);
			It should_make_the_control_disabled = () => control.Enabled.ShouldBeFalse();
		}
	}

}
