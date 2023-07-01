using Audisoft.Application.Enums;

namespace Audisoft.Dtos
{
    public class Status<T> where T : class
    {
        public Status()
        {
                
        }
        public Status(string Message, TypeMessage typeMessage, T Data)
        {
            this.Message = Message;
            this.TypeMessage = typeMessage;
            this.Data = Data;
        }
        public string Message { get; set; }
        public TypeMessage TypeMessage { get; set; }
        public T Data { get; set; }
    }
}
