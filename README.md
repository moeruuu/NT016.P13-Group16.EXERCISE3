# NT016.P13-Group16
Lớp lý thuyết môn lập trình mạng căn bản NT016.P13

GVHD: Lê Minh Khánh Hội

Thành viên nhóm 16:
 1. 23521564	  Trần Lê Uyên Thy **(Leader)**
 2. 23520407    Lê Nguyễn Phương Giang
 3. 23520222	  Nguyễn Xuân Đan
 4. 23520718	  Huỳnh Quốc Khánh

## Mô tả
Bài tập xây dựng ứng dụng quản lý sách theo mô hình client-server được code bằng Winform C#. Sản phẩm được hoàn thiện qua 3 bài tập nhỏ.

File solution phía client: exer3.sln

File solution phía server: exercise3.sln

Link database: 

    mongodb+srv://btcuacoHoine:yeultmnhat@clusterbaitap.nibhk.mongodb.net/

***Chú ý**: Sau khi clone repo về, nếu không chạy được, hãy xóa file refresh_token.txt trong đường dẫn Exer3\server\exercise3\bin\Debug\net8.0-windows trước khi chạy chương trình*
### Hướng dẫn kết nối database MongoDB
 1. Tải MongoDB Compass: [Link download](https://www.mongodb.com/try/download/compass)
 2. Chạy file MongoDB Compass đã tải. Tạo tài khoản và đăng nhập
 3. Tại giao diện chính của MongoDB Compass, bấm vào dấu cộng ở phần **CONNECTIONS** để tạo kết nối mới
 4.  Copy link database ở trên và pass vào ô URI. Nhấn **Save & Connect**
 <img src="https://i.imgur.com/0wqSniY.png" width="800" />

*Lưu ý: Sau khi tạo kết nối thành công, khi chạy chương trình ở những lần sau không cần kết nối đến database thêm nữa*

## Bài tập số 3
*Viết ứng dụng quản lý người dùng với tính năng đăng nhập, đăng ký với TCP socket*
### Giao diện người dùng

 - Form đăng nhập
<img src="https://i.imgur.com/Tvg4OVr.png" width="500" />

 - Form đăng ký
<img src="https://i.imgur.com/y4e6lQa.png" width="500" />

 - Form home sau khi đăng nhập thành công
<img src="https://i.imgur.com/OaW6DTU.png" width="500" />

### Giao diện server

<img src="https://i.imgur.com/wZMznXy.png" width="500" />

### Các tính năng làm được
 - Đăng ký 
 - Đăng nhập 
 - Hiện thông tin người dùng 
 - Đăng xuất 
 - Cơ sở dữ liệu lưu trữ thông tin người dùng
 - Mã hóa mật khẩu

## Bài tập số 4
*Viết ứng dụng tìm kiếm và quản lý sách với Google Books API*
### Giao diện người dùng
 - Màn hình tìm kiếm sách
<img src="https://i.imgur.com/NjWTS9D.png" width="500" />

 - Màn hình hiển thị thông tin chi tiết sách
<img src="https://i.imgur.com/KcsvxfO.png" width="500" />

### Các tính năng làm được
 - Chức năng tìm kiếm sách
 - Hiển thị thông tin chi tiết sách
 - Liệt kê các kệ sách của người dùng
 - Liệt kê sách trong kệ sách
 - Thêm, xóa sách của kệ sách

## Bài tập số 5
*Viết các tính năng quên mật khẩu, thay đổi mật khẩu cho ứng dụng quản lý sách*
### Giao diện người dùng
 - Giao diện quên mật khẩu
<img src="https://i.imgur.com/cxnRQSC.png" width="500" />

 - Giao diện đổi mật khẩu
<img src="https://i.imgur.com/eGSQ6bb.png" width="500" />

 - Email nhận được
<img src="https://i.imgur.com/rxcnn5a.png" width="500" />

### Các tính năng làm được
 - Quên mật khẩu
 - Đổi mật khẩu
 - Đảm bảo tính bảo mật
