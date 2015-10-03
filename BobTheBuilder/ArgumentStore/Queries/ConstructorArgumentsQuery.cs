﻿using BobTheBuilder.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace BobTheBuilder.ArgumentStore.Queries
{
    internal class ConstructorArgumentsQuery : IArgumentStoreQuery
    {
        private readonly IArgumentStore argumentStore;

        public ConstructorArgumentsQuery([NotNull]IArgumentStore argumentStore)
        {
            this.argumentStore = argumentStore;
        }

        public IEnumerable<MemberNameAndValue> Execute(Type destinationType)
        {
            var parameterNames = destinationType.GetConstructors().Single().GetParameters().Select(p => p.Name.ToPascalCase());
            return argumentStore.Remove(parameterNames);
        }
    }
}
