using System.Web;

namespace project_foodie.Modules;

public static class UrlHelper
{
    /// <summary>
    ///     Removes the query string by key.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="key">The key.</param>
    /// <returns>pagePathWithoutQueryString</returns>
    public static string RemoveQueryStringByKey(string url, string key)
    {
        var uri = new Uri(url);

        // this gets all the query string key value pairs as a collection
        var newQueryString = HttpUtility.ParseQueryString(uri.Query);

        // this removes the key if exists
        newQueryString.Remove(key);

        // this gets the page path from root without QueryString
        var pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

        return newQueryString.Count > 0
            ? string.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
            : pagePathWithoutQueryString;
    }
}