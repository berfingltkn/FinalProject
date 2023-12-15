using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Constants
{
    public static class Messages
    {
        //sürekli message ları new lememek için static kullandık. Static sabit demektir. 

        public static string ProductAdded = "Product Added. ";
        public static string ProductNameInvalid = "Product name is invalid.";
        public static string MaintenanceTime="System is under maintenance.";
        public static string ProductsListed="Products listed.";

        public static string ProductCountOfCategoryError = "Maximum 10 products can be entered";

        public static string ProductNameAlreadyExists = "There is a produtc name in this name";

        public static string CategoryLimitExceded ="New products cannot be added because the category limit has been exceeded.";
        public static string  AuthorizationDenied = "No Authorization";

        public static string UserRegistered = "Registered";

        public static string UserNotFound = "User not found";

        public static string PasswordError = "Password Error";

        public static string SuccessfulLogin = "Successful Login :)";

        public static string UserAlreadyExists = "User Already Exists";

        public static string AccessTokenCreated = "Access Token Created";


        //public ler büyük yazılır ProductAdded, ProductNameInvalid
        //Invalid-> geçersiz demek

    }
}
