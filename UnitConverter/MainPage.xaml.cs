// using Android.App.AppSearch;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnitConverter.Model;
using static UnitConverter.Model.PhysicalUnit;

namespace UnitConverter;

public partial class MainPage : ContentPage
{
    public List<PhysicalUnit> units = PhysicalUnit.GetUnits();
    public MainPage()
	{
        InitializeComponent();
        InitializePickers(upperLengthPicker, lowerLengthPicker, units.Where(x => x.Type == UnitType.Length).ToList(), "meter", "inch");
        InitializePickers(upperTemperaturePicker, lowerTemperaturePicker, units.Where(x => x.Type == UnitType.Temperature).ToList(), "degree Celsius", "degree Fahrenheit");
        InitializePickers(upperVolumePicker, lowerVolumePicker, units.Where(x => x.Type == UnitType.Volume).ToList(), "liter", "pint");
        InitializePickers(upperMassPicker, lowerMassPicker, units.Where(x => x.Type == UnitType.Mass).ToList(), "kilogram", "pound");
        InitializePickers(upperAreaPicker, lowerAreaPicker, units.Where(x => x.Type == UnitType.Area).ToList(), "square meter", "acre");
    }

    public void InitializePickers(Picker upperPicker, Picker lowerPicker, List<PhysicalUnit> units, string upperSelected, string lowerSelected)
    {
        upperPicker.ItemsSource = units;
        upperPicker.ItemDisplayBinding = new Binding("Name");
        upperPicker.SelectedItem = (PhysicalUnit)units.Where(x => x.Name == upperSelected).First();
        lowerPicker.ItemsSource = units;
        lowerPicker.ItemDisplayBinding = new Binding("Name");
        lowerPicker.SelectedItem = (PhysicalUnit)units.Where(x => x.Name == lowerSelected).First();
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
        if (lowerUnit.RelationToBaseWithConstant != null || lowerUnit.RelationToBaseWithConstant != null)
        {
            lowerLabel.Text = Math.Round(
                (enteredValue * upperUnit.RelationToBaseWithConstant[0] + upperUnit.RelationToBaseWithConstant[1]) / lowerUnit.RelationToBaseWithConstant[0] -
                lowerUnit.RelationToBaseWithConstant[1] / lowerUnit.RelationToBaseWithConstant[0], 12).ToString();
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

    private void upperTemperatureEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits(upperTemperatureEntry, upperTemperaturePicker, lowerTemperaturePicker, lowerTemperatureLabel);
    }

    private void upperTemperaturePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits(upperTemperatureEntry, upperTemperaturePicker, lowerTemperaturePicker, lowerTemperatureLabel);
    }
}

