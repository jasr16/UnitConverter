// using Android.App.AppSearch;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace UnitConverter;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
        InitializeComponent();
        InitializeLengthElements();
        InitializeAreaElements();
        InitializeVolumeElements();
        InitializeMassElements();
    }

    public void InitializeLengthElements()
    {
        List<PhysicalUnit> lengthUnits = PhysicalUnit.GetLengthUnits();
        upperLengthPicker.ItemsSource = lengthUnits;
        upperLengthPicker.ItemDisplayBinding = new Binding("Name");
        upperLengthPicker.SelectedItem = (PhysicalUnit)lengthUnits.Where(x => x.Name == "meter").First();
        lowerLengthPicker.ItemsSource = lengthUnits;
        lowerLengthPicker.ItemDisplayBinding = new Binding("Name");
        lowerLengthPicker.SelectedItem = (PhysicalUnit)lengthUnits.Where(x => x.Name == "inch").First();
    }

    public void InitializeAreaElements()
    {
        List<PhysicalUnit> areaUnits = PhysicalUnit.GetAreaUnits();
        upperAreaPicker.ItemsSource = areaUnits;
        upperAreaPicker.ItemDisplayBinding = new Binding("Name");
        upperAreaPicker.SelectedItem = (PhysicalUnit)areaUnits.Where(x => x.Name == "square meter").First();
        lowerAreaPicker.ItemsSource = areaUnits;
        lowerAreaPicker.ItemDisplayBinding = new Binding("Name");
        lowerAreaPicker.SelectedItem = (PhysicalUnit)areaUnits.Where(x => x.Name == "acre").First();
    }

    public void InitializeVolumeElements()
    {
        List<PhysicalUnit> volumeUnits = PhysicalUnit.GetVolumeUnits();
        upperVolumePicker.ItemsSource = volumeUnits;
        upperVolumePicker.ItemDisplayBinding = new Binding("Name");
        upperVolumePicker.SelectedItem = (PhysicalUnit)volumeUnits.Where(x => x.Name == "liter").First();
        lowerVolumePicker.ItemsSource = volumeUnits;
        lowerVolumePicker.ItemDisplayBinding = new Binding("Name");
        lowerVolumePicker.SelectedItem = (PhysicalUnit)volumeUnits.Where(x => x.Name == "pint").First();
    }

    public void InitializeMassElements()
    {
        List<PhysicalUnit> massUnits = PhysicalUnit.GetMassUnits();
        upperMassPicker.ItemsSource = massUnits;
        upperMassPicker.ItemDisplayBinding = new Binding("Name");
        upperMassPicker.SelectedItem = (PhysicalUnit)massUnits.Where(x => x.Name == "kilogram").First();
        lowerMassPicker.ItemsSource = massUnits;
        lowerMassPicker.ItemDisplayBinding = new Binding("Name");
        lowerMassPicker.SelectedItem = (PhysicalUnit)massUnits.Where(x => x.Name == "pound").First();
    }


    public void ConvertUnits(object entry, object upperItemPicker, object lowerItemPicker, object label)
    {
        Entry upperEntry = (Entry)entry;
        Picker upperPicker = (Picker)upperItemPicker;
        Picker lowerPicker = (Picker)lowerItemPicker;
        Label lowerLabel = (Label)label;

        if (upperEntry.Text == String.Empty || upperEntry.Text == null)
        {
            lowerLabel.Text = "Converted value";
            return;
        }
        bool success = double.TryParse(upperEntry.Text, out double enteredValue);
        if (!success)
        {
            lowerLabel.Text = "Incorrect value entered";
            return;
        }   
        PhysicalUnit upperUnit = (PhysicalUnit)upperPicker.SelectedItem;
        PhysicalUnit lowerUnit = (PhysicalUnit)lowerPicker.SelectedItem;
        if (upperUnit == null || lowerUnit == null)
        {
            lowerLabel.Text = "Incorrect unit selected";
            return;
        }     
        lowerLabel.Text = Math.Round(enteredValue * upperUnit.RelationToBase / lowerUnit.RelationToBase, 12).ToString();
    }

    private void upperAreaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits(upperAreaEntry, upperAreaPicker, lowerAreaPicker, lowerAreaLabel);
    }

    private void upperAreaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits(upperAreaEntry, upperAreaPicker, lowerAreaPicker, lowerAreaLabel);
    }

    private void upperVolumeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits(upperVolumeEntry, upperVolumePicker, lowerVolumePicker, lowerVolumeLabel);
    }

    private void upperVolumePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits(upperVolumeEntry, upperVolumePicker, lowerVolumePicker, lowerVolumeLabel);
    }

    private void upperMassEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits(upperMassEntry, upperMassPicker, lowerMassPicker, lowerMassLabel);
    }

    private void upperMassPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits(upperMassEntry, upperMassPicker, lowerMassPicker, lowerMassLabel);
    }

    private void upperLengthEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits(upperLengthEntry, upperLengthPicker, lowerLengthPicker, lowerLengthLabel);
    }

    private void upperLengthPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits(upperLengthEntry, upperLengthPicker, lowerLengthPicker, lowerLengthLabel);
    }
}

