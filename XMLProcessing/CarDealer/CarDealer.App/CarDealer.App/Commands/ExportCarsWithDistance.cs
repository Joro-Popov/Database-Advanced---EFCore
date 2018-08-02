namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;

    public class ExportCarsWithDistance : ICommand
    {
        private readonly ICarService carService;

        public ExportCarsWithDistance(ICarService carService)
        {
            this.carService = carService;
        }

        public string Execute()
        {
            this.carService.GetCarsWithDistance();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "cars - exported.xml");
        }
    }
}
