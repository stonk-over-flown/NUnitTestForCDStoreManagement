using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NUnitTestForCDStoreManagement.Model
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Duration { get; set; }
    }
    public class SongService
    {
        public static string checkRegex(string s)
        {
            var regex = @"^[0-5][0-9]:[0-5][0-9]$";
            var format = new Regex(regex);
            if (!format.IsMatch(s))
            {
                return s + " isn't valid";
            }
            return s + " is valid";
        }

    }
}
