using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BobTheBuilder.ArgumentStore
{
    internal class InMemoryArgumentStore : IArgumentStore
    {
        private readonly IDictionary<string, object> _members = new Dictionary<string, object>();

        public void SetMemberNameAndValue(string name, object value)
        {
            _members[name] = value;
        }

        public IEnumerable<MemberNameAndValue> GetAllStoredMembers()
        {
            return _members.Select(m => new MemberNameAndValue(m.Key, m.Value));
        }

        public IEnumerable<MemberNameAndValue> GetMissingArguments(ILookup<string, PropertyInfo> properties)
        {
            return GetAllStoredMembers().Where(member => !properties.Contains(member.Name));
        }
    }
}