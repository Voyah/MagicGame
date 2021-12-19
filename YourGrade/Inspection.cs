
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YourGrade
{
    public class Inspection
    {
        public static bool IsRefinementClass(string word)
        {
            foreach (string element in Subject.REFINEMENT_CLASS)
            {
                if (word == element) return true;
            }
            return false;
        }

        public static bool IsMajorClass(string word)
        {
            foreach (string element in Subject.MAJOR_CLASS)
            {
                if (word == element) return true;
            }
            return false;
        }

        public static bool IsSubjectCode(string word)
        {
            string pattern = "\\d{8}";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsScoreOrTotalUnivPoint(string word)
        {
            string pattern = "^[0-9]*[.]{0,1}][0-9]*$";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsPOfPFSubject(string word)
        {
            if (word == "P")
                return true;
            return false;
        }

        public static bool IsFOfPFSubject(string word)
        {
            if (word == "F")
                return true;
            return false;
        }

        public static bool IsUnivPoint(string word)
        {
            string pattern = "\\d{1}";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsSeparatedGrade(string word)
        {
            string pattern = "^[A-D]$";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsGrade(string word)
        {
            string pattern = "^[A-D][+|-|0]$";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsDate(string word)
        {
            string pattern = "\\d{4}[?][1|2|여름|겨울]";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsRetaked(string word)
        {
            string pattern = "^Ex2+";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsFGrade(string word)
        {
            string pattern = "^Ex3+";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsDuplicated(string word)
        {
            string pattern = "^Ex5+";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsAbandoned(string word)
        {
            string pattern = "^Ex6+";
            return Regex.IsMatch(word, pattern);
        }

        public static bool IsRetakedSubjectCode(string word, List<Subject> list)
        {
            foreach(Subject sub in list)
            {
                if (word == sub.Code)
                    return true;
            }
            return false;
        }
    }
}