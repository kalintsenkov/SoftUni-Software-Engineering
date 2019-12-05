namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
