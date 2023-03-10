
﻿using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YourGrade
{
    public class PDFReader
    {
        private List<Subject> subjects = new List<Subject>();

        public void SetDataFromPDF(User user, string path)
        {
            string parseResult = ParseUsingPDFBox(path);
            string[] lines, words;
            string curClassification = null;

            lines = Regex.Split(parseResult, "\r\n");
            for (int lNum = 0; lNum < lines.Length; lNum++)
            {
                words = lines[lNum].Split(' ');
                if (Inspection.IsRefinementClass(words[0]) || Inspection.IsMajorClass(words[0]))
                {
                    curClassification = words[0];
                    subjects.Add(GetSubjectsFromPDF(curClassification, words));
                }
                else if (Inspection.IsSubjectCode(words[0]))
                {
                    subjects.Add(GetSubjectsFromPDF(curClassification, words));
                }
            }

            user.Calculate(subjects);
        }

        private string ParseUsingPDFBox(string path)
        {
            PDDocument doc = null;

            try
            {
                doc = PDDocument.load(path);
                PDFTextStripper stripper = new PDFTextStripper();
                return stripper.getText(doc);
            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }
        }

        private Subject GetSubjectsFromPDF(string classification, string[] words)
        {
            Subject sub = new Subject();

            int dateIdx;
            for (dateIdx = 0; dateIdx < words.Length; dateIdx++)
                if (Inspection.IsDate(words[dateIdx])) break;

            if (Inspection.IsSubjectCode(words[0]))
                sub.Code = words[0];
            else if (Inspection.IsSubjectCode(words[1]))
                sub.Code = words[1];

            sub.Classification = classification;
            sub.UnivPoint = words[dateIdx + 1];

            if (words.Length == dateIdx + 2)
            {
                // 수강하지 않은 과목
                sub.Code = null;
            }
            else if (Inspection.IsRetaked(words[dateIdx - 1]) ||
                Inspection.IsDuplicated(words[dateIdx - 1]) ||
                Inspection.IsAbandoned(words[dateIdx - 1]))
            {
                // 재수강 과목 || 중복 수강 || 학점 포기
            }
            else if (Inspection.IsFGrade(words[dateIdx - 1]))
            {
                if (Inspection.IsRetakedSubjectCode(sub.Code, subjects))
                {
                    //  Exception :: 재수강 했는데 Ex3인 경우
                }
                else if (words.Length == dateIdx + 3)
                {
                    // P/F과목 FAIL의 경우
                    sub.Grade = "IGNORE";
                }
                else
                {
                    sub.Grade = words[dateIdx + 2];
                    sub.Score = words[dateIdx + 3];
                }
            }
            else if (Inspection.IsPOfPFSubject(words[dateIdx + 2]))
            {
                sub.Grade = words[dateIdx + 2][0].ToString();
            }
            else if (Inspection.IsFOfPFSubject(words[dateIdx + 2]))
            {
                // Exception :: F학점임에도 불구하고 과목정보가 Ex3 아닌 경우 포함
            }
            else if (Inspection.IsSeparatedGrade(words[dateIdx + 2]))
            {
                string grade = words[dateIdx + 2];
                grade += words[dateIdx + 3];
                sub.Grade = grade;
                sub.Score = words[dateIdx + 4];
            }
            else if (dateIdx + 3 != words.Length)
            {
                sub.Grade = words[dateIdx + 2];
                sub.Score = words[dateIdx + 3];
            }

            return sub;
        }

    }
}