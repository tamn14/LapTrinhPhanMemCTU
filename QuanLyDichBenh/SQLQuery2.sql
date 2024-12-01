CREATE DATABASE QLDB
GO  
USE QLDB
GO




-- Tạo bảng NguoiDung
CREATE TABLE NguoiDung (
    TenDangNhap VARCHAR(50) primary key,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro INT CHECK (VaiTro IN (1,2,3)) NOT NULL, 
    TenHienThi VARCHAR(50) 
);

-- Tạo bảng NongDan
CREATE TABLE NongDan (
    NongDanID INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(50),
    Ten VARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    DiaChi VARCHAR(255),
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(TenDangNhap) ON DELETE CASCADE
);

-- Tạo bảng ChuyenGia
CREATE TABLE ChuyenGia (
    ChuyenGiaID INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(50),
    Ten VARCHAR(100) NOT NULL,
    ChuyenMon VARCHAR(100),
    SoDienThoai VARCHAR(15),
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(TenDangNhap) ON DELETE CASCADE
);

-- Tạo bảng QuanLy
CREATE TABLE QuanLy (
    QuanLyID INT PRIMARY KEY IDENTITY(1,1),
	TenDangNhap VARCHAR(50),
    Ten VARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(TenDangNhap) ON DELETE CASCADE
);

CREATE TABLE MuaVu (
    MuaVuID INT PRIMARY KEY IDENTITY(1,1),
    TenMuaVu VARCHAR(100) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL
);

-- Tạo bảng GiongLua
CREATE TABLE GiongLua (
    GiongLuaID INT PRIMARY KEY IDENTITY(1,1),
    TenGiong VARCHAR(100) NOT NULL, 
	MuaVuID int ,
	FOREIGN KEY (MuaVuID) REFERENCES MuaVu(MuaVuID) ON DELETE CASCADE
);







-- Tạo bảng RuongLua
CREATE TABLE RuongLua (
    RuongLuaID INT PRIMARY KEY IDENTITY(1,1),
    NongDanID INT,
    Ten VARCHAR(100) NOT NULL,
    ViTri VARCHAR(255),
    DienTich DECIMAL(10, 2),
    GiongLuaID INT, 
    NgayGieo DATE,
    FOREIGN KEY (NongDanID) REFERENCES NongDan(NongDanID) ON DELETE CASCADE,
    FOREIGN KEY (GiongLuaID) REFERENCES GiongLua(GiongLuaID) ON DELETE CASCADE,
);



-- Tạo bảng DichBenh
CREATE TABLE DichBenh (
    DichBenhID INT PRIMARY KEY IDENTITY(1,1),
    Ten VARCHAR(100) NOT NULL,
    MoTa VARCHAR(MAX) -- Sử dụng NVARCHAR(MAX) cho mô tả
);



-- Tạo bảng BaoCaoDichBenh
CREATE TABLE BaoCaoDichBenh (
    BaoCaoID INT PRIMARY KEY IDENTITY(1,1),
    RuongLuaID INT,
    DichBenhID INT,
    NgayBaoCao DATE NOT NULL,
    MucDo INT CHECK (MucDo IN (1,2,3)),
    FOREIGN KEY (RuongLuaID) REFERENCES RuongLua(RuongLuaID) ON DELETE CASCADE,
    FOREIGN KEY (DichBenhID) REFERENCES DichBenh(DichBenhID) ON DELETE CASCADE
);


-- Tạo bảng BienPhapXuLy
CREATE TABLE BienPhapXuLy (
    BienPhapID INT PRIMARY KEY IDENTITY(1,1),
    DichBenhID INT,
    MoTa VARCHAR(MAX) NOT NULL,
    NgayDeXuat DATE,
    FOREIGN KEY (DichBenhID) REFERENCES DichBenh(DichBenhID) ON DELETE CASCADE
);











