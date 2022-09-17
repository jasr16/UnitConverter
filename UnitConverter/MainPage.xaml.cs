// using Android.App.AppSearch;

using System.Collections.Generic;
using System.Linq;

namespace UnitConverter;

public partial class MainPage : ContentPage
{
	// int count = 0;

	public MainPage()
	{
        InitializeComponent();
		List<PhysicalUnit> lengthUnits = PhysicalUnit.GetLengthUnits();
		upperPicker.ItemsSource = lengthUnits;
        upperPicker.ItemDisplayBinding = new Binding("Abbreviation");
        upperPicker.SelectedItem = (PhysicalUnit)lengthUnits.Where(x => x.Name == "meter").First();
        lowerPicker.ItemsSource = lengthUnits;
        lowerPicker.ItemDisplayBinding = new Binding("Abbreviation");
        lowerPicker.SelectedItem = (PhysicalUnit)lengthUnits.Where(x => x.Name == "inch").First();

    }

    private void upperEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ConvertUnits();  
    }

    public void ConvertUnits()
    {
        bool success = double.TryParse(upperEntry.Text, out double enteredValue);
        if (!success)
        {
            lowerLabel.Text = " ";
            return;
        }   
        PhysicalUnit upperUnit = (PhysicalUnit)upperPicker.SelectedItem;
        PhysicalUnit lowerUnit = (PhysicalUnit)lowerPicker.SelectedItem;
        if (upperUnit == null || lowerUnit == null)
        {
            lowerLabel.Text = "Incorrect unit selected";
            return;
        }     
        lowerLabel.Text = (enteredValue * upperUnit.RelationToMeter / lowerUnit.RelationToMeter).ToString();
    }

    private void upperPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConvertUnits();
    }



    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}

public class PhysicalUnit
{
    public string Name { get; set; }
	public string Abbreviation { get; set; }
    public string UnitSystem { get; set; }
    public double RelationToMeter { get; set; }

	public PhysicalUnit(string name, string abbreviation, string unitSystem, double relationToMeter)
	{
		Name = name;
		Abbreviation = abbreviation;
		UnitSystem = unitSystem;
		RelationToMeter = relationToMeter;
	}

	public static List<PhysicalUnit> GetMetricUnits()
	{
		List<PhysicalUnit> metricUnits = new List<PhysicalUnit>();
		PhysicalUnit meter = new PhysicalUnit("meter", "m", "metric", 1);
		metricUnits.Add(meter);
        PhysicalUnit decimeter = new PhysicalUnit("decimeter", "dm", "metric", 0.1);
        metricUnits.Add(decimeter);
        PhysicalUnit centimeter = new PhysicalUnit("centimeter", "cm", "metric", 0.01);
        metricUnits.Add(centimeter);
        PhysicalUnit milimeter = new PhysicalUnit("milimeter", "mm", "metric", 0.001);
        metricUnits.Add(milimeter);
        PhysicalUnit kilometer = new PhysicalUnit("kilometer", "m", "metric", 1000);
        metricUnits.Add(kilometer);
        return metricUnits;
	}

    public static List<PhysicalUnit> GetImperialUnits()
    {
        List<PhysicalUnit> imperialUnits = new List<PhysicalUnit>();
        PhysicalUnit inch = new PhysicalUnit("inch", "in", "imperial", 0.0254);
        imperialUnits.Add(inch);
        PhysicalUnit foot = new PhysicalUnit("foot", "ft", "imperial", 0.3048);
        imperialUnits.Add(foot);
        PhysicalUnit yard = new PhysicalUnit("yard", "yd", "imperial", 0.9144);
        imperialUnits.Add(yard);
        PhysicalUnit mile = new PhysicalUnit("mile", "mi", "imperial", 1609.344);
        imperialUnits.Add(mile);
        return imperialUnits;
    }

    public static List<PhysicalUnit> GetLengthUnits()
    {
        List<PhysicalUnit> metricUnits = PhysicalUnit.GetMetricUnits();
        List<PhysicalUnit> imperialUnits = PhysicalUnit.GetImperialUnits();
        return metricUnits.Concat(imperialUnits).ToList();
    }

}
