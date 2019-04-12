# Day 10
### EPAM-Training-ASP.NET-MVC

#### Tasks:

1. For objects of the Book class (**ISBN, author, title, publisher, 
year of publication, number of pages, price**) (8th day homework) 
to implement the possibility of a string representation of a different type. 
For example, for an object with **ISBN = 978-0-7356-6745-7, AuthorName = Jeffrey Richter, 
Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOPpages = 826, 
Price = 59.99$**, the following can be options:
- Jeffrey Richter, CLR via C#
- Jeffrey Richter, CLR via C#, Microsoft Press, 2012
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826.
- Jeffrey Richter, CLR via C #, Microsoft Press, 2012
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, P. 826., 59.99$.  
**etc.**

2. Without changing the Book class, 
add an additional formatting feature for the objects of this class 
that was not originally provided for by the class.

3. For implemented in p. 1, 2 functionalities add unit tests.

4. Perform class refactoring (to reduce repetitive code) in Euclidean algorithms 
(delegates can be used for refactoring, refactoring is possible only when all methods are in the same class!). 
The class interface should not change.

5. In a class with sorting algorithm of a jagged array that accepts the IComparer<int[]> 
interface as a comparator, add a method that takes a comparator delegate as an argument, 
encapsulating the jagged array row matching logic. To test the work of the developed method on the example of 
jagged array sorting, using the previous comparison criteria. 
To implement a class in two ways, “closing” in the first variant the implementation of the sorting method with 
a delegate to a method with an interface, in the second - vice versa.


Ruslan Bahirau  
ruslan.bahirau.1999@gmail.com