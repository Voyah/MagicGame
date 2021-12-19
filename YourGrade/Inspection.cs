
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