# To Do App

Đây là project To Do App sử dụng SQL Server làm cơ sở dữ liệu.

## Yêu cầu hệ thống

- .NET SDK (tùy phiên bản, ví dụ .NET 6 hoặc .NET 7)
- SQL Server (có thể là SQL Server Express hoặc các phiên bản khác)
- IDE khuyến nghị: Visual Studio, VS Code

## Hướng dẫn cài đặt và chạy project

### 1. Clone repository

```bash
git clone https://github.com/truongphuc1309/to_do_app.git
cd to_do_app
```

### 2. Cài đặt các package/phụ thuộc

Project .NET (Backend):

```bash
dotnet restore
```

Project Angular (Frontend):

```bash
npm install
```

### 3. Cấu hình kết nối SQL Server

- Mở file `appsettings.json` (hoặc file cấu hình tương ứng).
- Tìm khóa `ConnectionStrings:DefaultConnection` và chỉnh sửa thông tin kết nối SQL Server theo máy bạn, ví dụ:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ToDoAppDb;User Id=sa;Password=your_password;"
}
```

- Đảm bảo SQL Server đã được cài đặt và chạy, database đã được tạo hoặc có script tự động tạo database.

#### Tạo database thủ công

Bạn có thể dùng script SQL sau để tạo database:

```sql
CREATE DATABASE ToDoAppDb;
```

Hoặc chạy migration nếu dùng Entity Framework:

```bash
dotnet ef database update
```

### 4. Chạy project

Nếu là project .NET:

```bash
dotnet run
```

Nếu là front-end:

```bash
npm start
```

Ứng dụng sẽ khởi động tại địa chỉ (thường là): [http://localhost:5000](http://localhost:5000) hoặc [http://localhost:8080](http://localhost:8080).

## Tham khảo

- [Hướng dẫn cài đặt SQL Server](https://docs.microsoft.com/vi-vn/sql/sql-server/)
- [Hướng dẫn sử dụng Entity Framework](https://learn.microsoft.com/vi-vn/ef/core/)

## Liên hệ

Nếu có vấn đề hãy liên hệ qua GitHub Issues hoặc email: truongphuc1309@gmail.com
