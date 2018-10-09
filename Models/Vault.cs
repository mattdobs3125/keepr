using System.ComponentModel.DataAnnotations;

namespace keepr.Models

{
public class Vault 
{
public int Id { get; set; }

public string Username { get; set; }
[MaxLength(255)]
[Required]
public string Description { get; set; }
}

}