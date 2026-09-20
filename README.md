# IEC_Match3_Unity_Game_Test

## REVIEW PROJECT

### 1. Ưu điểm

* Sử dụng **pure C#** cho Board, không phụ thuộc vào Unity Lifecycle, giúp logic dễ test và tái sử dụng.
* Sử dụng **State Machine** để quản lý trạng thái của game và UI.
* Sử dụng interface `IMenu` cho UI, giúp dễ mở rộng. Code giữa các panel cũng được tổ chức nhất quán.
* Sử dụng `GameSettings` dưới dạng ScriptableObject (SO) để tập trung các config của game (board size, animation duration, moves, time,...) vào một file duy nhất. Có Editor hỗ trợ tạo/mở file nhanh.
* Sử dụng **DOTween** để tăng game feel. Ngoài ra, game đã có các hệ thống special item như Bomb, Stripe, Shuffle khi stuck và Hint. Nhìn chung, trải nghiệm game khá tốt.

### 2. Nhược điểm

* `BoardController` đang đảm nhiệm quá nhiều trách nhiệm: input handling, match detection, hint, shuffle,... Nên tách ra, ví dụ tách riêng `InputService` để xử lý phần input.
* Hiện đang sử dụng **magic string** trong `Constants`, dễ xảy ra lỗi nếu nhập sai. Ngoài ra, mỗi khi thay đổi cần phải compile lại. Có thể sử dụng SO để quản lý các path.
* `LevelCondition` có 3 overload cho hàm `Setup()`. Có thể đưa phần setup riêng vào từng subclass, hoặc sử dụng Dependency Injection để quản lý dependency rõ ràng hơn.
* Chưa có `AudioService`, trong khi UI hiện tại chỉ thay đổi trạng thái.
* Về performance, ngoài các thay đổi đã áp dụng, Item hiện chưa sử dụng **Object Pooling** mà vẫn sử dụng `Instantiate/Destroy`.
* Một số xử lý chưa có **Null Guard**. Một vài vị trí đã được sửa, nhưng để xử lý triệt để trên toàn project thì cần review kỹ hơn.

### 3. Đề xuất

* Đặt **namespace** trong code theo từng module.
* Áp dụng các thay đổi đã đề cập trong phần nhược điểm, như thêm **Pooling + Factory** để quản lý việc khởi tạo và hủy Item, đồng thời tách các responsibility.
* Phân chia folder kết hợp với **Assembly Definition (asmdef)** để giảm thời gian compile code và phân chia dependency rõ ràng hơn.

```text
Assets/Scripts/
    Core/       (Constant, Utils, Interface,...)
    Gameplay/   (Board, Cell, BoardController,...)
    Data/       (GameSettings, NormalItemSkin,...)
    UI/
    Service/    (InputService, AudioService,...)
    Editor/
```
