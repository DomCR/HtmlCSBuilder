using System.IO;

namespace HtmlCSBuilder.Examples
{
	public class SaveDocument
	{
		/// <summary>
		/// Example of how to save the document
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="path"></param>
		public void Save(HtmlBuilder builder, string path)
		{
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.Write(builder.ToString());
			}
		}
	}
}
