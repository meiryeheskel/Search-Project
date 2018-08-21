using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;



namespace BLL
{
    public class SearchManager
    {
        public static event Action<string> SearchHandler;

        public static void StartSearching(SearchModel CurrentSearch)
        {
            CurrentSearch.SearchID = DbManager.ExecDb($"insert into dbo.SearchData(SearchString,SearchFolder) values ('{CurrentSearch.SearchString}','{CurrentSearch.SearchFolder}')");
            IEnumerable<string> Files;
            // Directory.EnumerateFiles will search asynchronously (with case insensitive) for all files that contain the 
            // specified user input string in the current folder and subfolders given the specified option. 
            Files = Directory.EnumerateFiles(CurrentSearch.SearchFolder, "*" + CurrentSearch.SearchString + "*", SearchOption.AllDirectories);

            foreach (string currentFile in Files)
            {
                SearchHandler?.Invoke(currentFile);  // raise an event
                DbManager.ExecDb($"insert into dbo.SearchResults(ResultPath,SearchID) values ('{currentFile}','{CurrentSearch.SearchID}')");
            }
        }
    }
}
