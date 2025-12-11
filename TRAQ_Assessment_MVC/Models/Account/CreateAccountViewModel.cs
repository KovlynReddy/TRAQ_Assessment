namespace TRAQ_Assessment_MVC.Models.Account
{
    public class CreateAccountViewModel : BaseCommand
    {
        public int Code { get; set; }
        public int Person_Code { get; set; }
        public string Account_Number { get; set; }
        public decimal Outstanding_Balance { get; set; }
        public DateOnly OpenDateTime { get; set; }
    }
}
