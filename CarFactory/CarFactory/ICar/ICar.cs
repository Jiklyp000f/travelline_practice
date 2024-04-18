using CarFactory.Models.CarColor;
using CarFactory.Models.CarTranmisson;
using CarFactory.Models.CarFormType;
using CarFactory.Models.CarEngine;

namespace CarFactory.Models.Car
{
    public interface ICar
    {
        public ICarColor Color { get; }
        public ITransmission Transmission { get; }
        public ICarFormType FormType { get; }
        public IEngine Engine { get; }

    }

}

