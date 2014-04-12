﻿using System.Collections.Generic;

namespace BobTheBuilder
{
    internal interface IArgumentStore
    {
        void SetMemberNameAndValue(string name, object value);

        IEnumerable<MemberNameAndValue> GetAllStoredMembers();
    }
}