using System;
using Xunit;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace RecipeManager.UITests
{
    public class UnitTest1
    {
        // I could also look into using bunit to test my UI. Maybe look a video up or something.

        // Example test from video: https://www.youtube.com/watch?v=V4CE_mNpmXU
        // TODO: Finish that video and get a test up and running for this project.
        //[Fact]
        //public async Task FirstTest()
        //{
        //    await Playwright.InstallAsync();
        //    using var playwright = await Playwright.CreateAsync();
        //    await using var browser = await playwright.Chromium.LaunchAsync(headless: false);
        //    var page = await browser.NewPageAsync();
        //    await page.GoToAsync("https://localhost:5001/library");   
        //}

        public IBrowser Browser;
        public UnitTest1()
        {
            if (Browser == null)
            {
                Browser = Task.Run(() => GetBrowserAsync()).Result;
            }
        }

        private async Task<IBrowser> GetBrowserAsync()
        {
            await Playwright.InstallAsync();
            var playwright = await Playwright.CreateAsync();
            return await playwright.Chromium.LaunchAsync(headless: false);
        }

        public IPage page;
        public void Dispose()
        {
            page?.CloseAsync();
        }

        //[Fact]
        //public async Task ValidateDevelopersTitle()
        //{
        //    var context = await Browser.NewContextAsync();
        //    page = await context.NewPageAsync();
        //    await page.GoToAsync("http://www.stackoverflow.com");
        //    var developersLinkText = (await page.GetTextContentAsync("a[href=\"#for-developers\"]")).Trim();
        //    Assert.Equal("For developers", developersLinkText);
        //}

        //[Fact]
        //public async Task ValidateHomePageTitle()
        //{
        //    var context = await Browser.NewContextAsync();
        //    page = await context.NewPageAsync();
        //    await page.GoToAsync("https://localhost:5001/");
        //    await page.ClickAsync("text=Library");
        //    var x = await page.GetTextContentAsync("Cookbook Library");

        //    //var developersLinkText = (await page.GetTextContentAsync("a[href=\"#for-developers\"]")).Trim();
        //    Assert.Equal("Cookbook Library", x);
        //}

        //[Fact]
        //public async Task SearchCSharp()
        //{
        //    var context = await Browser.NewContextAsync();
        //    page = await context.NewPageAsync();
        //    await page.GoToAsync("http://www.stackoverflow.com");

        //    var searchBar = "input[name=\"q\"]";
        //    await page.TypeAsync(searchBar, "c#");
        //    await page.ClickAsync(searchBar);
        //    await page.PressAsync(searchBar, "Enter");

        //    var headLineText = (await page.GetTextContentAsync(".fs-headline1")).Trim();
        //    Assert.Equal("Questions tagged [c#]", headLineText);

        //}
    }
}
