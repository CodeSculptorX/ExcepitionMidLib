using ExcepitionMidLib.Common;
#nullable disable
using Newtonsoft.Json;

namespace ExcepitionMidLib.Exception
{
    public class Error
    {
        /// <summary>
        /// Creates an instace of <see cref="Error"/>
        /// </summary>
        /// <param name="errorCode">Error code for the API error.</param>
        /// <param name="message">A brief message explaning API error.</param>
        /// <param name="args">Argurments to phrase message.</param>
        public Error(int errorCode, string message, params string[] args)
        {
            Code = errorCode;
            Message = (args!= null || args.Length == 0) ? message: string.Format(message, args);
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// API error id.
        /// </summary>
        [JsonProperty(Constants.JsonKey_Error_Id)]
        public string Id { get; }

        /// <summary>
        /// Internal API error Code.
        /// </summary>
        [JsonProperty(Constants.JsonKey_Error_Code)]
        public int Code { get; }

        /// <summary>
        /// A brief message explaning API error
        /// </summary>
        [JsonProperty(Constants.JsonKey_Error_Message)]
        public string Message { get; }

        /// <summary>
        /// Convers error objects to json string
        /// </summary>
        /// <returns>Return serialized json string</returns>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
