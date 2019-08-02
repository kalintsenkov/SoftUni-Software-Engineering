namespace Service.Models.Devices
{
    using System;

    using Contracts;
    using Parts;

    public class PC : Device
    {
        public PC(string make) 
            : base(make)
        {

        }

        public override void AddPart(IPart part)
        {
            if (part.GetType() != typeof(PCPart))
            {
                throw new InvalidOperationException($"You cannot add {part.GetType().Name} to {this.GetType().Name}!");
            }

            base.AddPart(part);
        }
    }
}
