using System;
using Machine.Specifications;
using System.Windows.Forms;
using ViewWeaver.Helpers;

namespace ViewWeaver.Specs.Helpers
{
    public class ControlStateSpec : SpecBase
    {
        protected static Control control;
        protected static ControlState.States state;
    }

    namespace GetState
    {
        [Subject("GetState")]
        public class When_passed_a_null_control : ControlStateSpec
        {
            Because of = () => ex = Catch.Exception(() => ControlState.GetState(null));
            It should_throw_an_argument_null_exception = () =>
            {
                ex.ShouldNotBeNull();
                ex.ShouldBeOfType<ArgumentNullException>();
            };
        }

        [Subject("GetState")]
        public class When_passed_a_visible_enabled_control : ControlStateSpec
        {
            Establish context = () => control = new Control() { Visible = true, Enabled = true };
            Because of = () => state = ControlState.GetState(control);
            It should_contain_no_flags = () => state.ShouldEqual(ControlState.States.Default);

        }

        [Subject("GetState")]
        public class When_passed_a_hidden_enabled_control : ControlStateSpec
        {
            Establish context = () => control = new Control() { Visible = false, Enabled = true };
            Because of = () => state = ControlState.GetState(control);
            It should_be_hidden = () => state.ShouldEqual(ControlState.States.Hidden);
        }

        [Subject("GetState")]
        public class When_passed_a_visible_disabled_control : ControlStateSpec
        {
            Establish context = () => control = new Control() { Visible = true, Enabled = false };
            Because of = () => state = ControlState.GetState(control);
            It should_be_disabled = () => state.ShouldEqual(ControlState.States.Disabled);
        }

        [Subject("GetState")]
        public class When_passed_a_hidden_disabled_control : ControlStateSpec
        {
            Establish context = () => control = new Control() { Visible = false, Enabled = false };
            Because of = () => state = ControlState.GetState(control);
            It should_be_disabled_and_hidden = () => state.ShouldEqual(ControlState.States.Disabled | ControlState.States.Hidden);
        }

    }

    namespace SetState
    {
        [Subject("SetState")]
        public class When_passed_a_null_control : ControlStateSpec
        {
            Because of = () => ex = Catch.Exception(() => ControlState.SetState(null, 0));
            It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>(); 
        }

        [Subject("SetState")]
        public class When_passed_and_hidden_and_disabled_control_and_the_default_flag : ControlStateSpec
        {
            Establish context = () => control = new Control() { Visible = false, Enabled = false };
            Because of = () => ControlState.SetState(control, ControlState.States.Default);
            It should_make_the_control_visible = () => control.Visible.ShouldBeTrue();
            It should_make_the_control_enabled = () => control.Enabled.ShouldBeTrue();
        }

        [Subject("SetState")]
        public class When_passed_a_visble_control_and_the_hidden_flag : ControlStateSpec
        {
            Establish context = () => control = new Control() {Visible = true};
            Because of = () => ControlState.SetState(control, ControlState.States.Hidden);
            It should_make_the_control_hidden = () => control.Visible.ShouldBeFalse();
        }

        [Subject("SetState")]
        public class When_passed_an_enabled_control_and_the_disable_flag : ControlStateSpec
        {
            Establish context = () => control = new Control() {Enabled = true};
            Because of = () => ControlState.SetState(control, ControlState.States.Disabled);
            It should_make_the_control_disabled = () => control.Enabled.ShouldBeFalse();
        }
    }

}
