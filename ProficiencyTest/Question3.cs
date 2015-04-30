using System;
using System.Collections;
using System.Collections.Generic;


namespace ProficiencyTest
{
	public class Run
	{

		public static int IndexOfLongestRun(string str)
		{
			//count is to store  max nof occuenrences of a repeated letter 
			int count=1;
			//Take an example of aaaaaabbcccddddccccbba
			//Dictionary defined for max nof occuenrences of a repeated letter and it's last index position
			Dictionary<int, int> dictionary =
				new Dictionary<int, int>();
			//for will itarate all charectores of string
			for (int i=0;i+1<str.Length;i++) {
				//check for current iterate char and next char in string are same
				if(str[i]==str[ i+1])
				{
					//if both chars are same, increment count with 1
					count=count+1;
				}
				else
				{
					//both chars are not same
					//if is for checking dictionary, whether it contains already key
					//count and current index is added to dictionary
					if(!dictionary.ContainsKey(count))
					dictionary.Add(count,i);
					//recetting the count
					count =1;
				}

			}
			//maxCount is for storing max number in dictionary
			//max is setted as 0
			int maxCount = 0;
			foreach (KeyValuePair<int,int> keyValue in dictionary) {
				//checking previous number with current number
				//if current number is heigher than previous number
				if (maxCount < keyValue.Key) {
					//storing current number in previous number
					maxCount = keyValue.Key;
				}
			}
			//maxCount will be 6 (aaaaaa) 
			// dictionary [maxCount] will give 5 bcz 5 is last index of  aaaaaa
			//(maxCount-1) will give 6-1 is 5
			//dictionary [maxCount] - (maxCount-1) so 5-5 is 0 is IndexOfLongestRun of aaaaaabbcccddddccccbba
			return dictionary [maxCount] - (maxCount-1);

		}

	}}

