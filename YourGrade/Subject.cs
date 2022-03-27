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
        public string Date { get => date; s