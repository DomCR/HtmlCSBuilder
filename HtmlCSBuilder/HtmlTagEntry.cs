using System;
using System.Linq;

namespace HtmlCSBuilder
{
	public class HtmlTagEntry : IDisposable
	{
		public event EventHandler<EventArgs> OnDispose;

		public string Name { get; }

		private HtmlBuilder _builder;

		internal HtmlTagEntry(HtmlBuilder builder, string name)
		{
			this.Name = name;

			this._builder = builder;

			this._builder.Write($"<{this.Name}>\n");
		}

		internal HtmlTagEntry(HtmlBuilder builder, string name, params (HtmlAttribute att, string value)[] arr)
			: this(builder, name, arr.Select(a => (a.att.ToString().ToLower(), a.value)).ToArray())
		{
		}

		internal HtmlTagEntry(HtmlBuilder builder, string name, params (string att, string value)[] arr)
		{
			this.Name = name;

			this._builder = builder;
			this._builder.Write($"<{this.Name}");

			writeAttributes(this._builder, arr);

			this._builder.Write($">\n", false);
		}

		public static void WriteInlineTag(HtmlBuilder builder, string name)
		{
			builder.Write($"<{name}/>\n");
		}

		public static void WriteInlineTag(HtmlBuilder builder, string name, params (HtmlAttribute att, string value)[] arr)
		{
			WriteInlineTag(builder, name, arr.Select(a => (a.att.ToString().ToLower(), a.value)).ToArray());
		}

		public static void WriteInlineTag(HtmlBuilder builder, string name, params (string att, string value)[] arr)
		{
			builder.Write($"<{name}");

			writeAttributes(builder, arr.Select(a => (a.att.ToString().ToLower(), a.value)).ToArray());

			builder.Write($"/>\n", false);
		}

		protected static void writeAttributes(HtmlBuilder builder, params (string att, string value)[] arr)
		{
			if (arr != null)
			{
				foreach (var item in arr)
				{
					builder.Write($" {item.att.ToString().ToLower()}=\"{item.value}\"", false);
				}
			}
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			this.OnDispose.Invoke(this, new EventArgs());
			this._builder.WriteLine($"</{this.Name}>");
		}
	}
}
