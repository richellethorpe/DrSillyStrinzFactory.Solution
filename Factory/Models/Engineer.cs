using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Factory.Models

{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "The engineer's first name cannot be empty")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "The engineer's last name cannot be empty")]
    public string LastName { get; set; }

    public string DateOfHire { get; set; }

    public List<EngineerMachineJoin> EngineerMachineJoins { get; }
  }
}