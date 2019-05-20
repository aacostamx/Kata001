# Kata 001

## Summary
Covers the "S" in SOLID, Not Invented Here (NIH), Date time modeling issues, and pure functions

## Discussion
- What does "S" in "SOLID" stand for (hint: it is not "do one thing only")? How would this lead to a design change?
A class should have only a single responsibility, that is, only changes to one part of the software's specification should be able to affect the specification of the class. It would lead into a new desing because the logic is inside the program class

- One class in the example is one of the most misused in the .net framework, which do you think it is? What is the story in .net core?
HttpClient error is the most misused
DateTime.Now is a very problematic way of retrieving the current date and time, and you should—almost—never use it.
https://blog.submain.com/datetime-now-usage-examples/

- "Not Invented Here" is a common problem found in code. What are some examples in the sample? 
The mapping, datetime parsing, the http client, the read/write file and the dependency injection
https://exceptionnotfound.net/not-invented-here-the-daily-software-anti-pattern/

- Timing is crucial and timestamps can have different intents. Discuss various date/time uses.
Timestamps represents a length of time. Represents an instant in time, typically expressed as a date and time of day. Typically we used date/times for saving time or log critical information

- What are "pure" functions and how to they relate to testable code? How do they relate to the question above?
Pure funtions are funtions that the return value is the same for the same arguments. The parameter and the response most be the same.

## Thought Exercise
Imagine a function, AssignWorkDate, that takes an item and assigns a work date:
 - If the next day is a week day, that day is selected
 - If the next day is a weekend, then the next Monday is selected.
 - Holidays are ignored

 A naive implementation would use DateTime.Now/UtcNow in the method. Describe issues with testing such an implementation?
DateTime object can fall into one of three different categories: UTC, Unspecified and Local and it will be hard to testing

 A naive refactor would simply elevate the date to a parameter. Has this resolved the issue or just moved it to a different layer in the stack?
 Same issue, we just moved it to a differente layer 

 A more robust refactor would inject the implementation. Describe how you would implement an IClock to make the business logic testable.
 I will create a IClock interface and Clock class and it will allows us the creation of dependent objects outside of a class and provides those objects to a class through different ways.

 ## Code Exercise
 Refactor the code, keeping in mind the "S" in SOLID, NIH, IClock, and pure functions. The current format is difficult to test. Adding unit tests can lead you to a more testable format.