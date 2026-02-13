Berikut adalah desain arsitektur Clean Architecture untuk aplikasi BOOK Library:

**Domain Layer**

* **Entity**: Book, User, Reservation
	+ Book memiliki atribut seperti Title, Author, ISBN, dan Synopsis
	+ User memiliki atribut seperti Email, Password, dan Profile Details
	+ Reservation memiliki atribut seperti Book ID, User ID, dan Loan Period
* **Value Object**: Rating, Review
	+ Rating memiliki atribut seperti Score dan Count
	+ Review memiliki atribut seperti Text dan Date Created

**Application Layer**

* **Use Case**: CreateBook, UpdateBook, DeleteBook, BorrowBook, ReturnBook, ReserveBook, CheckAvailability
	+ CreateBook: Membuat buku baru dengan atribut yang lengkap
	+ UpdateBook: Mengupdate informasi buku yang sudah ada
	+ DeleteBook: Menghapus buku dari inventori
	+ BorrowBook: Meminjam buku untuk periode pinjaman tertentu
	+ ReturnBook: Mengembalikan buku ke inventori
	+ ReserveBook: Merekrut buku yang sedang dipinjam
	+ CheckAvailability: Mengecek ketersediaan buku

**Infrastructure Layer**

* **Repository**: BookRepository, UserRepository, ReservationRepository
	+ BookRepository: Mengelola data buku di database
	+ UserRepository: Mengelola data user di database
	+ ReservationRepository: Mengelola data reservasi di database
* **Database**: Database yang digunakan untuk menyimpan data aplikasi

**Penggunaan Pola yang Sudah Ada**

* Repository Pattern: Digunakan untuk mengelola data buku, user, dan reservasi
* Unit of Work Pattern: Digunakan untuk mengelola transaksi database

**Struktur AST**

* Context:
	+ Document(metadata={'layer': 'Domain', 'method_name': 'CreateBook', 'namespace': 'Domain.Entities', 'file_path': '..\\src\\Domain\\Entities\\Book.cs', 'symbol_name': 'Book', 'symbol_type': 'method', 'source': '..\\src\\Domain\\Entities\\Book.cs'}, page_content='{\n            this.Title = title;\n            this.Author = author;\n            this.ISBN = isbn;\n        }')
	+ Document(metadata={'layer': 'Application', 'method_name': 'Handle', 'namespace': 'Application.Books.Commands.CreateBook', 'symbol_name': 'CreateBookHandler', 'file_path': '..\\src\\Application\\Books\\Commands\\CreateBook\\CreateBookHandler.cs', 'symbol_type': 'method', 'source': '..\\src\\Application\\Books\\Commands\\CreateBook\\CreateBookHandler.cs'}, page_content='{\n            var book = new Book(request.Title, request.Author, request.ISBN);\n            await _repo.AddAsync(book);\n        }')
* Use Case:
	+ CreateBook: Membuat buku baru dengan atribut yang lengkap
	+ UpdateBook: Mengupdate informasi buku yang sudah ada

Dengan menggunakan Clean Architecture, aplikasi BOOK Library dapat dibangun dengan struktur yang jelas dan mudah dipahami. Domain Layer mengelola entitas dan nilai objek, Application Layer mengelola use case, dan Infrastructure Layer mengelola repository dan database.
