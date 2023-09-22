namespace Game_Zone.ViewModels;

public class EditGameFormViewModel : GameFormViewModel
{
    public int Id { get; set; }

    public string? CurrentCover { get; set; }

    [AllowedExtensions(FileSettingImage.AllowedExtensions),
        MaxFileSize(FileSettingImage.MaxFileSizeInBytes)]
    public IFormFile? Cover { get; set; } = default!;
}
