# Practical refactoring in C#

##Brainstorm
- SOLID principles
- Refactoring as suggested by Resharper
- Turn off resharper
- Goals of refactoring (and non-goals of refactoring)
- refactoring within a method, within a class, rearchitecturing
- books
- open it up for suggestions
- refactoring without unit tests
- refactoring with unit tests
- demysitify jargon

##Refactorings
- renaming
- introduce local variable
- eliminate nesting
  - eliminate loops
  - combine singly-nested IFs
  - invert if
  - early return
- ternary assignment
- extract methods
- loop of method references
- Make Start-Stop into an IDisposable block
- Redesign and mark obsolete 
- Add dependency injection in six small steps
  - make instance from local
  - extract interface
  - make tightly-coupled implementation
  - bastardize constructor
  - configure DI
  - remove bastard constructor
