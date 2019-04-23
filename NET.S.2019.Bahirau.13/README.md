# Day 13
### EPAM-Training-ASP.NET-MVC

#### Tasks:

1. Add a generic Queue collection class that implements the basic operations for working with the queue, 
and provides the ability to iterate by implementing an iterator “**manually**” (without using the yield iterator). 
Test the methods of the added class.

2. Create generic classes for representing square, symmetric and diagonal matrices 
(a symmetric matrix is ​​a square matrix that coincides with the transposed matrix; 
a diagonal matrix is ​​a square matrix whose elements outside the main diagonal obviously have default values ​​
of the element type). Describe in the created classes an event that occurs when the matrix element with indices (i, j) 
changes. Extend the functionality of the existing class hierarchy by adding the ability to add two matrices of any type. 
Add unit tests.

3. Create a generic collection class BinarySearchTree (binary search tree). 
Provide for the use of a pluggable interface to implement an order relationship. 
Implement three tree traversal methods: direct (preorder), transverse (inorder), and reverse (postorder): 
use an iterator (yield) to implement. Test the developed class using the following types:
+ System.Int32 (use default comparison and plug-in comparator);
+ System.String (use default comparison and plug-in comparator);
+ Custom Book class, for objects of which order relations are implemented (use default comparison and plug-in comparator);
+ Custom Point structure, for objects of which the order relation is not implemented (use a plug-in comparator).  


Ruslan Bahirau  
ruslan.bahirau.1999@gmail.com