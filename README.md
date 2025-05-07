# RESTAPI-PusdatinATRBPN


# 🌍 Places API - .NET CORE 8 Rest API

API ini dibangun menggunakan **ASP.NET Core 8** dengan arsitektur clean dan lightweight, menyediakan endpoint untuk manajemen data lokasi/tempat (Places). Cocok digunakan untuk backend aplikasi pemetaan atau manajemen lokasi pengguna.

## 🚀 Fitur Utama

- ✅ CRUD: Create, Read, Update, Soft Delete tempat
- 🔄 AutoMapper untuk mapping DTO ke Entity
- 📦 FluentValidation untuk validasi request
- 🧩 Repository Pattern (bisa dengan EF Core / Dapper)
- ❌ Tanpa otentikasi (No JWT/Login)

## 🛠️ Teknologi

- .NET Core 8
- Entity Framework Core 8
- SQL Server
- AutoMapper
- FluentValidation
- Dapper (opsional)

## ⚙️ Struktur Proyek

```
/Controllers
/Models
/DTOs
/Repositories
/Services
/Validators
/Helpers
```

## 🔧 Konfigurasi

**Connection string** (di `appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=place;Trusted_Connection=True;TrustServerCertificate=True;"
},
```

## 🔄 Endpoints API

| Method | Endpoint                | Deskripsi                     |
|--------|-------------------------|-------------------------------|
| GET    | `/api/Places`           | Ambil semua tempat            |
| GET    | `/api/Places/Show` | Detail tempat berdasarkan ID  |
| POST   | `/api/Places/Store`     | Tambah tempat baru            |
| PUT    | `/api/Places/Update` | Update tempat              |
| DELETE | `/api/Places/Delete` | Soft delete tempat         |

## 🧪 Validasi

Semua input divalidasi menggunakan `FluentValidation`:
- `Places_AddValidator`
- `Places_UpdateValidator`

## ✅ Menjalankan Proyek

1. `git clone https://github.com/username/places-api.git`
2. Buka di **Visual Studio 2022/2025**
3. Jalankan Query Create Table SQL Server 
	CREATE TABLE Places (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OwnerName NVARCHAR(100),
    PlaceName NVARCHAR(100),
    Address NVARCHAR(255),
    PlacesType NVARCHAR(50),
    Date DATETIME);
	
4. Jalankan project tombol > diatas didalam Visual Studio
5. Muncul Swagger
