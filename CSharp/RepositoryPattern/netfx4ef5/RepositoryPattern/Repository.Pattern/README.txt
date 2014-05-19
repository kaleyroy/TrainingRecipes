This project based on 
"Generic Unit of Work & (Extensible) Repositories Framework"
https://genericunitofworkandrepositories.codeplex.com (v3.3)

Due to the original project depended on Entity Framework 6 + Net Framework 4.5,
But my solution based on EntityFramework 5 + Net Framework 4,so i made some changes for this project.

The Change Items:

1. Delete ODataApi intefaces (we don't need this feature).
2. Delete *Async interfaces (netfx4 not support async programming).
3. Delete Repository->*Graph interfaces (ef5 not support DbSet.AddRange()).
4. Add UpdateRange,DeleteRange interfaces.
