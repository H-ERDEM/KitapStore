namespace BookApp.Models // 'BoookApp' değil 'BookApp' ve '.Controllers' değil '.Models'
{
    public static class Repository // Sınıfı 'static' yaparsan HomeController'dan erişebilirsin
    {
        private static readonly List<ProductBook> _productBooks = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Roman" });
            _categories.Add(new Category { CategoryId = 2, Name = "Kişisel Gelişim" });
            _categories.Add(new Category { CategoryId = 3, Name = "Bilim Kurgu" });
            _categories.Add(new Category { CategoryId = 4, Name = "Çizgi Roman" });

            _productBooks.Add(new ProductBook { BookId = 1, BookName = "Aşkın Sonu", PageCount = 200, IsActive = true, Image="/img/1.png", CategoryId = 1, Price = 250, Description = "Etkileyici bir aşk hikayesi." });
            _productBooks.Add(new ProductBook { BookId = 2, BookName = "Mutluluk Sanatı", PageCount = 200, IsActive = true,  Image="/img/2.png", CategoryId = 2, Price = 180, Description = "Mutluluğu arayanlar için rehber." });
            _productBooks.Add(new ProductBook { BookId = 3, BookName = "Ben Robot", PageCount = 200, IsActive = true, Image="/img/3.png", CategoryId = 3, Price = 300, Description = "Bilim kurgu klasikleri arasında." });
            _productBooks.Add(new ProductBook { BookId = 4, BookName = "Superman", PageCount = 60, IsActive = true, Image="/img/4.png", CategoryId = 4, Price = 1220, Description = "Superman, genellikle adaletin, umudun ve insanlığın sembolü olarak görülür. " });
        }

        public static List<ProductBook> Products => _productBooks;
        public static List<Category> Categories => _categories;

        public static void DeleteProduct(ProductBook entity)
        {
            var product = _productBooks.FirstOrDefault(p => p.BookId == entity.BookId);

            if (product != null)
            {
                _productBooks.Remove(product);
            }
        }
    }
}