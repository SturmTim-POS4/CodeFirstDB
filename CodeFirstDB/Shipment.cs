namespace CodeFirstDB;

public class Shipment
{
    public int Id { get; set; }
    public int SequenceNr { get; set; }
    public DateTime PlanDate { get; set; }
    public DateTime? DeliverDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}