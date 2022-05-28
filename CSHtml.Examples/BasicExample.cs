using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHtml.Examples
{
	public class BasicExamples
	{
		public static void WriteSimpleHtml()
		{
			HtmlBuilder builder = new HtmlBuilder();

			using (builder.AddTag(HtmlTag.Html))
			{
				using (builder.AddTag(HtmlTag.Body, (HtmlAttribute.Class, "main_body")))
				{
					using (builder.AddTag(HtmlTag.H1))
					{
						builder.WriteLine("Heading");
					}

					using (builder.AddTag(HtmlTag.P))
					{
						builder.WriteLine("This is a paragraph");
					}
				}
			}

			Console.Write(builder.ToString());
		}

		public static void MultipleTags()
		{
			HtmlBuilder builder = new HtmlBuilder();

			using (builder.AddTag(HtmlTag.Html))
			{
				using (builder.AddTag(HtmlTag.Body, (HtmlAttribute.Class, "main_body")))
				{
					using (builder.AddTag(HtmlTag.H2))
					{
						builder.WriteLine("Span with multiple tags");
					}

					using (builder.AddTag(HtmlTag.P))
					{
						builder.WriteLine("Define a span with the source, width and height");
					}

					using (builder.AddTag(HtmlTag.Span, (HtmlAttribute.Src, "my_icon.jpg"), (HtmlAttribute.Width, "100"), (HtmlAttribute.Height, "150")))
					{
					}
				}
			}

			Console.Write(builder.ToString());
		}
	}
}
