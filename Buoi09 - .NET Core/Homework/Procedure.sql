--Hiển thị tất cả các mặt hàng có giảm giá <= 10%
CREATE PROCEDURE get_discount_info @Discount decimal
AS
SELECT * FROM products
WHERE Discount = @Discount
EXEC get_discount_info @Discount = "<=10%"

--Hiển thị tất cả các mặt hàng có tồn kho <= 5 
CREATE PROCEDURE get_stock
	@Stock decimal
AS
SELECT * FROM products WHERE Stock = @Stock
EXEC get_stock @Stock = '<5'

