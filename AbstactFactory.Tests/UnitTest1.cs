using AbstractFactory;
using Xunit;

namespace AbstactFactory.Tests
{

    public class UnitTest1
    {
        [Fact]
        public void ClassicFurnitureTest()
        {
            var a = new ClassicFactory();
            var b = new Furniture(a);
            var result = b.Use();
            Assert.True((result[0].Contains("Классик") 
                         && result[1].Contains("Классик") 
                         && result[2].Contains("Классик")));
        }

        [Fact]
        public void ModernFurnitureTest()
        {
            var c = new ModernFactory();
            var d = new Furniture(c);
            var result = d.Use();
            Assert.True((result[0].Contains("Модерн") 
                         && result[1].Contains("Модерн") 
                         && result[2].Contains("Модерн")));
        }
        
    }
}