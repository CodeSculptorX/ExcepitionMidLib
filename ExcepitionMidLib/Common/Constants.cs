using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepitionMidLib.Common
{
    public class Constants
    {
        #region Jsonkeys

        #region API Error

        /// <summary>
        /// Json key for API Error Message
        /// </summary>
        public const string JsonKey_Error_Message = "message";

        /// <summary>
        /// Json key for API Error Reason
        /// </summary>
        public const string JsonKey_Error_Reason = "reason";

        /// <summary>
        /// Json key for API Error ErrorCode
        /// </summary>
        public const string JsonKey_Error_Code = "errorcode";

        /// <summary>
        /// Json key for API Error ErrorId
        /// </summary>
        public const string JsonKey_Error_Id = "errorId";

        #endregion

        #region API Responce
        public const string JsonKey_Responce_TrackingId = "trackingid";
        public const string JsonKey_Responce_UserMessage = "usermessage";
        public const string JsonKey_Responce_DeveloperMessage = "developerMessage";
        public const string JsonKey_Responce_Data = "data";
        public const string JsonKey_Responce_StatusCode = "statuscode";
        public const string JsonKey_Global_ErrorMessage = "Internal server error.";
        #endregion

        #endregion
    }
}
