using EFCoreMastery.Services.Results.Interfaces;

namespace EFCoreMastery.Services.Results.Concretes
{
    public class TypedSuccessResult<T> : IServiceResult
    {
        public bool IsSuccess => true;
        public T Data { get; set; }

        public TypedSuccessResult(T data)
        {
            Data = data;
        }
    }
}
