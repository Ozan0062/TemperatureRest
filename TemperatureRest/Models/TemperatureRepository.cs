using System.Security.Cryptography.X509Certificates;

namespace TemperatureRest.Models
{
    public class TemperatureRepository
    {
        private List<TemperatureLib> _temperatures = new List<TemperatureLib>();
        private int _nextId = 1;

        public TemperatureRepository(List<TemperatureLib> temperatures)
        {
            _temperatures = temperatures;
        }

        public TemperatureRepository()
        {
            _temperatures.Add(new TemperatureLib { Id = _nextId++, Temperature = "10" });
            _temperatures.Add(new TemperatureLib { Id = _nextId++, Temperature = "20" });
        }

        public IEnumerable<TemperatureLib> Get()
        {
            IEnumerable<TemperatureLib> copyTemperatures = new List<TemperatureLib>(_temperatures);
            return copyTemperatures;
        }

        public TemperatureLib Add(TemperatureLib temperatureLib)
        {
            if (temperatureLib == null)
            {
                throw new ArgumentNullException("temperatureLib");
            }
            temperatureLib.Id = _nextId++;
            _temperatures.Add(temperatureLib);
            return temperatureLib;
        }
    }
}
