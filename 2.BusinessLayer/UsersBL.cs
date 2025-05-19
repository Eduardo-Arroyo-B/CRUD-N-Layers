using _3.DataLayer;
using _3.DataLayer.Entities;

namespace _2.BusinessLayer;

public class UsersBL
{
    private readonly UsersDL _usersDL;

    public UsersBL(UsersDL usersDl)
    {
        _usersDL = usersDl;
    }
    
    public async Task<List<users>> GetAllAsync()
    {
        return await _usersDL.GetAllAsync();
    }
}