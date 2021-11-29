using System;

namespace Wasted.Data
{
    public struct Product
    {
        public int Id;
        private string _name;
        private string _type;
        private string _measurementUnits;
        private double _energyValue;

        public string Name { 
            get { return _name; }
            set { _name = value; }
        }

        public string Type { 
            get => _type;
            set => _type = value;
        }

        public string MeasurementUnits { 
            get { return _measurementUnits; }
            set { _measurementUnits = value; }
        }

        public double EnergyValue { 
            get => _energyValue;
            set => _energyValue = value; 
        }
    }
}
