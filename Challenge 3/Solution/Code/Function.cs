//**Solution in C# Language**//


using System;
					
public class Program
{
	public static void Main()
	{
		var p = new Person {
			Name = "Rishabh",
			AddressDetail = new Address {
				Street = "Colwick Road",
				CountryDetail = new Country {
					CountryName = "UK"
				}
			}
		};
		var nested1 = GetPropertyValue(p, "Name");
		var nested2 = GetPropertyValue(p, "AddressDetail.Street");
		var nested3 = GetPropertyValue(p, "AddressDetail.CountryDetail.CountryName");
		Console.WriteLine(nested1);
		Console.WriteLine(nested2);
		Console.WriteLine(nested3);
	}
	
	
	
	public static object GetPropertyValue(object src, string propName)
	{
		if (src == null) throw new ArgumentException("Value cannot be null.", "src");
		if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");
		
		if(propName.Contains("."))//complex type nested
		{
			var temp = propName.Split(new char[] { '.' }, 2);
			return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
		}
		else
		{
			var prop = src.GetType().GetProperty(propName);
			return prop != null ? prop.GetValue(src, null) : null;
		}
	}
}



public class Person{
	public string Name { get; set;}
	public Address AddressDetail { get; set;}
}

public class Address{
	public string Street { get; set;}
	public Country CountryDetail { get; set;}
}

public class Country{
	public string CountryName { get; set;}
}
