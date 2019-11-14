namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePositionInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string PositionName { get; set; }
    }
}
