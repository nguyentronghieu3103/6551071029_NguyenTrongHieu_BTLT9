-- ========================================================
-- SCRIPT TẠO CƠ SỞ DỮ LIỆU VÀ DỮ LIỆU MẪU: QL_DatTour
-- ========================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QL_DatTour')
BEGIN
    CREATE DATABASE QL_DatTour;
END
GO

USE QL_DatTour;
GO

-- 1. Bảng Tour
IF OBJECT_ID('dbo.DatTour', 'U') IS NOT NULL DROP TABLE dbo.DatTour;
IF OBJECT_ID('dbo.Tour', 'U') IS NOT NULL DROP TABLE dbo.Tour;
IF OBJECT_ID('dbo.KhachHang', 'U') IS NOT NULL DROP TABLE dbo.KhachHang;

CREATE TABLE Tour (
    MaTour INT IDENTITY(1,1) PRIMARY KEY,
    TenTour NVARCHAR(100) NOT NULL,
    DiemDen NVARCHAR(50) NOT NULL,
    NgoaiTe CHAR(3) NOT NULL, -- THB, KRW, JPY, USD, VND
    GiaNgoaiTe DECIMAL(18,2) NOT NULL,
    NgayKhoiHanh DATE NOT NULL,
    SoChoToiDa INT NOT NULL
);

-- 2. Bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NULL
);

-- 3. Bảng DatTour
CREATE TABLE DatTour (
    MaDat INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaTour INT NOT NULL FOREIGN KEY REFERENCES Tour(MaTour),
    SoNguoi INT NOT NULL,
    NgayDat DATETIME DEFAULT GETDATE(),
    TyGia DECIMAL(18,4) NOT NULL,
    TongTienVND DECIMAL(18,0) NOT NULL
);
GO

-- ========================================================
-- DỮ LIỆU MẪU (THEO YÊU CẦU ĐỀ BÀI)
-- ========================================================

-- Nhập 5 tour với các ngoại tệ khác nhau
INSERT INTO Tour (TenTour, DiemDen, NgoaiTe, GiaNgoaiTe, NgayKhoiHanh, SoChoToiDa) VALUES
(N'Bangkok - Pattaya 5N4Đ', N'Thái Lan', 'THB', 9500.00, '2026-11-15', 20),
(N'Seoul - Nami - Everland', N'Hàn Quốc', 'KRW', 850000.00, '2026-11-20', 15),
(N'Tokyo - Núi Phú Sĩ 4N3Đ', N'Nhật Bản', 'JPY', 120000.00, '2026-12-05', 15),
(N'Khám phá bờ Tây nước Mỹ', N'Mỹ', 'USD', 1500.00, '2026-12-10', 10),
(N'Phuket - Thiên đường biển', N'Thái Lan', 'THB', 8000.00, '2026-11-25', 25);

-- Nhập danh sách khách hàng
INSERT INTO KhachHang (HoTen, SoDienThoai, Email) VALUES
(N'Lê Văn An', '0912345678', 'levanan@example.com'),
(N'Phạm Minh Hùng', '0987654321', 'hungpm@example.com'),
(N'Trần Thị Mai', '0901112233', 'maitt@example.com'),
(N'Hoàng Thu Thảo', '0933445566', 'thaoth@example.com');

-- Nhập dữ liệu đặt tour mẫu
INSERT INTO DatTour (MaKH, MaTour, SoNguoi, NgayDat, TyGia, TongTienVND) VALUES
(1, 1, 2, '2026-10-15 09:30:00', 772.0000, 14668000),
(2, 2, 2, '2026-10-16 14:15:00', 19.3800, 32946000),
(3, 4, 1, '2026-10-17 11:00:00', 25870.0000, 38805000);
GO
