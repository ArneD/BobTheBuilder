using System.Collections.Generic;
using System.Linq;
using BobTheBuilder.Extensions;
using JetBrains.Annotations;

namespace BobTheBuilder.ArgumentStore
{
    internal class InMemoryArgumentStore : IArgumentStore
    {
        private readonly IDictionary<string, object> _members = new Dictionary<string, object>();

        public void Set([NotNull]MemberNameAndValue member)
        {
            _members[member.Name] = member.Value;
        }

        public IEnumerable<MemberNameAndValue> Remove(IEnumerable<string> names)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MemberNameAndValue> GetAllStoredMembers()
        {
            return _members.Select(m => new MemberNameAndValue(m.Key.ToPascalCase(), m.Value));
        }

        public void RemoveMemberBy(string name)
        {
            _members.Remove(name);
        }
    }
}
