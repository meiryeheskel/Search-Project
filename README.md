# Search-Project
### A program that searches files on the computer and saves the results in sql database

 * The program uses an open database to store the required variables.
 * The relational Database was built through the query file "search.sql" which is included.
 * For simplicity - when no search folder is selected - the "c:\\" folder will be the default.
 * Although an error catching system was introduced, a try & catch syntax was added 
 for reasons of "UnauthorizedAccessException" errors from the BLL section.
 * The program takes advantage of the `Directory.EnumerateFiles` command that:
    1. searches with case insensitive
    2. works asyncronously 
    3. searches all subdirectories (given the search option: `SearchOption.AllDirectories`
