using System;

public class Seat : Car
{
    public Seat(string model, string color) : base(model, color)
    {
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model}{Environment.NewLine}" +
               $"{base.Start()}{Environment.NewLine}" +
               $"{base.Stop()}";
    }
}