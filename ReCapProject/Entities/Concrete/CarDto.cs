using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarDto:IEntity
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{CarId} {BrandName} {ColorName} {ModelYear} {DailyPrice} {Description}";
        }
    }
}
