

- Show books Feathers and Martin
- Editing someone else's code?
- Opinion and taste

#Within a class refactorings
- Motives
    - Easier to read, harder to misread
    - Easier to enhance
    - Easier to find further opportunities for further or broader refactoring


- Not covering 
    - Rename 
    - Move

- AccountController.cs 
    - R# warnings
        - Remove unused usings
        - Remove redundant names   
            - Write code in a way that is simpler for those who know the language, not for those who don't.
    - Commit refactorings often
    - R suggestions
        - Use expression-bodied methods/properties
            - try to build; be willing to upgrade to latest 
        - Restrict members/references to get-only, readonly, private, internal, or const whereever possible
        - Simplify conditionals with logic and underused operators: ?.  ??  ?:     
        - Eliminate redundant special cases
    - turn off R#
    - Invert If in GetErrorResult
    - Make simple blocks one line in GetErrorResult
    - combine boolean logic in FromIdentity
    - RegisterExternal - convert return to conditional expression using ternary (implicitly convertible)
    - GetExternalLogins - string 
    - Extract a method in GetExternalLogins

# Making a class testable


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




Optional
- 