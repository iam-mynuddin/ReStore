using API.Entities;
using API.Migrations;

namespace API.Extentions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query,string orderBy)
        {
            if(string.IsNullOrEmpty(orderBy)) return query.OrderBy(u=>u.Name);

            query = orderBy switch
            {
                "price" => query.OrderBy(u => u.Price),
                "priceDesc" => query.OrderByDescending(u => u.Price),
                _ => query.OrderBy(u => u.Name),
            };
            return query;
        }
        public static IQueryable<Product> Search(this IQueryable<Product> query,string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;
            string lowerCaseSearchTerm=searchTerm.Trim().ToLower();
            return query.Where(u=>u.Name.ToLower().Contains(lowerCaseSearchTerm));
        }
        public static IQueryable<Product> Filter(this IQueryable<Product> query,string brands,string types)
        {
            var brandList=new List<string>();
            var typeList=new List<string>();
            if(!string.IsNullOrEmpty(brands))
            brandList.AddRange(brands.ToLower().Split(',').ToList());
            if(!string.IsNullOrEmpty(types))
            brandList.AddRange(types.ToLower().Split(',').ToList());

            query=query.Where(u=>brandList.Count==0||brandList.Contains(u.Brand.ToLower()));
            query=query.Where(u=>typeList.Count==0||typeList.Contains(u.Type.ToLower()));

            return query;

        }
    }
}
