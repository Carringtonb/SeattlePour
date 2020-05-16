using System;
using EcomProject.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using AuthorizeNet.Api.Controllers.Bases;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using Microsoft.AspNetCore.Identity;

namespace EcomProject.Models.Services
{
    public class PaymentService : IPayment
    {
        //private IConfiguration _config;

        //private readonly UserManager<ApplicationUser> _userManager;


        //public PaymentService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        //{
        //    _config = configuration;
        //    _userManager = userManager;
        //}

        //public string Run()
        //{
        //    ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

        //    ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
        //    {
        //        name = _config["ApiLoginID"],
        //        ItemElementName = ItemChoiceType.transactionKey,
        //        Item = _config["TransactionKey"]
        //    };

        //    //var creditCard = new creditCardType
        //    //{
        //    //    cardNumber = "4111111111111111",
        //    //    expirationDate = "1022",
        //    //    cardCode = "777"
        //    //};

        //    //customerAddressType billingAddress = GetAddress("userID");

        //   // var paymentType = new paymentType { Item = creditCard };

        //    //var transaction = new transactionRequestType
        //    //{
        //    //    transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
        //    //    amount = 400m,
        //    //    payment = paymentType,
        //    //    billTo = billingAddress
        //    //};

        //    var request = new createTransactionRequest { transactionRequest = transaction };

        //    var controller = new createTransactionController(request);

        //    controller.Execute();

        //    var response = controller.GetApiResponse();

        //    if(response != null)
        //    {
        //        if(response.messages.resultCode == messageTypeEnum.Ok)
        //        {
        //            return "success!";
        //        }
        //    }

        //    return "payment failure!";
        //}

        ////public customerAddressType GetAddress(string userName)
        ////{


        ////    customerAddressType address = new customerAddressType
        ////    {
        ////        firstName = "Test",
        ////        lastName = "Tester",
        ////        address = "420 69th Ave",
        ////        city = "Seattle",
        ////        zip = "98111"
        ////    };

        ////    return address;
        ////}
        public string Run()
        {
            throw new NotImplementedException();
        }
    }
}