-- Bảng NguoiDung
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, TenHienThi)
VALUES 
('nguyenvana', 'A123', 1, 'Nguyen Van A'),
('tranthibinh', 'Binh123', 1, 'Tran Thi Binh'),
('lequocviet', 'viet123', 3, 'Le Quoc Viet'),
('phamthuy', 'Thuy123', 1, 'Pham Thuy'),
('danghuan', 'Huan123', 1, 'Dang Huan'),
('diemhuong', 'Huong123', 2, 'Banh Thi Diem Huong'),
('kieutien', 'Tien123', 2, 'Huynh Thi Kieu Tien'),
('camluyen', 'Luyen123', 2, 'Tran Thi Cam Luyen'),
('hoangquan', 'Quan123', 1, 'Nguyen Hoang Quan'),
('yenphuong', 'phuong123', 1, 'Van Yen Phuong');





-- Bảng NongDan

INSERT INTO NongDan (TenDangNhap, Ten, SoDienThoai, DiaChi)
VALUES
('nguyenvana', 'Nguyen Van A', '0981234567', 'Xa Truong Long, Huyen Phong Dien, TP Can Tho'),
('danghuan', 'Dang Huan', '0938765432', 'Xa Giai Xuan, Huyen Phong Dien, TP Can Tho'),
('tranthibinh', 'Tran Thi Binh', '0901236789', 'Xa Nhan Nghia, Huyen Phong Dien, TP Can Tho'),
('phamthuy', 'Pham Thuy', '0987654321', 'Xa Nhan Nghia, Huyen Phong Dien, TP Can Tho'),
('hoangquan', 'Nguyen Hoang Quan', '092212345', 'Xa Truong Long, Huyen Phong Dien, TP Can Tho'),
('yenphuong', 'Van Yen Phuong', '0789591627', 'Xa Truong Long, Huyen Phong Dien, TP Can Tho');





-- Bảng ChuyenGia

INSERT INTO ChuyenGia (TenDangNhap, Ten, ChuyenMon, SoDienThoai)
VALUES
('diemhuong', 'Banh Thi Diem Huong', 'Benh ly cay trong', '0981237890'),
('kieutien', 'Huynh Thi Kieu Tien', 'Ky thuat canh tac', '0912347890'),
('camluyen', 'Tran Thi Cam Luyen', 'Phan bon', '0934567890');


-- Bảng QuanLy
INSERT INTO QuanLy (TenDangNhap, Ten, SoDienThoai)
VALUES
('lequocviet', 'Le Quoc Viet', '0912361236');

INSERT INTO MuaVu (TenMuaVu, NgayBatDau, NgayKetThuc)
VALUES
('Vu Xuan 2024', '2024-01-01', '2024-04-30'),
('Vu He Thu 2024', '2024-05-01', '2024-08-31'),
('Vu Mua 2024', '2024-09-01', '2024-12-31'),
('Vu Dong Xuan 2024-2025', '2024-12-01', '2025-04-30'),
('Vu He Thu 2025', '2025-05-01', '2025-08-31'),
('Vu Mua 2025', '2025-09-01', '2025-12-31');


-- Bảng GiongLua
INSERT INTO GiongLua (TenGiong, MuaVuID)
VALUES
('ST24', 1),
('ST25', 1),
('OM7347', 2),
('OM6162', 2),
('IR50404', 1),
('Hoa Sua', 1),
('Tai Nguyen', 2),
('VNR20', 3),
('An Giang', 4),
('Lua Mua', 5),
('OM6162', 6),  
('IR50404', 2),
('Tai Nguyen', 3);  


-- Thêm các mùa vụ mới





