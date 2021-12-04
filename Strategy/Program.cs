using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
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