using System;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Playwright;

class Program
{
    public static async Task Main()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = false});
        var page = await browser.NewPageAsync();

        // Navigate to the homepage
        await page.GotoAsync("https://miacademy.co/#/");

        // Navigate to MiaPrep Online High School through the link on banner
        await page.WaitForSelectorAsync("text=Online High School");
        await page.ClickAsync("text=Online High School");
        Console.WriteLine("Navigated to MiaPrep Online High School link");

        // Apply to MOHS
        await page.WaitForSelectorAsync("text=Apply Now");
        await page.ClickAsync("text=Apply Now");
        Console.WriteLine("Clicked on 'Apply Now' link");

        // Navigate to the Parent Information page
        await page.WaitForSelectorAsync("div.alignNext button");
        await page.ClickAsync("div.alignNext button");
        Console.WriteLine("Moved to the Parent Information page");

        // Fill in the Parent Information
        await page.FillAsync("input[aria-labelledby='Name-arialabel aria-showelemslabel-Name0 ariarequired-Name0']", "Test");
        Console.WriteLine("Filled first name");
        await page.FillAsync("input[aria-labelledby='Name-arialabel aria-showelemslabel-Name1 ariarequired-Name1']", "Name");
        Console.WriteLine("Filled last name");
        await page.FillAsync("input[id='Email-arialabel']", "test.name@testing.com");
        Console.WriteLine("Filled email");
        await page.FillAsync("input[name='PhoneNumber']", "234567890");
        Console.WriteLine("Filled phone number");

        // Select "No" for the second parent/guardian information
        await page.SelectOptionAsync("select[name='Dropdown']", "No");
        Console.WriteLine("Selected 'No' for second parent");

        // Select tomorrow's date
        await page.ClickAsync("input[name='Date']");
        var tomorrow = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
        await page.FillAsync("input[name='Date']", tomorrow);
        await page.Keyboard.PressAsync("Enter");
        Console.WriteLine("Selected calendar date for tomorrow: " + tomorrow);

        // Proceed to the Student Information page
        await page.Keyboard.PressAsync("Enter");
        Console.WriteLine("Moved to the Student Information page");

        // Adding the 3 seconds wait intentionally and stopping the test here
        await page.WaitForTimeoutAsync(3000);
        Console.WriteLine("Test stopped here as requested.");

        // Close the browser
        await browser.CloseAsync();
    }
}