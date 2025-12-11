namespace TRAQ_Assessment_MVC.Models.Person
{
    public class CreatePersonViewModel : BaseCommand
    {
        public int Code { get; set; }
        public string ID_Number { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