public class PhysicalUnit
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string UnitSystem { get; set; }
    public double RelationToBase { get; set; }

    public PhysicalUnit(string name, string abbreviation, string unitSystem, double relationToBase)
    {
        Name = name;
        Abbreviation = abbreviation;
        UnitSystem = unitSystem;
        RelationToBase = relationToBase;
    }


    public static List<PhysicalUnit> GetLengthUnits()
    {
        List<PhysicalUnit> lengthUnits = new List<PhysicalUnit>() {
            new PhysicalUnit("meter", "m", "metric", 1),
            new PhysicalUnit("decimeter", "dm", "metric", 0.1),
            new PhysicalUnit("centimeter", "cm", "metric", 0.01),
            new PhysicalUnit("milimeter", "mm", "metric", 0.001),
            new PhysicalUnit("kilometer", "km", "metric", 1000),
            new PhysicalUnit("inch", "in", "imperial", 0.0254),
            new PhysicalUnit("foot", "ft", "imperial", 0.3048),
            new PhysicalUnit("yard", "yd", "imperial", 0.9144),
            new PhysicalUnit("mile", "mi", "imperial", 1609.344)
        };
        return lengthUnits;
    }

    public static List<PhysicalUnit> GetAreaUnits()
    {
        List<PhysicalUnit> areaUnits = new List<PhysicalUnit>() {
            new PhysicalUnit("square meter", "m^2", "metric", 1),
            new PhysicalUnit("square decimeter", "dm^2", "metric", 0.01),
            new PhysicalUnit("square centimeter", "cm^2", "metric", 0.0001),
            new PhysicalUnit("square milimeter", "mm^2", "metric", 0.000001),
            new PhysicalUnit("ar", "ar", "metric", 100),
            new PhysicalUnit("hectar", "ha", "metric", 10000),
            new PhysicalUnit("square kilometer", "km^2", "metric", 1000000),
            new PhysicalUnit("perch", "perch", "imperial", 25.29285264),
            new PhysicalUnit("rood", "rood", "imperial", 1011.7141056),
            new PhysicalUnit("acre", "acre", "imperial", 4046.8564224),
            new PhysicalUnit("square mile", "sq mi", "imperial", 2589988.110336)
    };
        return areaUnits;
    }

    public static List<PhysicalUnit> GetVolumeUnits()
    {
        List<PhysicalUnit> volumeUnits = new List<PhysicalUnit>() {
            new PhysicalUnit("liter", "l", "metric", 1),
            new PhysicalUnit("deciliter", "dl", "metric", 0.1),
            new PhysicalUnit("centiliter", "l", "metric", 0.01),
            new PhysicalUnit("mililiter", "ml", "metric", 0.001),
            new PhysicalUnit("hectoliter", "hl", "metric", 100),
            new PhysicalUnit("cubic meter", "m^3", "metric", 1000),
            new PhysicalUnit("cubic inch", "cu in", "imperial", 0.016387064),
            new PhysicalUnit("fluid ounce", "fl oz", "imperial", 0.0284130625),
            new PhysicalUnit("gill", "gi", "imperial", 0.1420653125),
            new PhysicalUnit("pint", "pt", "imperial", 0.56826125),
            new PhysicalUnit("quart", "qt", "imperial", 1.1365225),
            new PhysicalUnit("gallon", "gal", "imperial", 4.54609)
        };
        return volumeUnits;
    }

    public static List<PhysicalUnit> GetMassUnits()
    {
        List<PhysicalUnit> massUnits = new List<PhysicalUnit>() {
            new PhysicalUnit("kilogram", "kg", "metric", 1),
            new PhysicalUnit("decagram", "dg", "metric", 0.01),
            new PhysicalUnit("gram", "g", "metric", 0.001),
            new PhysicalUnit("miligram", "mg", "metric", 0.000001),
            new PhysicalUnit("metric ton", "t", "metric", 1000),
            new PhysicalUnit("grain", "gr", "imperial", 0.00006479891),
            new PhysicalUnit("drachm", "dr", "imperial", 0.0017718451953125),
            new PhysicalUnit("ounce", "oz", "imperial", 0.028349523125),
            new PhysicalUnit("pound", "lb", "imperial", 0.45359237),
            new PhysicalUnit("stone", "st", "imperial", 6.35029318),
            new PhysicalUnit("quarter", "qtr", "imperial", 12.70058636),
            new PhysicalUnit("hundredweight", "cwt", "imperial", 50.80234544),
            new PhysicalUnit("(imperial) ton", "t", "imperial", 1016.0469088)
        };
        return massUnits;
    }
}
