using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Company
	{
		public int Id { get; set; }	
		public string Name { get; set; }
	}
	public class Course
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public int price { get; set; }
	} 
	public class Team
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }	
	}
	public class Category
	{
		public int Id { get; set; }	
		public string Name { get; set; }	
	}
	public class Product
	{
		public int Id { get; set; }	
		public int CategoryId { get; set; }
		public string Name { get; set; }	
	}

}
