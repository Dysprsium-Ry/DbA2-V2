﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace BienvenidoOnlineTutorServices.D2.Objects
{
    public class ObjectModels
    {
        public class BindingSources
        {
            public static BindingSource QueueItems = new BindingSource();
        }

        public class DataId
        {
            public static long StudentId { get; set; }
            public static long TutorId { get; set; }
            public static long SubjectId { get; set; }
        }
        public class Enrollment 
        {
            public static long TransactionId { get; set; }
            public static string StudentName { get; set; }
            public static string StudentEmail { get; set; }
            public static string TutorName { get; set; }
            public static string Subject { get; set; }
            public static DateTime SessionScheduleDate { get; set; }
            public static TimeSpan StartSchedule { get; set; }
            public static TimeSpan EndSchedule { get; set; }
            public static decimal HourlyRate { get; set; }
            public static decimal TotalFee { get; set; }
            public static string TransactionState { get; set; }
        }
        public class PreferredSubject
        {
            public long TransactionId { get; set; }
            public string StudentName { get; set; }
            public long StudentId { get; set; }
            public string TutorName { get; set; }
            public long TutorId { get; set; }
            public string Subject { get; set; }
            public long SubjectId { get; set; }
            public DateTime SessionScheduleDate { get; set; }
            public TimeSpan SessionScheduleTime { get; set; }
            public int SessionDuration { get; set; }
            public DateTime SessionEndSchedule { get; set; }
            public decimal HourlyRate { get; set; }
            public decimal TotalFee { get; set; }
            public decimal PaymentFee { get; set; }
            public decimal RemainingFee { get; set; }
            public string PaymentStatus { get; set; }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                PreferredSubject other = (PreferredSubject)obj;

                return Subject == other.Subject && SessionScheduleDate == other.SessionScheduleDate;
                //&& BookedDate == other.BookedDate; && RentedDuration == other.RentedDuration && HourlyRate == other.HourlyRate && TotalFee == other.TotalFee;
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + (Subject?.GetHashCode() ?? 0);
                    hash = hash * 23 + SessionScheduleDate.GetHashCode();
                    return hash;
                }
            }
        }
        public class TemporalData
        {
            public static List<PreferredSubject> SubjectList = new List<PreferredSubject>();
            public static long TransactionId { get; set; }
            public static string StudentName { get; set; }
            public static long StudentId { get; set; }
            public static string StudentEmail { get; set; }
            public static string TutorName { get; set; }
            public static long TutorId { get; set; }
            public static string TutorEmail { get; set; }
            public static string Subject { get; set; }
            public static long SubjectId { get; set; }
            public static DateTime SessionScheduleDate { get; set; }
            public static TimeSpan SessionScheduleTime { get; set; }
            public static int SessionDuration { get; set; }
            public static DateTime SessionEndSchedule { get; set; }
            public static decimal HourlyRate { get; set; }
            public static decimal TotalFee { get; set; }
            public static decimal OverallTotalFee { get; set; }
            public static decimal PaymentFee { get; set; }
            public static decimal RemainingFee { get; set; }
            public static string PaymentStatus { get; set; }
            public static TimeSpan InTime { get; set; }
            public static TimeSpan OutTime { get; set; }
        }
        public class TransacObj
        {
            public static long TransacId { get; set; }
            public static decimal PayFee { get; set; }
            public static decimal TotalFee { get; set; }
            public static decimal RemainingFee { get; set; }
            public static string Student { get; set; }
            public static string Subject { get; set; }
            public static string Tutor { get; set; }
        }
        public class BillingObj
        {
            public static long TransactionId { get; set; }
            public static long EnrollmentId { get; set; }
            public static long SubjectId { get; set; }
            public static decimal Pay { get; set; }
            public static decimal PayFee { get; set; }
            public static decimal RemainingBalance { get; set; }
            public static decimal TotalFee { get; set; }
            public static String Tutor { get; set; }
            public static String Subject { get; set; }
            public static String Student { get; set; } 
            public static DateTime SessionSchedule { get; set; }
        }

        public class ReceiptObject
        {
            public long TransactionId { get; set; }
            public string Student { get; set; }
            public string Subject { get; set; }
            public string Tutor { get; set; }
            public decimal TotalFee { get; set; }
            public decimal TotalAmountFee { get; set; }
            public decimal PaidAmount { get; set; }
            public DateTime ScheduledDate { get; set; }
        }

        public class TutorDetails
        {
            public string TutorName { get; set; }
            public string Expertise { get; set; }
            public decimal HourlyRate { get; set; }
            public TimeSpan InTime { get; set; }
            public TimeSpan OutTime { get; set; }
        }

        public class ReceiptStaticClass
        {
            public static List<ReceiptObject> ReceiptList = new List<ReceiptObject>();
            public static long TransactionId { get; set; }
            public static string StudentName { get; set; }
            public static string Subject { get; set; }
            public static string TutorName { get; set; }
            public static SqlMoney TotalAmountFee { get; set; }
            public static SqlMoney PaidAmount { get; set; }
        }

        public class QueuedItems
        {
            public long TransactionId { get; set; }
            public string QueuedSubject { get; set; }
            public string QueuedTutor { get; set; }
            public decimal QueuedHourlyRate { get; set; }
            public DateTime QueuedSessionSchedule { get; set; }
            public TimeSpan QueuedStartTime { get; set; }
            public TimeSpan QueuedEndTime { get; set; }
        }

        public class QueuedItemList
        {
            public static List<QueuedItems> QueuedItemsList = new List<QueuedItems>();
            public static long TransactionId { get; set; }
            public static string QueuedSubject { get; set; }
            public static string QueuedTutor { get; set; }
            public static decimal QueuedHourlyRate { get; set; }
            public static string QueuedTimeSchedule { get; set; }
            public static DateTime QueuedSessionSchedule { get; set; }
        }

        #region editModels

        public class EditItemList
        {
            public long TransactionId { get; set; }
            public string Subject { get; set; }
            public string Tutor { get; set; }
            public decimal EditHourlyRate { get; set; }
            public TimeSpan EditStartTime { get; set; }
            public TimeSpan EditEndTime { get; set; }
            public DateTime EditScheduleDate { get; set; }
        }

        public class EditItemListCollection
        {
            public static List<EditItemList> EditItemsList = new List<EditItemList>();
            public static string EditSubject { get; set; }
            public static string EditTutor { get; set; }
            public static decimal EditHourlyRate { get; set; }
            public static TimeSpan EditStartTime { get; set; }
            public static TimeSpan EditEndTime{ get; set; }
            public static DateTime EditScheduleDate { get; set; }
        }

        #endregion
    }
}
