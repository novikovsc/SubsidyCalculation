using System;

namespace SubsidyCalculation
{
    public class SubsidyCalc : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;
        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            OnNotify?.Invoke(this, $"Расчёт начат {DateTime.Now}");
            if (volumes.HouseId != tariff.HouseId)
            {
                OnException?.Invoke(this, null);
                throw new Exception("Error in HouseId");
            }
            else if (volumes.ServiceId != tariff.ServiceId)
            {
                OnException?.Invoke(this, null);
                throw new Exception("Error in ServiceId");
            }
            else if (volumes.Month <=  tariff.PeriodBegin || volumes.Month >= tariff.PeriodEnd)
            {
                OnException?.Invoke(this, null);
                throw new Exception("Error in Mounth");
            }
            else if (tariff.Value <= 0)
            {
                OnException?.Invoke(this, null);
                throw new Exception("Error in tariff value");
            }
            else if (volumes.Value < 0)
            {
                OnException?.Invoke(this, null);
                throw new Exception("Error in volume value");
            }
            else
            {
                OnNotify?.Invoke(this, $"Расчёт закончен {DateTime.Now}");
                return new Charge()
                {
                    ServiceId = volumes.ServiceId,
                    HouseId = volumes.HouseId,
                    Month = volumes.Month,
                    Value = volumes.Value * tariff.Value
                };
            }
        }

       
    }
}