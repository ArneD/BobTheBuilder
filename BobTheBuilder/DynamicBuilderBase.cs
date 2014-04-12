using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace BobTheBuilder
{
    public abstract class DynamicBuilderBase<T> : DynamicObject, IDynamicBuilder<T>, IArgumentStore where T : class
    {
        private readonly IDictionary<string, object> _members = new Dictionary<string, object>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            return InvokeBuilderMethod(binder, args, out result);
        }

        public abstract bool InvokeBuilderMethod(InvokeMemberBinder binder, object[] args, out object result);

        public abstract T Build();

        public void SetMemberNameAndValue(string name, object value)
        {
            _members[name] = value;
        }

        public IEnumerable<MemberNameAndValue> GetAllStoredMembers()
        {
            return _members.Select(m => new MemberNameAndValue(m.Key, m.Value));
        }

        public static implicit operator T(DynamicBuilderBase<T> builder)
        {
            return builder.Build();
        }
    }
}