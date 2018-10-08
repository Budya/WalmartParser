using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using WalmartParser.Models;

namespace WalmartParser.Parser
{
    public class ParserProcess
    {
        public static List<Shoes> Parse()
        {
            
            var service = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
            var options = new ChromeOptions();
            options.AddArguments("--headless");


            List<string> sourceUrls = new List<string>();
            List<Shoes> resultListShoes = new List<Shoes>();
            bool comPrmt = false;

            IWebDriver driver = new ChromeDriver(service, options);
            driver.Url = @"https://www.walmart.com/browse/clothing/mens-shoes/5438_1045804_1045807?page=1&ps=48#searchProductResult";

            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.ClassName("GlobalFooterCopyright")));

            IWebElement elem = driver.FindElement(By.ClassName("GlobalFooterCopyright"));

            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem);

            // get count of pages for parsing
            var pagesWebElements = driver.FindElement(By.ClassName("paginator-list")).FindElements(By.TagName("li"));
            var lastPage = pagesWebElements[pagesWebElements.Count - 1].FindElement(By.TagName("a")).Text;


            // !!!!!!! ONLY FOR TEST
            //int lastPageNum = Int32.Parse(lastPage);
            int lastPageNum = 1;
            int currentPage = 0;



            // creating a list of urls
            string urlFirstPart = @"https://www.walmart.com/browse/clothing/mens-shoes/5438_1045804_1045807?page=";
            string urlEndPart = @"&ps=48#searchProductResult";
            for (int pageIterator = 1; pageIterator <= lastPageNum; pageIterator++)
            {
                string walmartUrl = urlFirstPart + pageIterator + urlEndPart;
                sourceUrls.Add(walmartUrl);
            }

            foreach (var sourceUrl in sourceUrls)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                currentPage = currentPage + 1;
                driver.Url = sourceUrl;

                WebDriverWait waitForElement1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                waitForElement1.Until(ExpectedConditions.ElementIsVisible(By.ClassName("GlobalFooterCopyright")));
                IWebElement elem1 = driver.FindElement(By.ClassName("GlobalFooterCopyright"));

                driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem1);

                var elements = driver.FindElement(By.ClassName("search-result-gridview-items"))
                    .FindElements(By.ClassName("Grid-col"));



                foreach (var webElement in elements)
                {
                    Shoes shoes = new Shoes();
                    if (comPrmt)
                    {
                        Console.WriteLine(webElement.FindElement(By.TagName("img"))
                            .GetAttribute("data-image-src"));
                    }

                    // img link
                    shoes.ShoesImageUrl = webElement.FindElement(By.TagName("img"))
                        .GetAttribute("data-image-src");
                    try
                    {
                        if (comPrmt)
                        {
                            Console.WriteLine(webElement.FindElement(By.ClassName("product-brand"))
                                .FindElement(By.TagName("strong")).Text);
                        }
                        // Brand name
                        shoes.ShoesBrand = webElement.FindElement(By.ClassName("product-brand"))
                            .FindElement(By.TagName("strong")).Text;
                    }
                    catch (Exception e)
                    {
                        if (comPrmt)
                        {
                            Console.WriteLine("No Brand Name");
                        }

                        shoes.ShoesBrand = "No Brand Name";

                    }

                    if (comPrmt)
                    {
                        Console.WriteLine(webElement.FindElement(By.TagName("img"))
                            .GetAttribute("alt"));
                    }

                    // Shoes title
                    shoes.ShoesTitle = webElement.FindElement(By.TagName("img"))
                        .GetAttribute("alt");

                    try
                    {
                        var selectors = webElement.FindElement(By.ClassName("swatch-selector")).FindElements(By.TagName("button"));
                        foreach (var selector in selectors)
                        {
                            if (comPrmt)
                            {
                                Console.WriteLine(selector.FindElement(By.TagName("img")).GetAttribute("alt"));
                            }
                            // shoes variants
                            string str = selector.FindElement(By.TagName("img")).GetAttribute("alt");
                            shoes.ShoesVariants.Add(str);
                        }
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message);

                        shoes.ShoesVariants.Add("No Variants");
                    }

                    try
                    {
                        if (comPrmt)
                        {
                            Console.WriteLine(webElement.FindElement(By.ClassName("price-group"))
                                .GetAttribute("aria-label"));
                        }

                        shoes.ShoesPrice = webElement.FindElement(By.ClassName("price-group"))
                            .GetAttribute("aria-label");
                    }
                    catch (Exception e)
                    {
                        if (comPrmt)
                        {
                            Console.WriteLine("Out of Stock");
                        }

                        shoes.ShoesPrice = "Out of Stock";
                        //throw;
                    }

                    resultListShoes.Add(shoes);

                }
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine("Page {0} from {1} is parsed in {2:hh\\:mm\\:ss}", currentPage, lastPageNum, stopwatch.Elapsed);
                Console.ResetColor();


            }

            return resultListShoes;
        }
    }
}
