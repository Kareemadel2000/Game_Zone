namespace Game_Zone.Services;

public class DeviceService : IDeviceService
{
    private readonly ApplicationDBContext _dbContext;

    public DeviceService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<SelectListItem> GetSelectListsDevice()
    {
        return _dbContext.Devices
            .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            .OrderBy(d => d.Text)
            .AsNoTracking()
            .ToList();
    }
}
