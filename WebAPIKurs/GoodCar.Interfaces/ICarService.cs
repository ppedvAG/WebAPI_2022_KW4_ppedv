using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCar.Interfaces
{
    public interface ICarService
    {
        //Wir verwenden jetzt das interface ICar und nicht das object
        void Repair(ICar car);

        void RepairV2(ICarV2 carv2);
    }
}
