# NT016.P13-Group16
Lớp lý thuyết lập trình mạng căn bản NT016.P13

GVHD: Lê Minh Khánh Hội

Thành viên nhóm 16:
 1. 23521564	  Trần Lê Uyên Thy **(Leader)**
 2. 23520401    Lê Nguyễn Phương Giang
 3. 23520222	  Nguyễn Xuân Đan
 4. 23520718	  Huỳnh Quốc Khánh

## Mô tả
Bài tập xây dựng ứng dụng quản lý sách theo mô hình client-server được code bằng Winform C#. Sản phẩm được hoàn thiện qua 3 bài tập nhỏ.

File solution phía client: exer3.sln

File solution phía server: exercise3.sln

Link database: 

    mongodb+srv://btcuacoHoine:yeultmnhat@clusterbaitap.nibhk.mongodb.net/

***Chú ý**: Sau khi clone repo về, cần xóa file refresh_token.txt trong đường dẫn Exer3\server\exercise3\bin\Debug\net8.0-windows trước khi chạy chương trình*
### Hướng dẫn kết nối csdl bằng MongoDB
 1. Tải MongoDB Compass: [Link download](https://www.mongodb.com/try/download/compass)
 2. Chạy file MongoDB Compass đã tải. Tạo tài khoản và đăng nhập
 3. Tại giao diện chính của MongoDB Compass, bấm vào dấu cộng ở phần **CONNECTIONS** để tạo kết nối mới
 4.  Copy link database ở trên và pass vào ô URI. Nhấn **Save & Connect**
 <img src="https://i.imgur.com/0wqSniY.png" width="800" />

*Lưu ý: sau khi đã tạo kết nối thành công, khi chạy chương trình ở những lần sau không cần kết nối đến database thêm nữa.*

## Bài tập số 3
*Viết ứng dụng quản lý người dùng với tính năng đăng nhập, đăng ký với TCP socket*
### Giao diện người dùng

 - Form đăng nhập
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

 - Form đăng ký
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

 - Form home sau khi đăng nhập thành công
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

### Giao diện server

<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

### Các kỹ thuật được sử dụng
 - Xử lý đăng ký 
 - Xử lý đăng nhập 
 - Hiện thông tin người dùng 
 - Đăng xuất 
 - Cơ sở dữ liệu 
 - Mã hóa mật khẩu

## Bài tập số 4
*Viết ứng dụng tìm kiếm và quản lý sách với Google Books API*
### Giao diện người dùng
 - Màn hình tìm kiếm sách
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

 - Màn hình hiển thị thông tin chi tiết sách
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

### Các kỹ thuật được sử dụng
 - Chức năng tìm kiếm sách
 - Hiển thị thôn tin chi tiết sách
 - Liệt kê kệ sách của người dùng
 - Thêm, xóa sách của kệ sách

## Bài tập số 5
*Viết các tính năng quên mật khẩu, thay đổi mật khẩu cho ứng dụng quản lý sách*
### Giao diện người dùng
 - Giao diện quên mật khẩu
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

 - Email nhận được
<img src="https://i.imgur.com/DjYrvRL.png" width="200" />

### Các kỹ thuật được sử dụng
 - Quên mật khẩu
 - Đổi mật khẩu
 - Bảo mật
