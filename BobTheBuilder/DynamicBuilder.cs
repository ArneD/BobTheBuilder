using System;
using System.Dynamic;

namespace BobTheBuilder
{
    public class DynamicBuilder<T> : DynamicBuilderBase<T> where T: class
    {
        public DynamicBuilder(IArgumentStore argumentStore) : base(argumentStore) { }

        public override bool InvokeBuilderMethod(InvokeMemberBinder binder, object[] args, out object result)
        {
            ParseMembersFromMethodName(binder, args);

            result = this;
            return true;
        }

        private void ParseMembersFromMethodName(InvokeMemberBinder binder, object[] args)
        {
            var memberName = binder.Name.Replace("With", "");
            argumentStore.SetMemberNameAndValue(memberName, args[0]);
        }
    }
}