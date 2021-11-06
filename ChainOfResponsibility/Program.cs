using System;
using ChainOfResponsibility.CheckStrategy;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullCheckChain = new CustomerCheck();
            fullCheckChain
                .SetNext(new TransactionCheck())
                .SetNext(new TypeCheck())
                .SetNext(new MccCodeCheck()); //Все проверки

            var shortCheckChain = new MccCodeCheck();
            shortCheckChain
                .SetNext(new CustomerCheck())
                .SetNext(new TypeCheck());

            var data = new CsvParserResponse
            {
                Customers = new(),
                Types = new(),
                MccCodes = new()
            }; //Создаем объект без транзакций 

            var (result1, check1) = fullCheckChain.Check(data);
            var (result2, check2) = shortCheckChain.Check(data);

            if (!result1)
                Console.WriteLine(check1.GetErrorMessage());
            if (!result2)
                Console.WriteLine(check2.GetErrorMessage());
        }
    }
}