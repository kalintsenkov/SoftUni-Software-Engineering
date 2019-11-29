namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        public int OfficerId { get; set; }

        public Officer Officer { get; set; }

        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }
    }
}
