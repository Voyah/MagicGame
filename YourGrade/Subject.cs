using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourGrade
{
    public class Subject
    {
        public static readonly string[] REFINEMENT_CLASS = { "교양필수", "교양선택", "일반선택" };
        public static readonly string[] MAJOR_CLASS = { "전공기초", "전공필수", "전공선택", "융합선택", "융합필수", "복수전공" };
        public static readonly string IGNORE = "1001";

        private string classification;
        private string code;
        private string name;
        private string category;
        private string date;
        private string univPoint;
        private string grade;
        private string score;

        public string Classification { get => classification; set => classification = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Date { get => date; set => date = value; }
        public string UnivPoint { get => univPoint; set => univPoint = value; }
        public string Grade { get => grade; set => grade = GetGradeFromString(value); }
        public string Score { get => score; set => score = removeCR(value); }

        private string GetGradeFromString(string value)
        {
            float result = 0;
            switch (value[0])
            {
                case 'A':
                    result += 4;
                    break;
                case 'B':
                    result += 3;
                    break;
                case 'C':
                    result += 2;
                    break;
                case 'D':
                    result += 1;
                    break;
                case 'F':
                    return "0";
                default:
                    return IGNORE;
            }

            switch (value[1])
            {
                case '+':
                    result += (float)0.5;
                    break;
                case '0':
                    result += (float)0.3;
                    break;
                case '-':
                    result += 0;
                    break;
            }

            return result.ToString();
        }

        private string removeCR(string word)
        {
            if (word.IndexOf('\\') > 0)
                return word.Substring(0, word.IndexOf('\\') - 1);
            return word;
        }
    }
}
