using System;

namespace CSHtml
{
	public class HtmlTagEntry : IDisposable
	{
		public event EventHandler<EventArgs> OnDispose;

		public string Name { get; }

		private HtmlBuilder _builder;

		internal HtmlTagEntry(HtmlBuilder builder, string name)
		{
			this.Name = name.ToLower();

			this._builder = builder;
			this._builder.Write($"<{this.Name}>\n");
		}

		internal HtmlTagEntry(HtmlBuilder builder, string name, params (HtmlAttribute att, string value)[] arr)
		{
			this.Name = name.ToLower();

			this._builder = builder;
			this._builder.Write($"<{this.Name}");

			if (arr != null)
			{
				foreach ((HtmlAttribute att, string value) in arr)
				{
					this._builder.Write($" {att.ToString().ToLower()}=\"{value}\"", false);
				}
			}

			this._builder.Write($">\n", false);
		}

		internal HtmlTagEntry(HtmlBuilder builder, string name, params (string att, string value)[] arr)
		{
			this.Name = name.ToLower();

			this._builder = builder;
			this._builder.Write($"<{this.Name}");

			if (arr != null)
			{
				foreach (var item in arr)
				{
					this._builder.Write($" {item.att.ToString().ToLower()}=\"{item.value}\"", false);
				}
			}

			this._builder.Write($">\n", false);
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			this.OnDispose.Invoke(this, new EventArgs());
			this._builder.WriteLine($"</{this.Name}>");
		}
	}
}