-- Bảng RuongLua
INSERT INTO RuongLua (NongDanID, Ten, ViTri, DienTich, GiongLuaID, NgayGieo)
VALUES
(1, 'Ruong A1', 'Xa Truong Long, Huyen Phong Dien, Can Tho', 2.5, 1, '2023-01-15'),
(1, 'Ruong A1', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 1, '2023-01-15'),
(1, 'Ruong A1', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 1, '2023-01-15'),
(1, 'Ruong A2', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 2,'2023-01-15'),
(1, 'Ruong A2', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 2,'2023-01-15'),
(1, 'Ruong A2', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 2,'2023-01-15'),
(1, 'Ruong A3', 'Xa Truong Long,  Huyen Phong Dien, Can Tho', 2.5, 2,'2023-01-15'),
(2, 'Ruong A1', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 3.0, 1, '2024-01-15'),
(2, 'Ruong A2', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 2.9, 2,  '2024-05-10'),
(3, 'Ruong B1', 'Xa Hung Loi, Huyen O Mon, Can Tho', 3.5, 3, '2024-09-05'),
(3, 'Ruong B2', 'Xa Hung Loi, Huyen O Mon, Can Tho', 3.7, 4,  '2024-12-20'),
(3, 'Ruong B3', 'Xa Hung Loi, Huyen O Mon, Can Tho', 3.3, 5,  '2025-05-12'),
(3, 'Ruong C1', 'Xa Hung Loi, Huyen Thot Not, Can Tho', 2.8, 6,  '2025-09-15'),
(4, 'Ruong C2', 'Xa Hung Loi, Huyen Thot Not, Can Tho', 3.1, 7,  '2024-01-22'),
(4, 'Ruong D1', 'Xa Hung Loi, Huyen Phong Dien, Can Tho', 4.0, 8,  '2024-05-18'),
(4, 'Ruong D2', 'Xa Hung Loi, Huyen Phong Dien, Can Tho', 4.2, 9,  '2024-09-12'),
(5, 'Ruong D3', 'Xa Hung Loi, Huyen Phong Dien, Can Tho', 3.9, 10,  '2024-12-25'),
(5, 'Ruong E1', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 4.5, 1,  '2025-05-05'),
(5, 'Ruong E2', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 4.1, 2,  '2025-09-10'),
(5, 'Ruong F1', 'Xa Hung Loi, Huyen Binh Thuy, Can Tho', 3.6, 3,  '2024-01-05'),
(5, 'Ruong F2', 'Xa Hung Loi, Huyen Binh Thuy, Can Tho', 3.8, 4,  '2024-05-15'),
(6, 'Ruong G1', 'Xa Hung Loi, Huyen Ninh Kieu, Can Tho', 4.3, 5,  '2024-09-08'),
(6, 'Ruong G2', 'Xa Hung Loi, Huyen Ninh Kieu, Can Tho', 4.0, 6,  '2024-12-15'),
(6, 'Ruong H1', 'Xa Hung Loi, Huyen Thot Not, Can Tho', 3.7, 7,  '2025-05-01'),
(6, 'Ruong H2', 'Xa Hung Loi, Huyen Thot Not, Can Tho', 3.9, 8,  '2025-09-20'),
(6, 'Ruong I1', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 4.2, 9,  '2024-01-10'),
(6, 'Ruong I2', 'Xa Hung Loi, Huyen Cai Rang, Can Tho', 4.1, 10,  '2024-05-18');



-- Thêm 10 dịch bệnh mới không có dấu
INSERT INTO DichBenh (Ten, MoTa)
VALUES
('Benh Vang La', 'Benh do virus gay ra, lam cho la bi vang va kho'),
('Benh Kho Van', 'Gay hai tren la va than lua, xuat hien cac dom mau nau'),
('Benh Thoi Den Co Re', 'Thoi phan goc va co re cua cay lua, do vi khuan gay ra'),
('Benh Bac La', 'La cay bi bac mau va heo kho dan'),
('Benh Lun Xoan La', 'Cay lua bi lun va la xoan lai'),
('Benh Dao On', 'Gay ra cac vet dom hinh thoi tren la'),
('Benh Sau Duc Than', 'Sau non duc vao than cay lua lam giam nang suat'),
('Benh Ray Xanh', 'Ray xanh tan cong lam cay lua suy yeu'),
('Benh Thoi Than', 'Gay thoi den than cay lua, lay lan nhanh trong dieu kien am uot'),
('Benh Vang La Chin Som', 'Lam la vang som va cay lua phat trien khong deu');


