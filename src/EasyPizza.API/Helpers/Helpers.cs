using EasyPizza.Contracts.Requests.V1;
using EasyPizza.Domain.Enums;

namespace EasyPizza.API.Helpers;

public static class Helpers
{
    public static (string? sortField, SortOrder sortOrder ) GetSortInfo(this GetAllIngredientsRequest request)
    {
        var sortField = request.SortBy?.Trim('+', '-');
        var sortOrder = request.SortBy is null ? SortOrder.Unsorted :
            request.SortBy.StartsWith('-') ? SortOrder.Descending :
            SortOrder.Ascending;

        return (sortField, sortOrder);
    }
}