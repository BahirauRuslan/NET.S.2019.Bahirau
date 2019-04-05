# Day 8
### EPAM-Training-ASP.NET-MVC

#### Tasks:

1. Create a Book class (**ISBN, author, title, publisher, year of publication,
number of pages, price**), overriding for it the necessary methods of
Object class. For class objects, implement **equivalence and order relations.
(using appropriate interfaces)**. To perform basic operations with
a list of books that **can** be loaded and, **if necessary**,
save to some BookListStorage storage; create BookListService class
(as a service for working with a **collection** of books) with AddBook functionality (add
a book, if there is no such book, otherwise throw an exception); RemoveBook
(delete the book, if it exists, otherwise throw an exception);
FindBookByTag (find a book by a given criterion); SortBooksByTag (sort
list of books by a given criterion). Do not use delegates!
Demonstrate the work of classes on the example of a console application.
To use as storage a binary file, to work with which to use only the classes **BinaryReader,
BinaryWriter. Storage can be changed / added later**

2. Develop a type system for describing work with a bank account. condition
account name
with additional bonuses that increase / decrease
every time you refill
replenishment and lists and calculated depending on some values
the value of "cost" balance and "cost" of replenishment. The value of "cost"
balance and "cost"
For example, Base, Gold, Platinum.
To work with the account to realize the following features:
	- make a deposit to the account;
	- execute lists from the account;
	- create a new account;
	- close an account.
Information about the accounts is stored in a binary file.
The work of the classes is demonstrated by the example of a console application.
The following expansion / change features
functionality
	- adding new types of accounts;
	- change / add account information storage sources;
	- change the logic of calculating bonus points.


Ruslan Bahirau  
ruslan.bahirau.1999@gmail.com