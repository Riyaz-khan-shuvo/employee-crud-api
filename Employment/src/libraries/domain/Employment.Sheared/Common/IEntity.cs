namespace Employment.Sheared.Common;

public interface IEntity<T> 
	where T :IEquatable<T>
{
	T Id { get; set; }	
}
public interface IEntity : IEntity<int> { }