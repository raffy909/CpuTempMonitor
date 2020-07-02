using OpenHardwareMonitor.Hardware;
using Swan.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempMonitorWS
{
    static class CpuTempMonitor
    {
        private static readonly Computer computer = new Computer() { CPUEnabled = true };

        public static List<CpuTemp> GetCpuTemps()
        {

            List<CpuTemp> ret = new List<CpuTemp>();

            try
            {
                computer.Open();

                IHardware[] cpus = Array.FindAll(computer.Hardware, h => h.HardwareType.ToString().Contains("CPU"));

                foreach (IHardware cpu in cpus)
                {
                    List<CpuTempSensor> tempSensors = new List<CpuTempSensor>();

                    cpu.Update();

                    foreach (ISensor s in cpu.Sensors)
                    {

                        if (s.SensorType.Equals(SensorType.Temperature))
                        {
                            CpuTempSensor tempSensor = new CpuTempSensor
                            {
                                Name = s.Name,
                                Index = s.Index,
                                Temp = s.Value
                            };

                            tempSensors.Add(tempSensor);
                        }
                    }

                    CpuTemp cpuTemp = new CpuTemp()
                    {
                        Name = cpu.Name,
                        Sensors = tempSensors
                    };

                    ret.Add(cpuTemp);
                }
            }
            catch (Exception e)
            {
                $"Exception - {e.Message}".Error();
            }

            return ret;
        }
    }
}
