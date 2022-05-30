
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourGrade
{
    public class User
    {
        private float majorGrade;
        private float majorScore;
        private float majorPoint;
        private float totalGrade;
        private float totalScore;
        private float totalPoint;

        public User()
        {
            this.majorGrade = 0;
            this.majorScore = 0;
            this.MajorPoint = 0;
            this.totalGrade = 0;
            this.totalScore = 0;
            this.TotalPoint = 0;
        }

        public float MajorGrade { get => majorGrade; set => majorGrade = value; }
        public float MajorScore { get => majorScore; set => majorScore = value; }
        public float TotalGrade { get => totalGrade; set => totalGrade = value; }
        public float TotalScore { get => totalScore; set => totalScore = value; }
        public float MajorPoint { get => majorPoint; set => majorPoint = value; }
        public float TotalPoint { get => totalPoint; set => totalPoint = value; }

        public void Calculate(List<Subject> list)
        {
            float majorDivider = 0, totalDivider = 0;
            foreach (Subject sub in list)
            {
                if (Inspection.IsMajorClass(sub.Classification))
                {
                    if (sub.Grade == Subject.IGNORE)
                    {
                        MajorPoint += float.Parse(sub.UnivPoint);
                    }
                    else if (sub.Grade != null)
                    {
                        majorGrade += float.Parse(sub.Grade) * float.Parse(sub.UnivPoint);
                        majorScore += float.Parse(sub.Score) * float.Parse(sub.UnivPoint);
                        MajorPoint += float.Parse(sub.UnivPoint);
                        majorDivider += float.Parse(sub.UnivPoint);
                    }

                }

                if (sub.Grade == Subject.IGNORE)
                {
                    TotalPoint += float.Parse(sub.UnivPoint);
                }
                else if (sub.Grade != null)
                {
                    totalGrade += float.Parse(sub.Grade) * float.Parse(sub.UnivPoint);
                    totalScore += float.Parse(sub.Score) * float.Parse(sub.UnivPoint);
                    TotalPoint += float.Parse(sub.UnivPoint);
                    totalDivider += float.Parse(sub.UnivPoint);
                }
            }

            if (majorDivider != 0)
            {
                majorGrade /= majorDivider;
                majorScore /= majorDivider;