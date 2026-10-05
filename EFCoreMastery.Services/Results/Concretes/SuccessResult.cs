using EFCoreMastery.Services.Results.Interfaces;


namespace EFCoreMastery.Services.Results.Concretes
{
    public class SuccessResult : IServiceResult
    {
        public bool IsSuccess => true;
        public object Data { get; set; }

        public SuccessResult(object data)
        {
            Data = data;
        }
    }
}
