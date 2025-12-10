namespace TRAQ_Assessment_MVC.Models.User
{
    public class CreateUserViewModel : BaseCommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