INSERT INTO BaoCaoDichBenh (RuongLuaID, DichBenhID, NgayBaoCao, MucDo)
VALUES
(1, 1, '2024-01-20', 1), 
(1, 2, '2024-02-15', 2),  
(2, 3, '2024-01-25', 3),  
(2, 4, '2024-02-10', 2),  
(3, 5, '2024-03-01', 1),  
(4, 6, '2024-04-05', 3), 
(5, 7, '2024-05-10', 2),  
(6, 8, '2024-05-15', 1),  
(7, 9, '2024-06-20', 2),  
(8, 10, '2024-07-01', 3),
(9, 1, '2024-01-30', 2),  
(9, 2, '2024-02-20', 1), 
(10, 3, '2024-03-10', 3), 
(1, 4, '2024-04-25', 1),  
(2, 5, '2024-05-30', 2),  
(3, 6, '2024-06-15', 3), 
(4, 7, '2024-07-20', 2),  
(5, 8, '2024-08-10', 1),  
(6, 9, '2024-09-05', 3),  
(7, 10, '2024-09-20', 2), 
(8, 1, '2024-10-01', 1),   
(9, 2, '2024-10-15', 3),   
(10, 3, '2024-10-30', 2); 

INSERT INTO BaoCaoDichBenh (RuongLuaID, DichBenhID, NgayBaoCao, MucDo)
VALUES
(11, 1, '2024-01-20', 1), 
(11, 2, '2024-02-15', 2),  
(12, 3, '2024-01-25', 3),  
(12, 4, '2024-02-10', 2),  
(13, 5, '2024-03-01', 1),  
(13, 6, '2024-04-05', 3), 
(13, 7, '2024-05-10', 2),  
(14, 8, '2024-05-15', 1),  
(14, 9, '2024-06-20', 2),  
(15, 10, '2024-07-01', 3),
(15, 1, '2024-01-30', 2),  
(16, 2, '2024-02-20', 1), 
(16, 3, '2024-03-10', 3), 
(16, 4, '2024-04-25', 1),  
(17, 5, '2024-05-30', 2),  
(17, 6, '2024-06-15', 3), 
(18, 7, '2024-07-20', 2),  
(19, 8, '2024-08-10', 1),  
(20, 9, '2024-09-05', 3),  
(21, 10, '2024-09-20', 2), 
(22, 1, '2024-10-01', 1),   
(23, 2, '2024-10-15', 3),   
(24, 3, '2024-10-30', 2),
(25, 7, '2024-07-20', 2),  
(25, 8, '2024-08-10', 1); 





-- Thêm 10 biện pháp xử lý mới
INSERT INTO BienPhapXuLy (DichBenhID, MoTa, NgayDeXuat)
VALUES
(1, 'Su dung thuoc phong benh truoc khi benh bung phat', '2024-06-10'),
(2, 'Phun thuoc bao ve thuc vat', '2024-07-15'),
(3, 'Su dung phan huu co', '2024-08-05'),
(4, 'Tang cuong che do tuoi nuoc', '2024-09-20'),
(5, 'Luon don sach co dai', '2024-10-11'),
(6, 'Su dung che pham khang benh', '2024-11-01'),
(7, 'Tang cuong bo sung vi sinh', '2024-12-05'),
(8, 'Phun khach che dinh ky', '2025-01-15'),
(9, 'Tao moi truong khoe manh', '2025-02-20'),
(10, 'Ket hop phan bon vo co va huu co', '2025-03-10');

select * from BaoCaoDichBenh


create Proc USP_lg
@username varchar(50) , @password varchar(255) 
as
begin
	select * from NguoiDung where TenDangNhap = @username and MatKhau = @password
end









SELECT d.ten AS [Tên Dịch Bệnh] , b.mota AS [Cách Điều Trị], b.ngaydexuat as [Ngày Đề Xuất] FROM DichBenh d ,  BienPhapXuLy b where d.DichBenhID = b.DichBenhID;

select b.ten , d.ten, d.vitri  , d.dientich ,  d.tengionglua , d.ngaygieo 
from NguoiDung a , NongDan b, RuongLua d 
where a.TenDangNhap = b.TenDangNhap and b.NongDanId = d.NongDanId



SELECT 
   n.Ten , r.Ten , d.Ten , g.TenGiong , b.MucDo , b.NgayBaoCao
