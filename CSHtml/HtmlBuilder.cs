using System;
using System.IO;

namespace CSHtml
{
	public class HtmlBuilder
	{
		private int _indentLevel = 0;

		private string _tabString = "\t";

		private TextWriter _writer;

		public HtmlBuilder() : this(new StringWriter())
		{
		}

		public HtmlBuilder(TextWriter writer)
		{
			this._writer = writer;
		}

		public HtmlTagEntry AddTag(HtmlTag tag)
		{
			var htag = new HtmlTagEntry(this, tag.ToString());

			this._indentLevel++;
			htag.OnDispose += this.onTagDisposed;

			return htag;
		}

		public HtmlTagEntry AddTag(HtmlTag tag, params (HtmlAttribute att, string value)[] arr)
		{
			var htag = new HtmlTagEntry(this, tag.ToString(), arr);

			this._indentLevel++;
			htag.OnDispose += this.onTagDisposed;

			return htag;
		}

		public void Write(string line, bool tabs = true)
		{
			if (tabs)
				this.outputTabs();

			this._writer.Write(line);
		}

		public void WriteLine(string line)
		{
			this.outputTabs();
			this._writer.WriteLine(line);
		}

		public override string ToString()
		{
			return this._writer.ToString();
		}

		protected virtual void outputTabs()
		{
			for (int i = 0; i < this._indentLevel; i++)
			{
				this._writer.Write(this._tabString);
			}
		}

		private void onTagDisposed(object sender, EventArgs e)
		{
			this._indentLevel--;
		}
	}
}
