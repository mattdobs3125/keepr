using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Img { get; set; } = "";
        public bool IsPrivate { get; set; } = false;
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        [MaxLength(225)]
public string Description { get; set; }
[Required]
public string UserId { get; set; }
public Keep()
{
    
}

public Keep(string name, string description, string userid,bool isprivate,string img )
{
    Name = name;
    Description = description;
    UserId = userid;
    IsPrivate = isprivate;
    Img = img;
    
}
    }

}