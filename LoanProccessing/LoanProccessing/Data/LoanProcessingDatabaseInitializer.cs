namespace LoanProccessing.Data;

using Dapper;
using System.Data;

public class LoanProcessingDatabaseInitializer
{
    private IDbConnection connection;

    public LoanProcessingDatabaseInitializer(IDbConnection connection)
    {
        this.connection = connection;
    }

    public async Task CreateDatabaseAsync()
    {
        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS 
                    Client (
                        Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        FirstName   TEXT NOT NULL,
                        SecondName  TEXT NOT NULL,
                        LastName    TEXT NOT NULL
                    )"
        );

        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS 
                    Loan
                    (
                        Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        LoanNumber  TEXT NOT NULL,
                        Status      TEXT NOT NULL,
                        Amount      NUMERIC(10,2) NOT NULL,
                        RequestedOn TEXT NOT NULL,
                        ClientId    INTEGER NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Client(Id) ON DELETE RESTRICT
                    )");

        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS
                    Invoice
                    (
                        Id              INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        InvoiceNumber   TEXT NOT NULL,
                        Amount          NUMERIC(10,2) NOT NULL,
                        LoanId          INTEGER NOT NULL,
                        FOREIGN KEY (LoanId) REFERENCES Loan(Id) ON DELETE RESTRICT
                    )");
    }
}
