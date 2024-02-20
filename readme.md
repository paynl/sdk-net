# Pay.nl C# SDK

With this SDK you will be able to start transactions and retrieve transactions with their status for the Pay.nl payment service provider.

---

- [Installation](#installation)
- [Quick start and examples](#usage)
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
var client = new PayClient("apiSecret", "AT-xxxx-xxxx", "ST-xxxx-xxxx");
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
    Description = "Example transaction"
};

// Contains ID
var transactionResponse = await client.CreateTransaction(transactionRequest);
```

To determine if a transaction has been paid, you can use:
```c#
var trxStatus = await client.GetTransactionInfo(transactionResponse.Id);
var paid = trxStatus.AmountPaid.Value == trxStatus.Amount.Value;
```
### Implemented features

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

### License

The Assembly is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).
