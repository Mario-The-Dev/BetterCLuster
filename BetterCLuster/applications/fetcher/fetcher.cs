using System;
using ScriptEx;
using System.Net;
using HtmlAgilityPack;
using BetterCLuster.Program.use.only.global;

namespace BetterCLuster.applications.Fetcher
{
    class FetcherClass
    {
        public static void FetcherManager()
        {
            if (Global.input.Contains("fetcher"))
            {
                if (Global.input.Contains(""))
                {
                    Fetch();
                }
                else
                {
                    DRY.PrameterException();
                }
            }
            else
            {

            }
        }


        public static void Fetch()
        {
            // Create a WebClient instance to download the HTML content
            WebClient client = new WebClient();
            Console.Write("URL : https://");
            string url = "https://"+Console.ReadLine(); // URL of the website to scrape

            try
            {
                DRY.Progress("Process Starting...");
                // Download the HTML content
                string html = client.DownloadString(url);
                DRY.Progress("Loading HTML...");
                // Load the HTML document
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                DRY.Progress("Extracting <a> elements...");
                // Extract information from the HTML
                // Here's an example of scraping all the <a> tags and printing their href attribute
                var links = doc.DocumentNode.SelectNodes("//a[@href]");
                if (links != null)
                {
                    foreach (HtmlNode link in links)
                    {
                        string href = link.GetAttributeValue("href", "");
                        string text = link.InnerText;
                        Console.WriteLine(text +" : "+ href);
                    }
                }
                else
                {
                    DRY.PrintError("No links found in the HTML content.");
                }
                DRY.Progress("Process Ended");
            }
            catch (WebException ex)
            {
                DRY.PrintError("An error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                DRY.PrintError("An error occurred: " + ex.Message);
            }
        }
    }

}
