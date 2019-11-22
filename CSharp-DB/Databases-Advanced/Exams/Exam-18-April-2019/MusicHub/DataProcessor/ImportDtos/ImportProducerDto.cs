namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDto
    {
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        public ImportAlbumDto[] Albums { get; set; }
    }
}
