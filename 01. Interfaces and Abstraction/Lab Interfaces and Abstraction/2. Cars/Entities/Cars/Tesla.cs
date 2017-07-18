using System;

public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int batteries) : base(model, color)
    {
        this.Battery = batteries;
    }

    public int Battery { get; private set; }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries{Environment.NewLine}" +
               $"{base.Start()}{Environment.NewLine}" +
               $"{base.Stop()}";
    }
}