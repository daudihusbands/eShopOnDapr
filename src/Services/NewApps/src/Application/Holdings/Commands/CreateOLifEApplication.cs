using NewApps.Application.Holdings;

namespace NewApps.Application.Holdings.Commands;
public class CreateOLifEApplication
{
    public class CreateOLifEApplicationHandler : IRequestHandler<Command, Holding>
    {
        private readonly IHoldingRepository _repository;

        public CreateOLifEApplicationHandler(IHoldingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Holding> Handle(Command request, CancellationToken cancellationToken)
        {
            var toUpdate = new Holding(request.HoldingTypeCode);
            toUpdate = await _repository.AddAsync(toUpdate);

            await _repository.SaveChangesAsync();

            return toUpdate;
        }
    }

    public record Command(WithTC HoldingTypeCode) : IRequest<Holding> { }
}
