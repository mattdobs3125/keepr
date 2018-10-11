using System.ComponentModel.DataAnnotations;

namespace keepr.Models

{
public class Vault 
{
    public string UserId { get; set; }
public int Id { get; set; }
[Required]
[MaxLength(20)]
public string Name { get; set; }
[Required]
[MaxLength(255)]
public string Description { get; set; }
public Vault()
{}

}


}