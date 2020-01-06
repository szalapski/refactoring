# Practical refactoring in C#

What a horrible mess this class is! Look at this--it has hard-wired static function calls, it’s newing up and hanging on to some IDisposables indefinitely, and it is just way too big. I dunno, maybe it needs a ServiceLocator?  Whatever, I’m not messing with this. I’ll just new up another dependency and make it work for this new feature it needs. But boy, does this smell icky…You know, I could just take a bit more time and change this all around…really, the right way to do this isn’t as radical as one might think…it really just takes a bit of constructor injection, application of the SOLID principles, and some iterative thinking. I’ll start with this one change, compile—it works!!—and check in. Then I’ll change it again and again--no big bangs here, and each time it is in a better state than before. When I’m done, I’ll write at least one unit test just to prove that it can be done—but really, I’ll be so happy with my class that it will be so easy to write dozens and gain lots of confidence in my code!

I’ll show you the way to incrementally fix up your code so that when you take it off the blocks, all will work well, quality goes up, and much goodness results.

Patrick Szalapski makes software and helps others make software at the same Fortune 500 company as Elsa Vezino.  When not refactoring code from twelve years ago, he enjoys the outdoors in Minnesota year round, loves deeper thinking and discussion, talking way too long about the Minnesota Twins, and most of all being a dad and husband.

## Brainstorm
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

## Refactorings
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
