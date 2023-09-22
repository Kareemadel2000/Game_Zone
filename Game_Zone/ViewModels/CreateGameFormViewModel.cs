namespace Game_Zone.ViewModels;

public class CreateGameFormViewModel : GameFormViewModel
{
    [AllowedExtensions(FileSettingImage.AllowedExtensions),
        MaxFileSize(FileSettingImage.MaxFileSizeInBytes)]
    public IFormFile Cover { get; set; } = default!;

   

}
