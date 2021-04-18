using GraphqlTest.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphqlTest.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member
            )
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
