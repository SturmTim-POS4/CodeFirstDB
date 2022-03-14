using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDB;

public class Employee
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    
    [NotMapped] public string EmployeeString => $"{Lastname} {Firstname}";
}