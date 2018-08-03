namespace CarDealer.Models.DTOs
{
    public class ToyotaDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public ulong TravelledDistance { get; set; }
    }
}