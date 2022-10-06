// using Android.App.AppSearch;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnitConverter.Model;

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
        InitializeTemperatureElements();
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

    public void InitializeTemperatureElements()
    {
        List<PhysicalUnit> temperatureUnits = PhysicalUnit.GetTemperatureUnits();
        upperTemperaturePicker.ItemsSource = temperatureUnits;
        upperTemperaturePicker.ItemDisplayBinding = new Binding("Name");
        upperTemperaturePicker.SelectedItem = (PhysicalUnit)temperatureUnits.Where(x => x.Name == "degree Celsius").First();
        lowerTemperaturePicker.ItemsSource = temperatureUnits;
        lowerTemperaturePicker.ItemDisplayBinding = new Binding("Name");
        lowerTemperaturePicker.SelectedItem = (PhysicalUnit)temperatureUnits.Where(x => x.Name == "degree Fahrenheit").First();
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

