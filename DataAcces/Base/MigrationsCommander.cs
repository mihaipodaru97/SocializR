using Microsoft.EntityFrameworkCore;

namespace DataAcces.Base
{
    public class MigrationsCommander
    {
        private Context context;
        public MigrationsCommander(Context context)
        {
            this.context = context;
        }

        public void ApplyLastMigration()
        {
            context.Database.Migrate();
        }
    }
}
