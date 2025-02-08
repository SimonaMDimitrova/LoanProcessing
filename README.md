# LoanProcessing
This is an ASP.NET Core Web API for retrieving loan data, including details about loans and their summaries.

## Overview
The Loan Processing API exposes two key endpoints to retrieve loan information:

**GetAllAsync**: Fetches a list of all loans.
**GetPaidAndAwaitingLoansSummary**: Fetches a summary of loans with the statuses Paid and AwaitingPayment, including each loan's percentage of the total amount.

These endpoints are defined in the LoanController and interact with the service layer to gather the necessary data.
