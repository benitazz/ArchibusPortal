#region

using System.Data.Entity;
using System.Linq;

using DurandalAuth.Domain.Model;
using DurandalAuth.Domain.Repositories;

#endregion

namespace DurandalAuth.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<Article> All()
        {
            return this.Context.Set<Article>().Include("Category");
        }
    }
}