using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class run
	{
		public static void First()
		{
			List<Company> companies = new List<Company>
			{
			new Company{Id=1,Name="Hybe"},
			new Company {Id=2,Name="JYP"},
			new Company {Id=3,Name="Styleto"}
			};

			List<Course> course = new List<Course>
			{
				new Course {Id =  1,Name="Sql", price=120000},
				new Course {Id = 2, Name="Asp.net", price= 150000},
				new Course {Id = 3,Name= "Dart" , price = 160000}
			};

			var T = course.Where(l => l.price < 150000);
			foreach (var t in T)
			{
				Console.WriteLine($"Name={t.Name} price={t.price}");
			}
			course.Add(new Course { Id = 4, Name = "Jquery", price = 110000 });
			Console.WriteLine("***************************");

			foreach (var t in T)
			{
				Console.WriteLine($"Name= {t.Name} Price={t.price} ");
			}
			var result = companies.Where(p => p.Name == "JYP");
			var n = companies.Where(FindCompany);
			var g = companies.Where(FindCompanies);
			var b = companies.Where(delegate (Company company)
			{
				return company.Name.StartsWith("J");
			});

			var v = companies.Where(c => c.Name == "Hybe");
			var mycondition = GetCourseList().Where(p => p.price > 110000).Where(p => p.Id >= 4).Where(p => p.Name == "Sql");
			var Jk = GetCourseList().Where((c, i) => 
		    {
				if (i % 2 == 0)
				{
					return true;	
				}
				return false;	
			});
			foreach (var J in Jk)
			{
                Console.WriteLine($"Name = {J.Name} Price={J.price} ");
            }

			Console.ReadKey();
		}
		private static bool FindCompanies(Company company)
		{
			return company.Name.Equals("Styleto");
		}

		private static bool FindCompany(Company company)
		{
			return company.Name == "Hybe";
		}
		
		private static List<Course> GetCourseList ()
		{
			List<Course> course = new List<Course>
			{
				new Course {Id =  1,Name="Sql", price=120000},
				new Course {Id = 2, Name="Asp.net", price= 150000},
				new Course {Id = 3,Name= "Dart" , price = 160000}
			};

			return course;
		}



	}
}
