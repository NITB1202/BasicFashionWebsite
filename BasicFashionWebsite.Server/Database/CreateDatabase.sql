CREATE database Fashion
use Fashion

Create Table Account
(
	account_id INT IDENTITY(1,1) PRIMARY KEY,
	username NVARCHAR(100) NOT NULL,
	password NVARCHAR(100) NOT NULL,
	role NVARCHAR(10) CHECK(role IN ('customer','admin')) NOT NULL
)

Create Table Product
(
	product_id INT IDENTITY(1,1) PRIMARY KEY,
	image_link NVARCHAR(100),
	name NVARCHAR(100) NOT NULL,
	description NVARCHAR(200),
	stock_quantity INT DEFAULT 0,
	cost INT CHECK(cost > 0)
)

Create Table Invoice
(
	invoice_id INT IDENTITY(1,1) PRIMARY KEY,
	order_date DATETIME DEFAULT GETDATE(),
	account_id INT NOT NULL,
	total INT CHECK(total > 0) NOT NULL,
	FOREIGN KEY(account_id) REFERENCES Account(account_id)
)

Create Table InvoiceDetails
(
	details_id INT IDENTITY(1,1) PRIMARY KEY,
	invoice_id INT NOT NULL,
	product_id INT NOT NULL,
	quantity INT CHECK(quantity > 0) NOT NULL,
	FOREIGN KEY(invoice_id) REFERENCES Invoice(invoice_id),
	FOREIGN KEY(product_id) REFERENCES Product(product_id)
)
