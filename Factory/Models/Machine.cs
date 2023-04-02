using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Factory.Models

{
  public class Machine
  {
    public int MachineId { get; set; }

    [Required(ErrorMessage = "The machine's name cannot be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The machine's description cannot be empty")]
    public string Description { get; set; }

    public List<EngineerMachineJoin> EngineerMachineJoins { get; }
  }
} 