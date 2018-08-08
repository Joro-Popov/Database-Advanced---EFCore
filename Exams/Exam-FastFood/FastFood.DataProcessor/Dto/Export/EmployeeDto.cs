namespace FastFood.DataProcessor.Dto.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeDto
    {
        public string Name { get; set; }

        public List<OrderDto> Orders { get; set; }

        public decimal TotalMoneyMade { get; set; }
    }
}
