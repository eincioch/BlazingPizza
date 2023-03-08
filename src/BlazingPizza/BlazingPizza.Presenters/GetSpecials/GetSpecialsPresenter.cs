namespace BlazingPizza.Presenters.GetSpecials;
internal class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;
    public GetSpecialsPresenter(IOptions<SpecialsOptions> options) =>
        ImagesBaseUrl = options.Value.ImagesBaseUrl;

    public Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync(
        IReadOnlyCollection<PizzaSpecial> specials)
    {
        foreach (var Item in specials)
        {
            Item.ImageUrl = $"{ImagesBaseUrl}/{Item.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
}

