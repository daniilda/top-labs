using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    
    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }
 
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }
 
    class Product
    {
        List<object> parts = new List<object>();
        public void Add(string part)
        {
            parts.Add(part);
        }
    }
 
    class ConcreteBuilder : Builder
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("Part A");
        }
        public override void BuildPartB()
        {
            product.Add("Part B");
        }
        public override void BuildPartC()
        {
            product.Add("Part C");
        }
        public override Product GetResult()
        {
            return product;
        }
    }
}