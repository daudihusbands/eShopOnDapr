using NewApps.Application.Common.Interfaces;

namespace NewApps.Application.Holdings.Commands;
public class CreateOLifEApplication
{
    public class CreateOLifEApplicationHandler : IRequestHandler<Command, Holding>
    {
        private readonly IHoldingRepository _repository;
        private readonly ITCRepository<HoldingTypeTC> _holdingTCRepository;

        public CreateOLifEApplicationHandler(IHoldingRepository repository, ITCRepository<HoldingTypeTC> holdingTCRepository)
        {
            _repository = repository;
            _holdingTCRepository = holdingTCRepository;
        }
        public async Task<Holding> Handle(Command request, CancellationToken cancellationToken)
        {
            // Create OLifE
            var oLife = new OLifE
            {
                SourceInfo = new SourceInfo("Source", "DTCC"),
                //Holding = new Holding("Holding_1")
                //{
                //    HoldingTypeCode = new WithTC("2", "Policy"),
                //    HoldingStatus = new WithTC("3", "Proposed - Pending - Not yet inforce"),
                //    CarrierAdminSystem = "DTCC",
                //    CurrencyTypeCode = new WithTC("840", "USD (United States Dollar)"),
                //    DistributorClientAcctNum = application.ApplicationContracts.FirstOrDefault()?.DistributorClientAccountID,
                //    AccountDesignation = new WithTC("3", "Owner"),
                //}
            };
            var holdingTC = await _holdingTCRepository.GetByCode(request.HoldingTypeCode.TC);

            var holding = new Holding(holdingTC, request.DistributorClientAcctNum);

            holding = await _repository.AddAsync(holding);

            await _repository.SaveChangesAsync();

            return holding;
        }
    }

    public record Command(HoldingTypeTC HoldingTypeCode, string DistributorClientAcctNum) : IRequest<Holding>
    {
    }
}
