using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Constant
{
    public static class ErrorMessages
    {
       public const string ADD_ERROR_MESSAGE = "Some Thing Wrong Happened while Adding";
       public const string UPDATE_ERROR_MESSAGE = "Some Thing Wrong Happened while Updating";
       public const string DELETE_ERROR_MESSAGE = "Some Thing Wrong Happened while Deleteing";
       public const string DUBLICATE_NAME_ERROR_MESSAGE = "There is an Item with same name";
       public const string NotFount_ERROR_MESSAGE = "Item you Choose is Not Fount";
    }


    public static class OkMessages
    {
        public const string ADD_Ok_MESSAGE = "Adding Done Successfully";
        public const string UPDATE_Ok_MESSAGE = "Updating Done Successfully";
        public const string DELETE_Ok_MESSAGE = "Deleteing Done Successfully";
    }
}
