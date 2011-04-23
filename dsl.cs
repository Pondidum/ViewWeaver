
flxgrid.PopulateFrom(candidates).AutomaticColumns()
								.CreateMissingColumns();

flxgrid.PopulateFrom(candidates).Column(0, c => c.FirstName)
								.Column(1, c => c.LastName);
								
								
internal class Configuration<T>
{
	public Dictionary<int, Func<T, Object> ColumnMappings { get; private set; }
	public bool CreateMissingColumns { get; private set; }
	public bool ClearOnPopulate { get; private set; }
}

public class FluentConfigureation<T> 
{
	private readonly Configuration<T> _config;
	
	internal FluentConfigureation(Configuration<T> config)
	{
		_config = config;
	}

	public FluentConfiguration<T> AutomaticColumns() { _config.ColumnMappings = ColumnMapper.Map<T>(); }
	public FluentConfiguration<T> CreateMissingColumns() { _config.CreateMissingColumns = true; }
	public FluentConfiguration<T> Columns(int index, Func<T, Object> creator) { _config.ColumnMappings.Add(index, creator); }
	public FluentConfiguration<T> ClearOnPopulate() { _config.ClearOnPopulate = true; }
}


flxgrid.Setup<TCollection>().AutomaticColumns()
							.CreateMissingColumns()
							.ClearOnRepopulate();

flxgrid.Populate(_people);


static class Extensions
{
	public void Setup<TCollection>(this Control control)
	public void Populate(this Control control, ICollection collection)
}

public class GridHandler()
{
	static void Setup(Control grid, FluentConfiguration config)
	{}
	
	static void Populate(Control grid, IEnumarable collection)
	{}
}

internal class GridHandlerImpl
{
	private readonly IDictionary<Control, Configuration> _grids;
	private readonly IDictionary<Type, IGridPopulator> _populators;
	
	static GridHandlerImpl()
	{
		_grids = new Dictionary<Control, Configuration>();
		_populators = new Dictionary<Type, IGridPopulator>();
	}
	
	public FluentConfiguration<T> Setup<T>(Control grid)
	{
		Check.Self(grid, "grid")
		
		var config = new Configuration<T>();
		
		_grids[grid] = config;
		return new FluentConfiguration<T>(confgig);
	}
	
	public void Populate(Control grid, IEnumarable collection)
	{
		Check.Self(grid, "grid")
		
		var config = _grids[grid];
		var populator = _populators[grid.GetType()];
		
		if (config == null) throw new InvalidConfigurationException(_grid.Name & " has not been setup");
		if (populator == null) throw new InvalidConfigurationException(string.Format("There is no populator setup for grids of type '{0}'", grid.GetType().Name))
	
		if (config.ClearRows) populator.ClearRows(grid);
		if (config.
	}
}


