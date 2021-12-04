using System;
using Xunit;

namespace Builder.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var baker = new Baker();
            var builder = new RyeBreadBuilder();
            builder.SetAdditives();
            var ryeBread = baker.Bake(builder);
            Assert.Contains("Ржаная мука 1 сорт",ryeBread.ToString());

        }

        [Fact]
        public void Test2()
        {
            var baker = new Baker();
            var builder = new WheatBreadBuilder();
            var wheatBread = baker.Bake(builder);
            Assert.Contains("Добавки: улучшитель хлебопекарный ",wheatBread.ToString());
        }
    }
}