Money Transfer System

Project Overview

This is a money transfer system built with ASP.NET Core, implementing key functionalities such as user authentication (via ASP.NET Identity), exchange rate management, and the ability to transfer money from Malaysia (MYR) to Nepal (NPR). The system allows users to send money to receivers in Nepal, providing live exchange rate calculations and a summary of transactions.

Features

User Authentication: Users (senders) can sign up and log in using ASP.NET Identity. Authentication is required for all transactions except for viewing the exchange rate.

Money Transfer: Authenticated users can transfer money from Malaysia (MYR) to Nepal (NPR).

Exchange Rate Management: Exchange rate is dynamically fetched and displayed during the money transfer process.

Transaction History: Users can view their past transactions with detailed information.

Date Range Filter: Users can filter transactions based on a specified date range.


Technologies Used

Backend: ASP.NET Core MVC, ASP.NET Identity

Frontend: HTML, CSS, Bootstrap (for responsive design), JavaScript (for dynamic updates)

Database: Entity Framework Core, SQL Server (can be replaced with any EF-compatible database)

Tools: Visual Studio, Git


Project Setup

1. Clone the repository:

git clone


2. Open the project in Visual Studio.


3. Update the connection string in the appsettings.json file to match your local SQL Server instance:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MoneyTransferDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}


4. Run the migrations to set up the database:

Update-Database


5. Build and run the project



How to Use

1. Sign Up & Login

Navigate to the registration page to create a new account.

After registering, log in to access the money transfer features.


2. Transfer Money

Once logged in, navigate to the "Transfer Money" page.

Fill in the receiver's information and the transfer amount.

The system will automatically calculate the exchange rate and display the equivalent amount in NPR.

Review the transaction and submit.


3. Transaction History

You can view all previous transactions in the "Transaction History" section.

Use the date range filter to view transactions within a specific period.


Assumptions and Decisions

The system is designed to handle transfers from Malaysia (MYR) to Nepal (NPR), though it can be extended to support other countries and currencies.

The system uses a "sell" rate for converting MYR to NPR, assuming the user is converting their local currency to the target currency.

The user must be authenticated to perform any transactions, but exchange rate information can be accessed without logging in.


Known Issues or Future Improvements

UI Enhancements: The current UI uses basic Bootstrap elements and can be improved for a better user experience.

Error Handling: Currently, the system handles null values and other edge cases with basic validation. More comprehensive error handling could be implemented.

