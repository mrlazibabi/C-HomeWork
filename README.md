# Quản lý hàng đợi khách hàng - Developer Bank

Bạn nhận được dự án phát triển một chương trình quản lý hàng đợi của khách hàng rút tiền tại ngân hàng. với các yêu cầu như sau:

Có 2 hằng chờ:
- dành cho khách hàng thường
- dành cho khách hàng VIP

Tạo menu chức năng cho người dùng để thực hiện các thao tác sau:

```console
1. Thêm khách hàng vào hàng đợi.
2. Gọi tên khách hàng kế tiếp (VIP)
3. Gọi tên khách hàng kế tiếp (Thường).
4. Danh Sách Khách hàng sắp tới.
5. Thống kê
6. Thoát khỏi chương trình.

Chọn một chức năng (1-6): 
```

1. Khi thêm khách hàng vào hàng đợi
  - Nhập thông tin sau: Tên khách hàng và Số tiền cần rút. 
  - Nếu số tiền cần rút lớn hơn 500, khách hàng sẽ được coi là VIP và được thêm vào cuối hàng đợi của khách VIP. Ngược lại khách hàng sẽ được thêm vào cuối hàng đợi của khách bình thường.
  - Mỗi khách hàng khi thêm vào hàng đợi sẽ được gán một số thứ tự.

2. Khi gọi tên khách hàng kế tiếp(VIP và Thường)
  - Hiển thị tên và số thứ tự của khách hàng đến lượt rút tiền.
  - Sau khi hiển thị thì coi như là khách hàng này đã hoàn thành việc rút tiền và không nằm trong hàng đợi rút tiền nữa.

4. Danh Sách Khách hàng sắp tới:
  - Hiển thị thông tin về 3 khách hàng gần nhất hàng đợi VIP và tổng số lượng khách hàng đang chờ
  - Hiển thị thông tin về 3 khách hàng gần nhất hàng đợi Thường và tổng số lượng khách hàng đang chờ

5. Trong phần thống kê hiển thị 3 thông tin nhau:
  - Hiển thị danh sách các khách hàng đã rút tiền.
  - Tính tổng số tiền đã rút từ danh sách khách hàng.
  - Hiển thị tổng số tiền còn lại trong hàng đợi(cả VIP và Thường).

- Chương trình sẽ dùng LinkedList & Queue để thao tác dữ liệu.
- Hãy mở trang web [draw.io](https://app.diagrams.net/) và mở file [file diagram để dễ làm việc](capstone-diagram.drawio) để xem chi tiết.
- Menu chương trình như sau:

```console
=== Thêm khách hàng vào hàng đợi ===
Nhập thông tin khách hàng:

Tên: Huy
Số tiền cần rút: 600

Khách hàng Huy đã được thêm vào hằng đợi VIP
Số thứ tự là: 1
```

```console
=== Gọi tên khách hàng kế tiếp (VIP) ===
Đến lượt khách hàng VIP:

Số thứ tự: 1
Tên: Huy
Số tiền cần rút: 600

Đã rút thành công số tiền: 600 VND
```

```console
=== Gọi tên khách hàng kế tiếp (Thường) ===
Đến lượt khách hàng Thường:

Số thứ tự: 15
Tên: Culy
Số tiền cần rút: 300

Đã rút thành công số tiền: 300 VND
```

```console
=== Danh Sách Khách hàng sắp tới ===
Hàng đợi VIP:

1. VIP002 - Robert
2. VIP003 - Hello
3. VIP004 - David

Hàng đợi Thường:

1. Eco003 - Mario
2. Eco004 - Solo
3. Eco005 - Mabu

Tổng số khách VIP đang chờ: 3
Tổng số khách thường đang chờ: 30
```

```console
=== Thống kê ===
1. Danh sách khách đã rút:
  1. VIP002 - Robert
  2. VIP003 - Hello
  3. VIP004 - David
  4. Eco003 - Mario
  ...

2. Tổng tiền đã rút: 100,000
3. Tổng tiền trong hằng chờ: 50,000
```

- Dữ liệu của chương trình lưu trong file JSON và sẽ không bị mất nếu chương trình đột ngột dừng lại.
- Tạo dữ liệu giả bằng cách https://www.mockaroo.com/
- Viết unit test cho các hàm đã triển khai để đảm bảo hoạt động được như mong đợi
- Nâng cao: Giả sử rằng mỗi một lần khách hàng có rút tiền có 1 mã số rút tiền riêng biệt hãy triển khai hàm tìm kiếm thông tin lần rút tiền dựa trên mã số rút tiền này. Lưu ý sử dụng binary search tree để tối ưu hóa việc tìm kiếm. kết quả là hiển thị thông tin về giao dịch này.
