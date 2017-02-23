using System;
using System.Threading;
using System.Collections.Generic;

namespace AcademicWork
{
	public class Order
	{
		static int nextId;

		public int OrderID { get; private set; }
		public DateTime OrderCreationDate { get; private set; }
		public CustomerSuite Customer { get; set; }

		private List<Article> ArticleList{ get; set;}


		public String Articles
		{
			get
			{
				string articles = "";
				foreach (var article in ArticleList)
				{
					articles += "{" + article.ArticlePrice + ", " + (int)article.ArticlePrice + ", " + article.Amount + ", " + article.Discount + "}";
				}
				return articles;
			}
		}

		public double Total
		{
			get
			{
				double total = 0;
				foreach (var article in ArticleList)
				{
					total += (int)article.ArticlePrice * article.Amount;
					total -= total * article.Discount;
				}

				return total;
			}
		}
		public Order(CustomerSuite customer)
		{
			OrderID = Interlocked.Increment(ref nextId);
			OrderCreationDate = System.DateTime.Now;
			Customer = customer;
			ArticleList = new List<Article>();
		}

		public void AddArticle(Article article)
		{
			ArticleList.Add(article);
		}


	}

}
