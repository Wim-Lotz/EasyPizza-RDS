namespace EasyPizza.Application.Handlers;

public class DeleteIngredientCommandHandler:IRequestHandler<DeleteIngredientCommand, bool>
{
    private readonly IIngredientService _ingredientService;

    public DeleteIngredientCommandHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    public Task<bool> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        return _ingredientService.DeleteAsync(request.Id, cancellationToken);
    }
}