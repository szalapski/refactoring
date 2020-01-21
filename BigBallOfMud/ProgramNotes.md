

#Within a class refactorings
- Motives
    - Easier to read, harder to misread
    - Easier to enhance
    - Easier to find further opportunities for further or broader refactoring

- AccountController.cs 
    - R# warnings
        - Remove unused usings
        - Remove redundant names   
            - Write code in a way that is simpler for those who know the language, not for those who don't.
    - Commit refactorings often
    - R# suggestions
        - Use expression-bodied methods/properties
            - try to build; be willing to upgrade to latest 
        - Restrict members/references to get-only, readonly, private, internal, or const whereever possible
        - Simplify conditionals with logic and underused operators: ?.  ??  ?:     
        - Eliminate redundant special cases
    - if-else

Things to mention
- Refactoring is not about less typing


Optional
- 