namespace ViewWeaver.Specs.EventAutoWirerSpecs
{
	public class AutoWirerSpecBase<TView> : SpecBase
	{
		protected static EventAutoWirer<TView> eventHook;
		protected static TView view;
	}
}
