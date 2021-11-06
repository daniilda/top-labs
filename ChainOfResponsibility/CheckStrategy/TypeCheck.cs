using ChainOfResponsibility.CheckStrategy.Abstractions;

namespace ChainOfResponsibility.CheckStrategy
{
    public class TypeCheck : BaseCheck
    {
        public override (bool, ICheckStrategy) Check(ICheckResponse checkResponse)
        {
            var data = checkResponse.ThrowIfIncorrectType<CsvParserResponse>();
            var (isOk, check) = CheckNext(checkResponse);
            return !isOk
                ? (false, check)
                : (data.Types != null, this);
        }
        
        public override string GetErrorMessage()
        {
            return "Отсутствует Type";
        }
    }
}