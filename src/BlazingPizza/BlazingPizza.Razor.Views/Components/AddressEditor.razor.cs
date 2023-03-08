namespace BlazingPizza.Razor.Views.Components;

public partial class AddressEditor
{
    [Parameter]
    public Address Address { get; set; }

    //private ElementReference NameInput;

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        await NameInput.FocusAsync();
    //    }
    //}
}
