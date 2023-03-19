using FluentAssertions;
using FluentAssertions.Execution;
using NewApps.Application.Holdings;
using NewApps.Application.Holdings.Commands;
using NewApps.Domain.Entities.ACORD;
using NewApps.Infrastructure.Repositories;
using NUnit.Framework;

namespace NewApps.Application.IntegrationTests.Applications.Commands;

using static Testing;

public class CreateApplicationTests : BaseTestFixture
{
    [Test]
    public void ShouldRegister_IHoldingRepository()
    {
        var repo = GetService<IHoldingRepository>();

        using (var scope = new AssertionScope())
        {
            repo.Should().NotBeNull();
            repo.Should().BeOfType<HoldingRepository>();
        }
    }
    [Test]
    public void ShouldRequireMinimumFields()
    {
        var command = new CreateOLifEApplication.Command(HoldingTypeCode.Policy());

        using (var scope = new AssertionScope())
        {
            command.HoldingTypeCode.TC.Should().Be("2");
            command.HoldingTypeCode.Value.Should().Be("Policy");

            //await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }

   
}
