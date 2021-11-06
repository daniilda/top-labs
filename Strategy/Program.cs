using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добавляем правила");
            var rules = new RuleAgent();
            rules
                .AddRule(new NotAdminRule())
                .AddRule(new SomeRule());
            Console.WriteLine("Создаем 'назначение' которое всречает правила");
            var goodAssignment = new Assignment("Moderator", 39);
            Console.WriteLine(rules.Approve(goodAssignment));
            Console.WriteLine("Создаем 'назначение' которое не проходит по одному правилу");
            var badAssignment = new Assignment("Admin", 12);
            Console.WriteLine(rules.Approve(badAssignment));
            Console.WriteLine("Создаем новый набор правил");
            var newRules = new RuleAgent();
            newRules
                .AddRule(new SomeRule());
            Console.WriteLine(newRules.Approve(badAssignment));
        }
    }

    public interface IRule
    {
        bool IsApproved(Assignment assignment);
    }

    public class RuleAgent
    {
        private List<IRule> Rules { get; set; } = new();

        public bool Approve(Assignment assignment)
            => Rules.All(rule => rule.IsApproved(assignment));

        public RuleAgent AddRule(IRule rule)
        {
            Rules.Add(rule);
            return this;
        }
    }

    public record Assignment(string Role, int SomeValue);

    public class SomeRule : IRule
    {
        public bool IsApproved(Assignment assignment)
        {
            return assignment.SomeValue < 40;
        }
    }

    public class NotAdminRule : IRule
    {
        public bool IsApproved(Assignment assignment)
        {
            return assignment.Role != "Admin";
        }
    }
}