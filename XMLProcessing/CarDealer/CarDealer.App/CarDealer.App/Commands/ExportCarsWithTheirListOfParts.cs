namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;
    using System;

    public class ExportCarsWithTheirListOfParts : ICommand
    {
        private readonly ICarService carService;

        public ExportCarsWithTheirListOfParts(ICarService carService)
        {
            this.carService = carService;
        }
        public string Execute()
        {
            this.carService.GetCarsWithTheirListOfParts();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "cars-and-parts.xml");
        }
    }
}
