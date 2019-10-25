/*
 * Developer: Jacob Van Silfhout
 * Purpose: Unit tests for converter application
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobVanSilfhout
{
    public class Converter
    { 
        /*Static members*/
        /*New units for conversion along with there associated formulae can be added here*/
        /*This would potentially be pulled from a database or api*/
        public static List<List<string>> supportedUnits = new List<List<string>>
        {
            new List<string>{"f","c","(x-32)*5/9","Fahrenheit"},//fahrenheit => celcius 
            new List<string>{"f","k","(x-32)*5/9+273.15","Fahrenheit"},//fahrenheit => kelvin
            new List<string>{"c","f","(x*9/5)+32","Celcius"},//celcius => fahrenheit
            new List<string>{"c","k","x+273.15","Celcius"},//celcius => kelvin
            new List<string>{"k","c","x-273.15","Kelvin"},//Kelvin => celcius
            new List<string>{"k","f","(x-273.15)*(9/5)+32","Kelvin"},//kelvin => fahrenheit
            new List<string>{"l","ml", "x*1000", "litre"},//litre => millilitres
            new List<string>{"l","us gal", "x/3.785", "litre"},//litre => gallons
            new List<string>{"ml","l","x/1000","millilitre"},//millilitres => litres
            new List<string>{"ml","us gal","x/3785.412","millilitre"},//millilitres => gallons
            new List<string>{"us gal","l","x*3.785","U.S gallon"},//gallons => litres
            new List<string>{"us gal","ml","x*3785.412","U.S gallon"},//gallons => millilitres
            new List<string>{"ml","ml","x","millilitres"},//millilitres
            new List<string>{"l","l","x","litres"},//litres
            new List<string>{"us gal", "us gal", "x","U.S gallon"},//gallons
            new List<string>{"f","f","x","millilitres"},//fahrenheit
            new List<string>{"c","c","x","litres"},//celcius
            new List<string>{"k", "k", "x","U.S gallon"},//kelvin
        };
        /*Method to check if the conversion type is supported*/
        public static bool ValidUnit(string input)
        {
            bool check = false;
            foreach (List<string> x in supportedUnits)
            {
                if (x[0] == input)
                    check = true;
            }
            return check;
        }

        /*Public properties to hold the the user objects values*/
        public static Dictionary<string, string> supported = new Dictionary<string, string>();//Used for UI
        public double ConVal { get; set; }
        public string Units { get; set; }
        public string ConTo { get; set; }


        /*Overloaded Constructors*/
        public Converter()
        {
            foreach (List<string> x in supportedUnits)
            {
                if (!supported.ContainsKey(x[0]))
                    supported.Add(x[0], x[3]);
            }
        }
        public Converter(double conVal, string units, string conTo)
        {
            foreach (List<string> x in supportedUnits)
            {
                if (!supported.ContainsKey(x[0]))
                    supported.Add(x[0], x[3]);
            }
            ConVal = conVal;
            Units = units;
            ConTo = conTo;
        }

        /*Method to check if the conversion is valid*/
        public bool ValidConversion()
        {
            bool isValid = false;
            string current = Units.ToLower();
            string proposed = ConTo.ToLower();

            if (current == "f" || current == "c" || current == "k")
            {
                if (proposed == "f" || proposed == "c" || proposed == "k")
                    isValid = true;
            }
            else if (current == "l" || current == "ml" || current == "us gal")
            {
                if (proposed == "l" || proposed == "ml" || proposed == "us gal")
                    isValid = true;
            }
            return isValid;
        }

        /*Method to perform the conversion*/
        public double Conversion()
        {
            string equation = "";
            string current = Units.ToLower();
            string proposed = ConTo.ToLower();
            DataTable table = new DataTable();

            if (ValidConversion())
            {
                foreach (List<string> x in supportedUnits)
                {
                    if (x[0] == current && x[1] == proposed)
                    {
                        equation = x[2];
                    }
                }
                equation = equation.Replace('x'.ToString(), $"{ConVal}");
                table.Columns.Add("evaluate", string.Empty.GetType(), equation);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                return Math.Round(double.Parse((string)row["evaluate"]), 2);
            }
            else
                return -1;
        }
    }
}
