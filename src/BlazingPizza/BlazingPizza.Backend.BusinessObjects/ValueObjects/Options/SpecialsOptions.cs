namespace BlazingPizza.Backend.BusinessObjects.ValueObjects.Options;
public class SpecialsOptions
{
    public const string SectionKey = "Specials";
    public string ImagesBaseUrl { get; set; } =
        "https://ticapacitacion.blob.core.windows.net/blazingpizzaimages";
}
