namespace _04.Recharge
{
    using _04.Recharge.Contracts;

    public class RechargeStation
    {
        public void Recharge(IRechargeable rechargeable)
        {
            rechargeable.Recharge();
        }
    }
}