namespace Dwolla.API
{
    internal class DwollaServiceException : DwollaAPIException
    {
        public DwollaServiceException(bool responseSuccess, string responseMessage)
        {
            this.ResponseSuccess = responseSuccess;
            this.ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; private set; }

        public bool ResponseSuccess { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format("[response status:{0}]{1}", this.ResponseSuccess, this.ResponseMessage);
            }
        }
    }
}
