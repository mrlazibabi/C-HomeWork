Console.OutputEncoding = System.Text.Encoding.UTF8;

//vi ten ng dung hay duoc luu duoi dang string
string tenNguoiDung = "Nguyen Van A";
Console.WriteLine("ten nguoi dung: " + tenNguoiDung);

//vi can chi so tuoi, khong am, va trong khoan co the luu tru
//thuc te khi luu do tuoi, dev thuong dung int
byte Age = 25;
Console.WriteLine("so tuoi: " + Age);

//vi can in dang so thuc
float averagePoint = 8.5f;
Console.WriteLine("diem trung binh: " + averagePoint);
//hoac co the
double averagePoint2 = 8.5;

//vi can in 1 ky tu unicode
char kyTu = 'N';
Console.WriteLine("Chu cai dau: " + kyTu);

//vi de kiem tra trang thai con ton tai -> true - false
bool isActive = true;
Console.WriteLine("trang thai hoat dong: " + isActive);

//in 1 so thap phan trong khoan 128 bit
decimal accountBalance = 1000.50m;
Console.WriteLine("so du tai khoan: " + accountBalance);
