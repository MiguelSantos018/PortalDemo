using Arq.PortalDemo.EntityFrameworkCore;

namespace Arq.PortalDemo.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly PortalDemoDbContext _context;

        public InitialHostDbBuilder(PortalDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
