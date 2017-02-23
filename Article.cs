using System;
namespace AcademicWork
{
	public class Article
	{
		public ArticlePrice ArticlePrice { get; set; }
		public int Amount { get; set; }
		public double Discount { get; set; }

		public Article(ArticlePrice articlePrice, int amount, double discount)
		{
			ArticlePrice = articlePrice;
			Amount = amount;
			Discount = discount;
		}
	}
}
