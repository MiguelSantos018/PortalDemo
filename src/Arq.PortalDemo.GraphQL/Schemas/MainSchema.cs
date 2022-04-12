using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Arq.PortalDemo.Queries.Container;
using System;

namespace Arq.PortalDemo.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}