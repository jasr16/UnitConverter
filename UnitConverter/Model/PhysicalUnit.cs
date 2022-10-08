using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Model
{
    public class PhysicalUnit
    {
        public enum UnitType
        {
            Length,
            Temperature,
            Volume,
            Mass,
            Area
        }

        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public UnitType Type { get; set; }
        public double RelationToBase { get; set; }
        public double[] RelationToBaseWithConstant { get; set; }

        public PhysicalUnit(string name, string abbreviation, UnitType unitType, double relationToBase)
        {
            Name = name;
            Abbreviation = abbreviation;
            Type = unitType;
            RelationToBase = relationToBase;
        }

        public PhysicalUnit(string name, string abbreviation, UnitType unitType, double[] relationToBaseWithConstant)
        {
            Name = name;
            Abbreviation = abbreviation;
            Type = unitType;
            RelationToBaseWithConstant = relationToBaseWithConstant;
        }


        public static List<PhysicalUnit> GetUnits()
        {
            // Length
            List<PhysicalUnit> units = new List<PhysicalUnit>() {
            new PhysicalUnit("meter", "m", UnitType.Length, 1),
            new PhysicalUnit("decimeter", "dm", UnitType.Length, 0.1),
            new PhysicalUnit("centimeter", "cm", UnitType.Length, 0.01),
            new PhysicalUnit("milimeter", "mm", UnitType.Length, 0.001),
            new PhysicalUnit("kilometer", "km", UnitType.Length, 1000),
            new PhysicalUnit("inch", "in", UnitType.Length, 0.0254),
            new PhysicalUnit("foot", "ft", UnitType.Length, 0.3048),
            new PhysicalUnit("yard", "yd", UnitType.Length, 0.9144),
            new PhysicalUnit("mile", "mi", UnitType.Length, 1609.344),

            // Temperature
            new PhysicalUnit("degree Celsius", "°C", UnitType.Temperature, new double[2]{1, 0}),
            new PhysicalUnit("degree Fahrenheit", "°F", UnitType.Temperature, new double[2]{5.0/9.0, -32*5.0/9.0}),

            // Volume
             new PhysicalUnit("liter", "l", UnitType.Volume, 1),
            new PhysicalUnit("deciliter", "dl", UnitType.Volume, 0.1),
            new PhysicalUnit("centiliter", "l", UnitType.Volume, 0.01),
            new PhysicalUnit("mililiter", "ml", UnitType.Volume, 0.001),
            new PhysicalUnit("hectoliter", "hl", UnitType.Volume, 100),
            new PhysicalUnit("cubic meter", "m^3", UnitType.Volume, 1000),
            new PhysicalUnit("cubic inch", "cu in", UnitType.Volume, 0.016387064),
            new PhysicalUnit("fluid ounce", "fl oz", UnitType.Volume, 0.0284130625),
            new PhysicalUnit("gill", "gi", UnitType.Volume, 0.1420653125),
            new PhysicalUnit("pint", "pt", UnitType.Volume, 0.56826125),
            new PhysicalUnit("quart", "qt", UnitType.Volume, 1.1365225),
            new PhysicalUnit("gallon", "gal", UnitType.Volume, 4.54609),

            // Mass
            new PhysicalUnit("kilogram", "kg", UnitType.Mass, 1),
            new PhysicalUnit("decagram", "dg", UnitType.Mass, 0.01),
            new PhysicalUnit("gram", "g", UnitType.Mass, 0.001),
            new PhysicalUnit("miligram", "mg", UnitType.Mass, 0.000001),
            new PhysicalUnit("metric ton", "t", UnitType.Mass, 1000),
            new PhysicalUnit("grain", "gr", UnitType.Mass, 0.00006479891),
            new PhysicalUnit("drachm", "dr", UnitType.Mass, 0.0017718451953125),
            new PhysicalUnit("ounce", "oz", UnitType.Mass, 0.028349523125),
            new PhysicalUnit("pound", "lb", UnitType.Mass, 0.45359237),
            new PhysicalUnit("stone", "st", UnitType.Mass, 6.35029318),
            new PhysicalUnit("quarter", "qtr", UnitType.Mass, 12.70058636),
            new PhysicalUnit("hundredweight", "cwt", UnitType.Mass, 50.80234544),
            new PhysicalUnit("(imperial) ton", "t", UnitType.Mass, 1016.0469088),

            //Area
            new PhysicalUnit("square meter", "m^2", UnitType.Area, 1),
            new PhysicalUnit("square decimeter", "dm^2", UnitType.Area, 0.01),
            new PhysicalUnit("square centimeter", "cm^2", UnitType.Area, 0.0001),
            new PhysicalUnit("square milimeter", "mm^2", UnitType.Area, 0.000001),
            new PhysicalUnit("ar", "ar", UnitType.Area, 100),
            new PhysicalUnit("hectar", "ha", UnitType.Area, 10000),
            new PhysicalUnit("square kilometer", "km^2", UnitType.Area, 1000000),
            new PhysicalUnit("perch", "perch", UnitType.Area, 25.29285264),
            new PhysicalUnit("rood", "rood", UnitType.Area, 1011.7141056),
            new PhysicalUnit("acre", "acre", UnitType.Area, 4046.8564224),
            new PhysicalUnit("square mile", "sq mi", UnitType.Area, 2589988.110336)
        };
            return units;
        }
    }

}
