using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			var orderby = GetCourseList().OrderBy(p => p.price);
            Console.WriteLine ("&&&&&&&&&&&&&&*&***********");
			foreach (var J in orderby)
			{
                Console.WriteLine($"Name={J.Name} price={J.price}");
            }
			var Desc = GetCourseList().OrderByDescending(p => p.price);
			Console.WriteLine("&&&&&&&&&&&&&&*&***********");
			foreach (var p in Desc)
			{
				Console.WriteLine($"Name={p.Name} price={p.price}");
			}
			var Then = GetCourseList().OrderByDescending(p => p.price).ThenByDescending(p => p.Id);
			Console.WriteLine("&&&&&&&&&&&&&&*&***********");
			foreach (var p in Then)
			{
				Console.WriteLine($"Name={p.Name} price={p.price}");
			}
            Console.WriteLine("****************");
            foreach (var p in Then.Reverse())
			{
				Console.WriteLine($"Name={p.Name} price={p.price}");
			}

			List<Team> teams = new List<Team>
			{
				new Team {Name="Steghlal", Country="Iran" },
				new Team {Name= "Perspolis", Country="Iran"},
				new Team {Name="Sjg" , Country ="Germany" }
			};

			var Group = teams.GroupBy(p => p.Country).ToList();
			foreach (var t in Group)
			{
				// Console.WriteLine("Name:{0}", t.Key );
				foreach  (var J in t)
				{
                    Console.WriteLine($"Name={J.Name} country={J.Country}");
                }
			}

			List<Category> categories = new List<Category>
			{
				new Category {Id =1 , Name ="Mobile" , products = new List<Product>()
				{
					new Product { Id=1, Name="Samsung" , CategoryId = 1},
					new Product { Id=2, Name="Iphone" , CategoryId = 1},
				}
				},
				new	Category {Id = 2 , Name= "Desktop"}
			};
			List<Product> products = new List<Product>
			{
				new Product { Id=1, Name="Samsung" , CategoryId = 1},
				new Product { Id=2, Name="Iphone" , CategoryId = 1},
				new Product { Id=3, Name="Lenovo" , CategoryId = 2},
				new Product { Id=4, Name="Ipod" , CategoryId = 2},
			};

			var Joins = products.Join(categories, p => p.CategoryId, c => c.Id, (Product, Category) => new
			{
				productId = Product.Id,
				ProductName = Product.Name,
				ProductCategoryId = Category.Name
			}) ;  
			foreach (var j in Joins)
			{
				Console.WriteLine($"Name={j.ProductName} category {j.ProductCategoryId}");
			}
            Console.WriteLine("***********************");
			var groupjoin = products.GroupJoin(products, p => p.Id, c => c.CategoryId, (Category, Product) => new
			{
				prod= Product ,
				cat= Category ,

			});
			foreach (var j in groupjoin )
			{
                Console.WriteLine($"{j.cat.Name}  ");
            }
			var Select = products.Join(categories, p => p.CategoryId, c => c.Id, (Product, Category) =>
			new newlistDTO
			{
				Id = Product.Id,
				Name = Product.Name,
				Category = Category.Name
			}) ;
			foreach (var j in Select)
			{
				Console.WriteLine($"{j.Name} {j.Category} "); 
			}
            Console.WriteLine("***********$$$$$$$$$$$$$$$$");
            IEnumerable<string> Names= from CategoryName in categories where CategoryName.Name == "Mobile" select CategoryName.Name;
			foreach (var j in Names)
			{
				Console.WriteLine(j);
			}

			IEnumerable<int> ints= from CategoryId in categories where CategoryId .	Id >= 1 select CategoryId.Id;
			foreach (var j in ints)
			{
				Console.WriteLine(j);
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
	public class newlistDTO
	{
		public int Id { get; set; }	
		public string Name { get; set; }	
		public string Category { get; set; }	
		public DateTime InsertDate { get; set; }
	}



}
