namespace Patient_Management_System.Data;

public interface IEntity<T>
{
    T Id { get; set; }
}