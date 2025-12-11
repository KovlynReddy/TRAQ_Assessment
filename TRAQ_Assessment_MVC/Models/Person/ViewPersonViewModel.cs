using TRAQ_Assessment_MVC.Models.Account;

namespace TRAQ_Assessment_MVC.Models.Person;

public class ViewPersonViewModel : BaseViewModel
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string ID_Number { get; set; }
    public string Surname { get; set; }
    public List<ViewAccountViewModel> Accounts { get; set; }
}
