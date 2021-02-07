using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo Cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = Cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