FROM RuongLua r
JOIN NongDan n ON r.NongDanID = n.NongDanID
JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID
LEFT JOIN BaoCaoDichBenh b ON r.RuongLuaID = b.RuongLuaID
LEFT JOIN DichBenh d ON b.DichBenhID = d.DichBenhID
WHERE n.TenDangNhap = 'phamthuy';


 SELECT n.Ten as TenNhaNong,  r.Ten as TenRuong,   d.Ten as TenDichBenh,  g.TenGiong,   b.MucDo,  b.NgayBaoCao   
 FROM RuongLua r  
 JOIN NongDan n ON r.NongDanID = n.NongDanID   
 JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID 
 JOIN BaoCaoDichBenh b ON r.RuongLuaID = b.RuongLuaID 
 JOIN DichBenh d ON b.DichBenhID = d.DichBenhID   
 WHERE n.TenDangNhap = 'yenphuong';


 SELECT 
    rl.Ten AS TenRuong,
    db.Ten AS TenDichBenh,
    gl.TenGiong AS TenGiongLua,
    bpxl.MoTa AS CachXuLy,
    bcd.NgayBaoCao
FROM 
    BaoCaoDichBenh bcd
JOIN RuongLua rl ON bcd.RuongLuaID = rl.RuongLuaID
JOIN DichBenh db ON bcd.DichBenhID = db.DichBenhID
JOIN GiongLua gl ON rl.GiongLuaID = gl.GiongLuaID
LEFT JOIN BienPhapXuLy bpxl ON bpxl.DichBenhID = db.DichBenhID
JOIN NongDan nd ON rl.NongDanID = nd.NongDanID
WHERE 
    nd.TenDangNhap = 'yenphuong'


	select d.DichBenhID , b.MoTa , b.NgayDeXuat 
	from DichBenh d
	left join BienPhapXuLy b on b.DichBenhID = d.DichBenhID


	select n.Ten , n.DiaChi , n.SoDienThoai , r.Ten , g.TenGiong , m.TenMuaVu from RuongLua r , NongDan n, GiongLua g , MuaVu m
	where r.NongDanID = n.NongDanID and r.GiongLuaID = g.GiongLuaID and m.MuaVuID = g.MuaVuID

	select d.Ten , d.MoTa , b.MoTa , b.NgayDeXuat from DichBenh d , BienPhapXuLy b where d.DichBenhID = b.DichBenhID



CREATE PROC USP_GetListDongRuong
    @page INT
AS
BEGIN
    DECLARE @pageRow INT = 10
    DECLARE @startRow INT = (@page - 1) * @pageRow + 1
    DECLARE @endRow INT = @page * @pageRow

    ;WITH DongRuongShow AS 
    (
        SELECT 
            n.Ten AS TenNhaNong, 
            n.DiaChi, 
            n.SoDienThoai, 
            r.Ten AS TenRuong, 
            g.TenGiong, 
            m.TenMuaVu,
            ROW_NUMBER() OVER (ORDER BY n.Ten) AS RowNum
        FROM RuongLua r
        JOIN NongDan n ON r.NongDanID = n.NongDanID
        JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID
        JOIN MuaVu m ON g.MuaVuID = m.MuaVuID
    )
    SELECT 
        TenNhaNong, DiaChi, SoDienThoai, TenRuong, TenGiong, TenMuaVu
    FROM DongRuongShow
    WHERE RowNum BETWEEN @startRow AND @endRow
END



--------------------------------------------


CREATE PROC USP_GetListDB	
    @page INT
AS
BEGIN
    DECLARE @pageRow INT = 10
    DECLARE @startRow INT = (@page - 1) * @pageRow + 1
    DECLARE @endRow INT = @page * @pageRow

    ;WITH DBShow AS 
    (
        SELECT 
            n.Ten AS tenDichBenh, 
            n.MoTa, 
           
            ROW_NUMBER() OVER (ORDER BY n.Ten) AS RowNum
        FROM DichBenh n
		 
       
    )
    SELECT 
        tenDichBenh  ,MoTa
    FROM DBShow
    WHERE RowNum BETWEEN @startRow AND @endRow
