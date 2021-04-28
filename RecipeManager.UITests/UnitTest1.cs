using System;
using Xunit;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace RecipeManager.UITests
{
    public class UnitTest1
    {
        // Example test from video: https://www.youtube.com/watch?v=V4CE_mNpmXU
        // TODO: Finish that video and get a test up and running for this project.
        [Fact]
        public async Task FirstTest()
        {
            await Playwright.InstallAsync();
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless: false);
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://localhost:5001/library");
            
        }
    }
}
