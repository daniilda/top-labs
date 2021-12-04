using Xunit;

namespace Strategy.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var rules = new RuleAgent();
            rules
                .AddRule(new NotAdminRule())
                .AddRule(new SomeRule());
            var goodAssignment = new Assignment("Moderator", 39);
            Assert.True(rules.Approve(goodAssignment));
        }

        [Fact]
        public void Test2()
        {
            var rules = new RuleAgent();
            rules
                .AddRule(new NotAdminRule())
                .AddRule(new SomeRule());
            var badAssignment = new Assignment("Admin", 12);
            Assert.False(rules.Approve(badAssignment));
        }

        [Fact]
        public void Test3()
        {
            var badAssignment = new Assignment("Admin", 12);

            var newRules = new RuleAgent();
            newRules
                .AddRule(new SomeRule());
            Assert.True(newRules.Approve(badAssignment));
        }
    }
}