namespace CarDealer.DTO
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class CarPartsDto
    {
        [JsonProperty("car")]
        public ExportCarDto Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartDto> Parts { get; set; }
    }
}
