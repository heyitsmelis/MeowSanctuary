namespace MeowSanctuary.Models
{
    public class WorkSchedule
    {
        public Guid WorkerId { get; set; }
        public Worker Worker { get; set; }
        public Guid CatId { get; set; }
        public Cat Cat { get; set;}
         
    }
}
