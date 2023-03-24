using System.Collections.Generic;


namespace Factory.Models

{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string DateOfHire { get; set; }

    public List<EngineerMachineJoin> EngineerMachineJoins { get; }
  }
}