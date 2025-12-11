namespace TRAQ_Assessment_MVC.Models.Transaction;

public class CreateTransactionViewModel : BaseCommand
{
    public int Code { get; set; }
    public int Account_Code { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Transaction_Date { get; set; }
    public DateTime Capture_Date { get; set; }
}
