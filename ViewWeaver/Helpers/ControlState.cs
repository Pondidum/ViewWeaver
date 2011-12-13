using System;
using System.Windows.Forms;
using ViewWeaver.Extensions;

namespace ViewWeaver.Helpers
{
    public static class ControlState
    {
        public static void SetState(this Control control, States state)
        {
            Check.Self(control, "control");
            Check.Self(state, "state");

            control.Enabled = !state.Has(States.Disabled);
            control.Visible = !state.Has(States.Hidden);
        }

        public static States GetState(this Control control)
        {
            Check.Self(control, "control");

            var result = States.Default;

            if (!control.Enabled) result = result.Add(States.Disabled);
            if (!control.Visible) result = result.Add(States.Hidden);

            return result;
        }

        [Flags]
        public enum States
        {
            Default = 0,
            Disabled = 1,
            Hidden = 2,
        }
    }
}