# CSHtml

Library to write HTML documents using .NET

## Syntax Example

Example of basic html

```html
<html>
    <body class="main_body">
        <h1>Heading</h1>
        <p>This is a paragraph</p>
    </body>
</html>
```

CSHtml syntact to write the html sample:

```c#
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
```