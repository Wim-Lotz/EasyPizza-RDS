namespace EasyPizza.Application.Handlers;

public sealed class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, bool>
{
    private readonly IIngredientService _ingredientService;

    public DeleteIngredientCommandHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    public async Task<bool> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        return await _ingredientService.DeleteAsync(request.Id, cancellationToken);
    }
}