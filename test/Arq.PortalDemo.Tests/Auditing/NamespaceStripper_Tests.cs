using Arq.PortalDemo.Auditing;
using Arq.PortalDemo.Test.Base;
using Shouldly;
using Xunit;

namespace Arq.PortalDemo.Tests.Auditing
{
    // ReSharper disable once InconsistentNaming
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("Arq.PortalDemo.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("Arq.PortalDemo.Auditing.GenericEntityService`1[[Arq.PortalDemo.Storage.BinaryObject, Arq.PortalDemo.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("Arq.PortalDemo.Auditing.XEntityService`1[Arq.PortalDemo.Auditing.AService`5[[Arq.PortalDemo.Storage.BinaryObject, Arq.PortalDemo.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[Arq.PortalDemo.Storage.TestObject, Arq.PortalDemo.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
