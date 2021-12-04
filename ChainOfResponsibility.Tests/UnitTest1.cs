using ChainOfResponsibility.CheckStrategy;
using Xunit;

namespace ChainOfResponsibility.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var fullCheckChain = new CustomerCheck();
            fullCheckChain
                .SetNext(new TransactionCheck())
                .SetNext(new TypeCheck())
                .SetNext(new MccCodeCheck()); //Все проверки
            
            var data = new CsvParserResponse
            {
                Customers = new(),
                Types = new(),
                MccCodes = new()
            }; //Создаем объект без транзакций 

            var (result1, check1) = fullCheckChain.Check(data);
            
            Assert.False(result1);
        }
        
        [Fact]
        public void Test2()
        {
            var fullCheckChain = new CustomerCheck();
            fullCheckChain
                .SetNext(new TransactionCheck())
                .SetNext(new TypeCheck())
                .SetNext(new MccCodeCheck()); //Все проверки
            
            var data = new CsvParserResponse
            {
                Customers = new(),
                Types = new(),
                MccCodes = new()
            }; //Создаем объект без транзакций 

            var (result1, check1) = fullCheckChain.Check(data);
            
            Assert.Contains("Отсутствует Transactions", check1.GetErrorMessage());
        }

        [Fact]
        public void Test3()
        {
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
            
            var (result2, check2) = shortCheckChain.Check(data);
            
            Assert.True(result2);
        }
    }
}