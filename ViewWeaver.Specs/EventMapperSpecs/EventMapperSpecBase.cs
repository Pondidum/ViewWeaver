namespace ViewWeaver.Specs.EventMapperSpecs
{
	public class AutoWirerSpecBase<TView> : SpecBase
	{
		protected static EventMapper<TView> eventHook;
		protected static TView view;
	}
}
