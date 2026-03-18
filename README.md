
# 📚 KitapÇarşısı

KitapÇarşısı, ASP.NET Core MVC mimarisi kullanılarak geliştirilmiş bir kitap yönetim ve listeleme uygulamasıdır. Kullanıcılar kitapları inceleyebilir, arayabilir ve admin paneli üzerinden kitap/kategori yönetimi yapabilirler.

## Özellikler

- **Anasayfa:** Aktif kitapların listelenmesi.
- **Arama ve Filtreleme:** Kitap ismine göre arama ve kategorilere göre filtreleme özelliği.
- **Detay Görüntüleme:** Kitapların fiyat, sayfa sayısı ve özet bilgilerinin görüntülendiği detay sayfası.
- **Admin Paneli:**
  - Kitap Ekleme (Resim yükleme özelliği ile)
  - Kitap Düzenleme
  - Kitap Silme
  - Kategori Ekleme
  - Pasif/Aktif durum yönetimi

## Teknolojiler

- **Platform:** .NET Core
- **Dil:** C#
- **Web Framework:** ASP.NET Core MVC
- **Veri Yönetimi:** In-Memory Repository Pattern (Statik listeler)
- **Tasarım:** Bootstrap 5

## Kurulum

Projeyi çalıştırmak için bilgisayarınızda .NET SDK yüklü olmalıdır.

1. Proje dizinine gidin:
   ```bash
   cd BookApp
   ```

2. Uygulamayı başlatın:
   ```bash
   dotnet watch run
   ```
---

# 📚 BookBazaar

BookBazaar is a book management and listing application developed using the ASP.NET Core MVC architecture. Users can browse, search books and manage books/categories via the admin panel.

## Features

- **Homepage:** Listing active books.
- **Search & Filtering:** Search by book name and filter by categories.
- **Detail View:** Displays price, page count, and summary information.
- **Admin Panel:**
  - Add Book (with image upload)
  - Edit Book
  - Delete Book
  - Add Category
  - Active/Passive status management

## Technologies

- **Platform:** .NET Core
- **Language:** C#
- **Web Framework:** ASP.NET Core MVC
- **Data Management:** In-Memory Repository Pattern (Static lists)
- **UI:** Bootstrap 5

## Installation

Make sure you have .NET SDK installed.

1. Navigate to project folder:
   ```bash
   cd BookApp



   
## Notlar

- Veri tabanı kullanılmamıştır, veriler uygulama çalıştığı sürece bellekte tutulur. Uygulama yeniden başlatıldığında veriler sıfırlanır.
- Yüklenen resimler `wwwroot/img` klasöründe saklanır.

## Ekran Görüntüleri

### Proje Ekran Görüntüleri

![Anasayfa](assets/Anasayfa.png)
![Admin Paneli](assets/Admin_paneli.png)
![Kategori Ekleme](assets/Kategori_ekleme.png)
![Kitap Ekleme](assets/Kitap_ekleme.png)
