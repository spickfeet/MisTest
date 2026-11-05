using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Faults
{
    public static class DiagnosisFaults
    {
        public static Fault TherapyEmpty()
        {
            return new("Diagnosis.TherapyEmpty",
                [new("Лечение не указано")]);
        }

        public static Fault TherapyTooLong(int maxLength)
        {
            return new("Diagnosis.TherapyTooLong",
                [new($"Длина лечения не должна превышать {maxLength} символов")]);
        }

        public static Fault CommentTooLong(int maxLength)
        {
            return new("Diagnosis.CommentTooLong",
                [new($"Длина комментария не должна превышать {maxLength} символов")]);
        }

        public static Fault CommentEmpty()
        {
            return new("Diagnosis.CommentEmpty",
                [new("Комментарий обязателен для заполнения")]);
        }
        
        public static Fault DateEmpty()
        {
            return new("Diagnosis.DateEmpty",
                [new("Дата диагноза обязательна для заполнения")]);
        }

        public static Fault DateInFuture(DateTime date)
        {
            return new("Diagnosis.DateInFuture",
                [new($"Дата диагноза ({date:dd.MM.yyyy}) не может быть в будущем")]);
        }
    }
}
