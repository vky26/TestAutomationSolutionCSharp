# TestAutomationSolutionCSharp
CSharp Test Automation Solution

**Execute from IDE: (Visual Studio)**
1. Load the project
2. Build the project, you can see Tests inside Test Explorer
3. Pick the test and Run

**Execute from Command line:** 
1. dotnet test

**Stack:** 
Framework is built on CSharp, SpecFlow BDD with Extend Reporting. Allure Reporting can be easily integrated 

**Sample Extend Reporting:** 
![Extend Report ](https://user-images.githubusercontent.com/30401839/201915336-8d9b15d0-1766-4500-8b37-15efc282d0c1.jpg)

**Allure Reporting Integration:**
Pre-requisite:
1. Install scoop 
2. Install Allure via scoop: scoop install allure
3. Create Allure/TRXFiles and Allure/Reports folders inside the Test Automation Solution
    
    ![image](https://user-images.githubusercontent.com/30401839/201916869-bafd22ba-47d3-4ece-917e-bda1298ce6e7.png)

    Project Folder: C:\Users*\source\repos\SpecFlowProjectAllure\SpecFlowProjectAllure
    Allure Installation Path: C:\Users*\scoop\apps\allure\2.14.0\bin 
    Create Folders for TRX: C:\Users*\source\repos\SpecFlowProjectAllure\SpecFlowProjectAllure\Allure\TRXFiles
    Create Folder for Reports: C:\Users*\source\repos\SpecFlowProjectAllure\SpecFlowProjectAllure\Allure\Reports
    
 **Allure Report Execution via command line:** 
 1. dotnet test "TestAutomationSolutionCSharp.csproj" --logger trx --results-directory "C:\Users\***\TestAutomationSolutionCSharp-main\TestAutomationSolutionCSharp-main\Allure\TRXFiles"
2. allure generate "C:\Users\***\TestAutomationSolutionCSharp-main\TestAutomationSolutionCSharp-main\Allure\TRXFiles" -o "C:\Users\***\TestAutomationSolutionCSharp-main\TestAutomationSolutionCSharp-main\Allure\Reports" --clean
3. allure open C:\Users\\***\\TestAutomationSolutionCSharp-main\TestAutomationSolutionCSharp-main\Allure\Reports

**Sample Allure Report:** 
![image](https://user-images.githubusercontent.com/30401839/201916247-a5fd1a57-f35a-4f2c-bc84-860d808a25fc.png)
