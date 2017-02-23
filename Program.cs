using System;
using System.Collections.Generic;
using MarkdownLog;

namespace AcademicWork
{
	class MainClass
	{
		public static CustomerSuite GetOrderCustomer()
		{
			int customerChoice;
			CustomerSuite customer = CustomerSuite.None;

			Console.WriteLine("1. Privat Person" + Environment.NewLine +
							  "2. Small Company" + Environment.NewLine +
							  "3. Big Company");
			var customerEntry = Console.ReadLine();

			if (int.TryParse(customerEntry, out customerChoice))
			{
				switch (customerChoice)
				{
					case 1: customer = CustomerSuite.PrivatPerson; break;
					case 2: customer = CustomerSuite.SmallCompany; break;
					case 3: customer = CustomerSuite.BigCompany; break;
				}
			}

				return customer;
			}

		public static ArticlePrice GetOrderArticle()
		{
			int articleChoice;
			ArticlePrice article = ArticlePrice.None;


			Console.WriteLine("1. Pencil" + Environment.NewLine +
							  "2. Block" + Environment.NewLine +
							  "3. Paper" + Environment.NewLine +
							  "4. Rubber");
			var articlerEntry = Console.ReadLine();

			if (int.TryParse(articlerEntry, out articleChoice))
			{
				switch (articleChoice)
				{
					case 1: article = ArticlePrice.Pencil; break;
					case 2: article = ArticlePrice.Block; break;
					case 3: article = ArticlePrice.Paper; break;
					case 4: article = ArticlePrice.Rubber; break;

				}
			}
			return article;
		}

		public static int GetOrderAmount()
		{
			int amount = 0;
			int amountChoice;
			Console.WriteLine("Amount:");
			var amountEntry = Console.ReadLine();

			if (int.TryParse(amountEntry, out amountChoice))
			{
				amount = amountChoice;
			}

			return amount;
		}

		public static void OrderArticles(Order order)
		{
			ArticlePrice article = GetOrderArticle();
			int amount = GetOrderAmount();

			if (article != ArticlePrice.None && amount != 0 && amount <= 100)
			{
				Article articleItem = new Article(article, amount, CalculateDiscount(order.Customer));

				order.AddArticle(articleItem);

				Console.WriteLine("Order created!");
			}
			else
			{
				Console.WriteLine("Something went wrong. Please try again!");
			}
		}

		public static double CalculateDiscount(CustomerSuite customer)
		{
			double discount = 0;
			if (customer == CustomerSuite.SmallCompany || customer == CustomerSuite.BigCompany)
			{
				discount = 0.1;
			}

			return discount;	
		}

		public static void CreateOrder(List<Order> orderList)
		{
			bool continueOrder = true;
			CustomerSuite customer = GetOrderCustomer();

			if (customer != CustomerSuite.None)
			{
				Order order = new Order(customer);
				orderList.Add(order);

				OrderArticles(order);

				while (continueOrder)
				{

					int menuChoice;

					Console.WriteLine("1. Done" + Environment.NewLine +
									  "2. Continue" + Environment.NewLine);

					var menuEntry = Console.ReadLine();

					if (int.TryParse(menuEntry, out menuChoice))
					{
						switch (menuChoice)
						{
							case 1: continueOrder = false; break;
							case 2: OrderArticles(order); break;
						}
					}
				}
			}
		}


		public static void ViewOrders(List<Order> orderList)
		{
			Console.WriteLine("Provide order number or write 'list orders'" + Environment.NewLine);
			var ans = Console.ReadLine();

			if (ans.Equals("list orders"))
			{
				PrintOrders(orderList);
			}
			else
			{
				int choice = 0;

				if (int.TryParse(ans, out choice))
				{
					var order = orderList.FindAll(x => x.OrderID == choice);
					if (order != null)
					{
						PrintOrders(order);
					}
				}
			}
		}


		public static void PrintOrders(List<Order> orders)
		{
			Console.WriteLine(orders.ToMarkdownTable());

		}

		public static void ShowMenu(List<Order> orderList)
		{
			Console.WriteLine("1. Create order" + Environment.NewLine + "2. View orders");

			int choice = 0;
			var ans = Console.ReadLine();

			if (int.TryParse(ans, out choice))
			{
				switch (choice)
				{
					case 1:
						{
							CreateOrder(orderList);
							break;
						}
					case 2:
						{
							ViewOrders(orderList);
							break;
						}
				}
			}
			else
			{
				Console.WriteLine("Please try again...");
				Console.ReadKey();
			}
		}



		public static void Main(string[] args)
		{
			var orderList = new List<Order>();

			while (true)
			{
				ShowMenu(orderList);
			}
		}
	}
}
