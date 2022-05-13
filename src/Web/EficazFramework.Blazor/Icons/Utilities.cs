namespace EficazFramework.Icons;
public static class Utilities
{
    //converts SVG element to base64 URI:
    public static string ToUri(this string SvgIcon, string fill = "inherit", string viewbox = "0 0 24 24")
    {
        string svg = SvgIcon.Replace("<", "%3C").Replace("</", "%3C/").Replace(">", "%3E").Replace("\" %3E", "\"%3E");
        return "data:image/svg+xml," + $"%3Csvg xmlns=\"http://www.w3.org/2000/svg\" fill=\"{fill.Replace("#", "%23")}\" viewBox=\"{viewbox}\"%3E" + svg + "%3C/svg%3E";

    }
}
