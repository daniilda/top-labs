using System;
using System.Collections.Generic;
using System.Transactions;
using ChainOfResponsibility.CheckStrategy.Abstractions;

namespace ChainOfResponsibility.CheckStrategy
{
    public class CsvParserResponse : ICheckResponse
    {
        public List<string>? Customers { get; set; }
        public List<string>? MccCodes { get; set; }
        public List<string>? Transactions { get; set; }
        public List<string>? Types { get; set; }
    }
}