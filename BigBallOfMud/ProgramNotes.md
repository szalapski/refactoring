- setup
	- load deck
	- get books ready
	- load AsyncAwaitPain in run-x branch
	- load BigBallOfMud 
    - zoom to start magnifier
	
- Not covering 
    - Rename 
    - Move

- AccountController.cs 
    - R# warnings
        - Remove unused usings
        - Remove redundant names   
            - Write code in a way that is simpler for those who know the language, not for those who don't.
    - Commit refactorings often
    - R# suggestions
        - Use expression-bodied methods/properties
            - try to build; be willing to upgrade to latest 
        - Restrict members/references to get-only, readonly, private, internal, static, or const whereever possible
        - Simplify conditionals with logic and underused operators: ?.  ??  ?:     
        - Eliminate redundant special cases
    - turn off R#
	- if-else in GetExternalLogins
    - Invert If in GetErrorResult
    - Make simple blocks one line in GetErrorResult
    - combine boolean logic in FromIdentity
    - RegisterExternal - convert return to conditional expression using ternary (implicitly convertible)
    - GetExternalLogins - string 
    - Extract a method in GetExternalLogins

  - seven-step DI refactoring in BigBallOfMud
  1. (static only) Sequester the untestable/uninjectable code into a tightly-coupled implementation
	a. extract instance method
	b. extract instance class from that method
	c. use the new class and method with "new"
  2. make local refereance for the "new" object only
  3. move local to instance and switch to abstract type (i.e. interface)
  4. bastardize constructor
  5. configure DI
  7. remove bastard constructor
  N. clean up code (always)

  - Kill loops with Linq - GetManageInfo;  GetExternalLogins
    

Things to mention
- Refactoring is not about less typing
- Keyboard shortcuts to learn
  - Ctrl+arrows, ctrl+backspace
  - Ctrl+.
  - Ctrl+R R to rename

#Links
  - https://sourcemaking.com/refactoring/refactorings
  - https://www.jetbrains.com/help/resharper/Main_Set_of_Refactorings.html
  - https://www.thekua.com/publications/RefactoringCheatSheet.pdf