using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCSBuilder.Examples
{
	public class BasicExamples
	{
		/// <summary>
		/// Example of a simple html using <see cref="HtmlBuilder"/>
		/// </summary>
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

		/// <summary>
		/// Example of how to add multiple attributes for an html tag
		/// </summary>
		public static void MultipleAttributes()
		{
			HtmlBuilder builder = new HtmlBuilder();

			using (builder.AddTag(HtmlTag.Html))
			{
				using (builder.AddTag(HtmlTag.Body, (HtmlAttribute.Class, "main_body")))
				{
					using (builder.AddTag(HtmlTag.H2))
					{
						builder.WriteLine("Span with multiple attributes");
					}

					using (builder.AddTag(HtmlTag.P))
					{
						builder.WriteLine("Define a span with source, width and height");
					}

					using (builder.AddTag(HtmlTag.Span, (HtmlAttribute.Src, "my_icon.jpg"), (HtmlAttribute.Width, "100"), (HtmlAttribute.Height, "150")))
					{
					}
				}
			}

			Console.Write(builder.ToString());
		}

		/// <summary>
		/// Example of how to add inline tags like images or hr
		/// </summary>
		public static void InlineTag()
		{
			HtmlBuilder builder = new HtmlBuilder();

			using (builder.AddTag(HtmlTag.Html))
			{
				using (builder.AddTag(HtmlTag.Body, (HtmlAttribute.Class, "main_body")))
				{
					using (builder.AddTag(HtmlTag.P))
					{
						builder.WriteLine("Inline hr tag");
					}

					builder.AddInlineTag(HtmlTag.Hr);

					using (builder.AddTag(HtmlTag.P))
					{
						builder.WriteLine("Inline image tag");
					}

					builder.AddInlineTag(HtmlTag.Img, (HtmlAttribute.Src, "my_image.jpg"), (HtmlAttribute.Width, "400"), (HtmlAttribute.Height, "500"));
				}
			}

			Console.Write(builder.ToString());
		}
	}
}
