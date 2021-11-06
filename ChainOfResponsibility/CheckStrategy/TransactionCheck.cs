using ChainOfResponsibility.CheckStrategy.Abstractions;

namespace ChainOfResponsibility.CheckStrategy
{
    public class TransactionCheck : BaseCheck
    {
        public override (bool, ICheckStrategy) Check(ICheckResponse checkResponse)
        {
            var data = checkResponse.ThrowIfIncorrectType<CsvParserResponse>();
            var (isOk, check) = CheckNext(checkResponse);
            return !isOk
                ? (false, check)
                : (data.Transactions != null, this);
            
        }
        
        public override string GetErrorMessage()
        {
            return "Отсутствует Transactions";
        }
    }
}