namespace Game_Zone.Setting;

public static class FileSettingImage
{
    public const string ImagesPath = "/assets/images/game";
    public const string AllowedExtensions = ".jpg,.jpeg,.png";
    public const int MaxFileSizeInMB = 1;
    public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
}
