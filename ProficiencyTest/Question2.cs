using System;
using System.Text.RegularExpressions;

namespace ProficiencyTest
{
	public class Path
	{
		public string CurrentPath { get; private set; }
		public Path(string path)
		{
			this.CurrentPath = path;
		}
		//Reg expression for it should contains a-z, A-Z and /(slash)
		private static bool isValid(String str)
		{
			return Regex.IsMatch(str, @"^[a-zA-Z/]+$");
		}
		public Path Cd(string newPath)
		{
			//check for string contains  a-z, A-Z and /(slash) , ../ or ./
			if (isValid (CurrentPath) && (newPath.Contains ("../") || newPath.Contains ("./"))) {
				//take example /a/b/c/d
				//splitting filepath using /(slace)
				// will get in array "", a, b, c, d
				string[] directories = CurrentPath.Split ('/');
				//take example ../../../x
				//splitting newpath using /(slace)
				//will get in array .., .., .., x
				string[] newPaths = newPath.Split ('/');
				//will get how many occurences of ../ or ./ 
				int count = CountStringOccurrences (newPath, "../");
				if (count == 0) {
					count = CountStringOccurrences (newPath, "./");
				}
				//forming new changed directory using 	
				string strPath = "";
				for (int i = 0; i < directories.Length - count; i++) {
					strPath = strPath + "/" + directories [i];
				}
				//removing extra slace in starting position
				strPath = strPath.TrimStart ('/');
				//concatinating strpath and newdirectiory
				strPath = strPath + "/" + newPaths [newPaths.Length - 1];
				CurrentPath = strPath;
			} else {
				Console.WriteLine("Path and newpath are not valid");
			}
				return this;
			
				
		}
		public static int CountStringOccurrences(string text, string pattern)
		{
			// Loop through all instances of the string 'text'.
			int count = 0;
			//is is starting index
			int i = 0;
			while ((i = text.IndexOf(pattern, i)) != -1)
			{
				//starting index is added with pattern.Length for searching pattern in next position
				i += pattern.Length;
				//if pattren is matchedd in text incrementing count with 1
				count++;
			}
			return count;
		}
	}
}

