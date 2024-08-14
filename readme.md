# Pay.nl C# SDK

With this SDK you will be able to start transactions and retrieve transactions with their status for the Pay.nl payment service provider.

This SDK provides support for both the [PAY 2.0 (stable)](https://developer.pay.nl/v2.0/docs/introduction), and the [PAY 3.0 (beta)](https://developer.pay.nl/v3.0/docs/introduction), with each their own client class, `PayV2Client` and `PayV3Client`.

---

- [Installation](#installation)
- [Quick start and examples](#usage)
- [Supported platforms](#supported-platforms)
- [Implemented features](#implemented-features)
- [License](#license)

---
### Installation
Simply download and restore nuget packages https://www.nuget.org/packages/PayNL.Sdk or install it from package manager
```
PM> Install-Package PayNL.Sdk -Version x.x.x
```
### Usage

Creating a client, you can find your API key and tokens in the [Pay.nl Admin Panel](https://my.pay.nl/company/tokens), and the service id (SL-xxxx-xxx) secret in the [Pay.nl Services Overview](https://my.pay.nl/programs/programs#field_content) under 'Sales locations':
```c#
var client = new PayV2Client("apiSecret", "AT-xxxx-xxxx", "ST-xxxx-xxxx");
```

Getting a list of available payment methods:
```c#
var methods = await client.GetAvailablePaymentMethods();
```

Starting a transaction:
```c#
var transactionRequest = new CreateTransactionRequest()
{
    Amount = new Amount()
        {
            Value = 1000,
        },
    ReturnUrl = "https://demo.pay.nl/complete/",
    Description = "Example transaction",
    Reference = "12345XXY0123"
};

// Contains ID
var transactionResponse = await client.CreateTransaction(transactionRequest);
```

To determine if a transaction has been paid, you can use:
```c#
var trxStatus = await client.GetTransactionInfo(transactionResponse.Id);
var paid = trxStatus.AmountPaid.Value == trxStatus.Amount.Value;
```

### Supported platforms
This library is built using .NET standard 2.1. This means that the package supports the following .NET implementations:
| Framework                   | Version Support |
|-----------------------------|-----------------|
| .NET and .NET Core          | 3.0, 3.1, 5.0, 6.0, 7.0, 8.0 |
| .NET Framework 1            | N/A             |
| Mono                        | 6.4             |
| Xamarin.iOS                 | 12.16           |
| Xamarin.Mac                 | 5.16            |
| Xamarin.Android             | 10.0            |
| Universal Windows Platform  | N/A             |
| Unity                       | 2021.2          |

Source: https://docs.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-1

### Implemented features API V2

- Transactions
    - [x] Create
    - [x] View
    - [x] Cancel
    - [x] Refund
    - [x] Approve
    - [x] Decline
    - [x] Capture
    - [x] Void
    - [x] Load
    - [ ] Load UUID
- [x] Get available currencies
- [x] DirectDebits CRUD
- [x] Ip addresses
    - [x] Get all
    - [x] Verify single
- [ ] Merchants
    - [x] Create    
    - [x] Get    
    - [x] Delete    
    - [x] List    
    - [x] Update
    - [x] Request review 
    - [ ] Clearings
    - [ ] Invoices
    - [ ] Update package
    - [ ] Undelete
- [x] Packages
- [x] Get available payment methods
- [x] Get services
- [x] Pin transactions
    - [x] Get status
    - [x] Cancel
    - [x] Get terminals
- [x] Trademarks
    - [x] Get
    - [x] List
    - [x] Create
    - [x] (Un)suspend
- [x] Create vouchers
- [ ] Remainder of the documented API

### Implemented features API V3
- [x] Orders
    - [x] Create
    - [x] View
    - [x] Capture order
    - [x] Capture amount
    - [x] Capture products
    - [x] Void
    - [x] Abort
    - [x] Approve
    - [x] Decline
- [ ] Remainder of the documented API

### License

The Assembly is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).
