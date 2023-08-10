namespace Domain;

public class Unit
{
public int Id { get; set; }
public string Symbol { get; set; }  
public string Description { get; set; }

  public enum Units
  {
    ///<summary>Pounds</summary>
    lb = 1,
    ///<summary>Kilograms</summary>
    kg = 2,
    ///<summary>Stone</summary>
    st = 3
  }
}
