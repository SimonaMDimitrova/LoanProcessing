# LoanProcessing
This is an ASP.NET Core Web API for retrieving loan data, including details about loans and their summaries.

## Overview
The Loan Processing API exposes two key endpoints to retrieve loan information:

**GetAllAsync**: Fetches a list of all loans.

**GetPaidAndAwaitingLoansSummary**: Fetches a summary of loans with the statuses Paid and AwaitingPayment, including each loan's percentage of the total amount.

These endpoints are defined in the LoanController and interact with the service layer to gather the necessary data.

## Database relations
![image](https://github.com/user-attachments/assets/17b5fdaa-bcb2-49ae-b318-072a53adf8cc)
