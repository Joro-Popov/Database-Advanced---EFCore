namespace CarDealer.App.Commands
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.Services.Contracts;
    using System;

    public class ExportCarsFromMakeFerrari : ICommand
    {
        private readonly ICarService carService;

        public ExportCarsFromMakeFerrari(ICarService carService)
        {
            this.carService = carService;
        }

        public string Execute()
        {
            this.carService.GerCarsFromMakeFerrari();

            return string.Format(Messages.SUCCESSFULL_EXPORT, "ferrari-cars.xml");
        }
    }
}
