# MOHS Registration Automation Challenge
This project automates the process to test the MiaPrep Online High School's "Apply Now" or registration functionality. The project is developed in C# Programmnig language and used Playwright test-automation framework.
In order to test the School's Regisration we need to automate the process as follows:
1. visit the Home page
2. starting from navigating through the link on banner  
3. apply to MiaPrep Online High School
4. fill-in the Parent Information
5. navigate to Student Information page
6. Stop the Test as per requirement

# Pre-requisites
To run this project you need to first download and install the `.NET SDK`. 
1. .NET SDK can be downloaded from this [link](https://dotnet.microsoft.com/en-us/download/dotnet).
2. Then we need to add the Playwright package to the project using the dotnet add package command: `dotnet add package Microsoft.Playwright`.

# Initializing Playwright framework and running the script
1. Run the script with command: `dotnet run`

# Considerations
The following consideration have been taken into account while implementing the task:
1. I have set the `Headless = false` for browser launching option for better visibility for each step being performed in the test.
2. Intentionally added the 3 seconds wait time after the last step (after proceeding to the Student Information page) and before stopping the test for a better visibility.

In case if we need to run the test headless i.e. `Headless = true`, then we don't need the added 3 sec wait just before stopping the test.

Moreover, the task was implemented on Windows OS, everything is working fine on Windows platform, but in case if you encounter any issue while running the script on any platform, please let me know. I'll be happy to fix the issue.