using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.Transaction;

namespace TRAQ_Assessment_MVC.Models.Account;

public class ViewAccountViewModel : BaseViewModel
{
    public int Code { get; set; }
    public int Person_Code { get; set; }
    public string Account_Number { get; set; }
    public decimal Outstanding_Balance { get; set; }
    public DateOnly OpenDateTime { get; set; }

    public List<ViewTransactionViewModel> Transactions { get; set; }

    public ViewPersonViewModel HolderDetails { get; set; }
}
