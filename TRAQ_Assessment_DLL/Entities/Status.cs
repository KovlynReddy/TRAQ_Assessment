namespace TRAQ_Assessment_DLL.Entities;

public class Status : BaseEntity
{
    public Statuses AccountStatus { get; set; }
    public int Account_Code { get; set; }
}

public enum Statuses { Open, Closed }