END









----------------------













CREATE PROC USP_GetListDichBenh
    @page INT
AS
BEGIN
    DECLARE @pageRow INT = 10;
    DECLARE @startRow INT = (@page - 1) * @pageRow + 1;
    DECLARE @endRow INT = @page * @pageRow;

    ;WITH DichBenhShow AS 
    (
        SELECT 
            rl.RuongLuaID, 
            rl.Ten AS TenRuong,
            rl.ViTri,
            rl.DienTich,
            gl.TenGiong,
            db.Ten AS TenDichBenh,
            bcd.NgayBaoCao,
            COALESCE(CONVERT(VARCHAR, bcd.MucDo), 'Chua phat hien') AS MucDo,
            ROW_NUMBER() OVER (ORDER BY rl.RuongLuaID) AS RowNum
        FROM  
            RuongLua rl 
            LEFT JOIN GiongLua gl ON rl.GiongLuaID = gl.GiongLuaID
            LEFT JOIN BaoCaoDichBenh bcd ON rl.RuongLuaID = bcd.RuongLuaID
            LEFT JOIN DichBenh db ON bcd.DichBenhID = db.DichBenhID
    )
    SELECT 
        RuongLuaID, 
        TenRuong, 
        ViTri, 
        DienTich, 
        TenGiong, 
        TenDichBenh, 
        NgayBaoCao, 
        MucDo
    FROM 
        DichBenhShow
    WHERE 
        RowNum BETWEEN @startRow AND @endRow
    ORDER BY 
        RowNum;
END;


exec USP_GetListDichBenh 5



SELECT 
           count(*)
        FROM DichBenh d
        JOIN BienPhapXuLy b ON d.DichBenhID = b.DichBenhID


exec USP_GetListDichBenh @page 

 SELECT  count(*)  FROM RuongLua r JOIN NongDan n ON r.NongDanID = n.NongDanID JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID JOIN MuaVu m ON g.MuaVuID = m.MuaVuID



SELECT G.TenGiong, COUNT(R.GiongLuaID) AS SoLuongGieo FROM RuongLua R
JOIN GiongLua G ON R.GiongLuaID = G.GiongLuaID GROUP BY G.TenGiong
HAVING COUNT(R.GiongLuaID) = ( SELECT MAX(SoLuong) FROM (
SELECT COUNT(GiongLuaID) AS SoLuong FROM RuongLua GROUP BY GiongLuaID) AS T);


SELECT N.Ten, COUNT(R.RuongLuaID) AS SoLuongRuong FROM NongDan N
JOIN RuongLua R ON N.NongDanID = R.NongDanID GROUP BY N.Ten
HAVING COUNT(R.RuongLuaID) = ( SELECT MAX(SoLuong) FROM (
SELECT COUNT(RuongLuaID) AS SoLuong FROM RuongLua GROUP BY NongDanID) AS T);

SELECT Ten, DienTich FROM RuongLua WHERE DienTich = (SELECT Min(DienTich) FROM RuongLua)




SELECT G.TenGiong, M.TenMuaVu, COUNT(R.RuongLuaID) AS SoLanGieo
FROM GiongLua G
JOIN RuongLua R ON G.GiongLuaID = R.GiongLuaID
JOIN MuaVu M ON G.MuaVuID = M.MuaVuID
GROUP BY G.TenGiong, M.TenMuaVu
ORDER BY M.TenMuaVu, SoLanGieo DESC;

select TenGiong , TenMuaVu from GiongLua g , MuaVu m where g.MuaVuID = m.MuaVuID






select count(*)
from DichBenh d, BaoCaoDichBenh b, RuongLua r 
Where d.DichBenhID = b.DichBenhID and r.RuongLuaID = b.RuongLuaID

Select c.ten as TenChuyenGia  , c.chuyenmon , c.sodienthoai , n.TenDangNhap , n.Matkhau , n.TenHienThi  from ChuyenGia c , nguoidung n where c.TenDangNhap = n.TenDangNhap and ten like '%Huong%' ; 