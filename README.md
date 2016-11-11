# Game

* We are looking for well designed, testable and maintainable code.	
  * I have structured the code in a workflow/task/dataflow manner, I have followed many OO principles here.
  * The code will become more maintainable as its extended in this structure, as you will see i have added the beginnings of a WebApi library.
  * Threading is kept well under control in this structure.

* Use as little memory as possible and make it run as fast as possible.
  * [Premature optimization is the root of all evil in programming. C.A.R. Hoare](http://www.comp.nus.edu.sg/~damithch/pages/SE-quotes.htm?type=bestQuotes)
* In your comments, discuss the runtime order complexity of your solution e.g., O(n) or O(n^2), etc.
  * O(count of children)
* Comment on resiliency.
 * I implemented a uniform exception handling strategy.
* Explain any assumptions or trade-offs you have made.
 * The requirement of moving to the next child after one has been removed is not clear, would have clarified ths requiremnt first in practice. Should we remove the one to the right or the left. I moved right in each case because we are working clockwise.