# Kata 001

## Summary
Covers the "S" in SOLID, Not Invented Here (NIH), Date time modeling issues, and pure functions

## Discussion
- What does "S" in "SOLID" stand for (hint: it is not "do one thing only")? How would this lead to a design change?
- One class in the example is one of the most misused in the .net framework, which do you think it is? What is the story in .net core?
- "Not Invented Here" is a common problem found in code. What are some examples in the sample? 
- Timing is crucial and timestamps can have different intents. Discuss various date/time uses.
- What are "pure" functions and how to they relate to testable code? How do they relate to the question above?

## Thought Exercise
Imagine a function, AssignWorkDate, that takes an item and assigns a work date:
 - If the next day is a week day, that day is selected
 - If the next day is a weekend, then the next Monday is selected.
 - Holidays are ignored

 A naive implementation would use DateTime.Now/UtcNow in the method. Describe issues with testing such an implementation?

 A naive refactor would simply elevate the date to a parameter. Has this resolved the issue or just moved it to a different layer in the stack?

 A more robust refactor would inject the implementation. Describe how you would implement an IClock to make the business logic testable.

 ## Code Exercise
 Refactor the code, keeping in mind the "S" in SOLID, NIH, IClock, and pure functions. The current format is difficult to test. Adding unit tests can lead you to a more testable format.