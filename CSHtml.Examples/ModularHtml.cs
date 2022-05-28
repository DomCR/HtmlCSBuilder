using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHtml.Examples
{
	public class ModularHtml
	{
		/// <summary>
		/// Example how to write a chunk of html once and use it in other pages
		/// </summary>
		public static void WritePages()
		{
			HtmlBuilder page1 = new HtmlBuilder();
			HtmlBuilder page2 = new HtmlBuilder();

			using (page1.AddTag(HtmlTag.Html))
			{
				page1.AddChunk(header());

				using (page1.AddTag(HtmlTag.Body))
				{
					page1.WriteLine("Dynamic main content in this html page 001");
				}

				page1.AddChunk(footer());
			}

			using (page2.AddTag(HtmlTag.Html))
			{
				page2.AddChunk(header());

				using (page2.AddTag(HtmlTag.Body))
				{
					page2.WriteLine("Dynamic main content in this html page 002");
				}

				page2.AddChunk(footer());
			}

			Console.WriteLine("Write the first page in the terminal");
			Console.Write(page1.ToString());

			Console.WriteLine();

			Console.WriteLine("Write the second page in the terminal");
			Console.Write(page2.ToString());
		}

		private static HtmlBuilder header()
		{
			HtmlBuilder head = new HtmlBuilder();

			using (head.AddTag(HtmlTag.Head))
			{
				using (head.AddTag(HtmlTag.Title))
				{
					head.WriteLine("This is the default title for all pages");
				}
			}

			return head;
		}

		public static HtmlBuilder footer()
		{
			HtmlBuilder foot = new HtmlBuilder();

			using (foot.AddTag(HtmlTag.Footer))
			{
				using (foot.AddTag(HtmlTag.P))
				{
					foot.WriteLine("Author: this is the author of the pages");
				}
			}

			return foot;
		}
	}
}
