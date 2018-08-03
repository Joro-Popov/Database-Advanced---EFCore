namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;

    public class ExportCarsFromMakeToyota : ICommand
    {
        private readonly ICarService carService;

        public ExportCarsFromMakeToyota(ICarService carService)
        {
            this.carService = carService;
        }

        public string Execute()
        {
            this.carService.GerCarsFromMakeToyota();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "toyota-cars.json");
        }
    }
}