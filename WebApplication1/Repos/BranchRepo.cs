using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class BranchRepo
    {
        readonly ISPContext context;

        public BranchRepo(ISPContext _context)
        {
            this.context = _context;
        }

    }
}
