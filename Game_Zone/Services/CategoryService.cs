namespace Game_Zone.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDBContext _dbContext;

    public CategoryService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<SelectListItem> GetSelectListCategory()
    {
        return _dbContext.Categories
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();
    }
}
