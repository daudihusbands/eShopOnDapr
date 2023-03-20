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

    [SetUp]
    public async Task InitThese()
    {
        var init = GetService<ApplicationDbContextInitialiser>();
        await init.InitialiseAsync();
        await init.SeedAsync();

    }
    [Test]
    public async Task ShouldRegister_IHoldingRepository()
    {
        var repo = GetService<IHoldingRepository>();

        using (var scope = new AssertionScope())
        {

        }
        repo.Should().NotBeNull();
        repo.Should().BeOfType<HoldingRepository>();
        var holdings = await repo.GetAll();
    }
    [Test]
    public async Task ShouldCreateOLife()
    {
        var command = new CreateOLifEApplication.Command(HoldingTypeTC.Policy(), "DistributorClientAcctNum");
        var result = await SendAsync(command);

        using (var scope = new AssertionScope())
        {
            command.HoldingTypeCode.TC.Should().Be("2");
            command.HoldingTypeCode.Value.Should().Be("Policy");

            //await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }


}
