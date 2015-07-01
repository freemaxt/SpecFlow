﻿using System;
using System.Collections.Generic;

namespace TechTalk.SpecFlow.Assist.ValueRetrievers
{
    public class NullableGuidValueRetriever : IValueRetriever
    {
        private readonly Func<string, Guid> guidValueRetriever = v => new GuidValueRetriever().GetValue(v);

        public NullableGuidValueRetriever(Func<string, Guid> guidValueRetriever = null)
        {
            if (guidValueRetriever != null)
                this.guidValueRetriever = guidValueRetriever;
        }

        public Guid? GetValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return guidValueRetriever(value);
        }

        public object ExtractValueFromRow(TableRow row, Type targetType)
        {
            return GetValue(row[1]);
        }

        public bool CanRetrieve(TableRow row, Type type)
        {
            return type == typeof(Guid?);
        }
    }
}