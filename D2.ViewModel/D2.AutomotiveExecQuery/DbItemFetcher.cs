﻿using _3_13_25.D2.DataModels;
using _3_13_25.D2.QueryStorage;
using BOTS.Database_Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static BienvenidoOnlineTutorServices.D2.Objects.ObjectModels;

namespace _3_13_25.D2.ViewModel.D2.AutomotiveExecQuery
{
    public class DbItemFetcher
    {
        public static long TransactionIdFetcher()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                if (!string.IsNullOrEmpty(TemporalData.StudentName))
                {
                    using (SqlCommand command = new SqlCommand(Queries.TransactionIdExisting, connection))
                    {
                        command.Parameters.AddWithValue("@Student", TemporalData.StudentName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Convert.ToInt64(reader.GetInt64(0));
                            }
                            else return 1;
                        }
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(Queries.TransactionIdNew, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Convert.ToInt64(reader.GetInt64(0)) + 1;
                            }
                            else return 0;
                        }
                    }
                }
            }
        }


        public static string StudentEmailFetcher(string StudUsername)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.StudentEmail, connection))
                {
                    command.Parameters.AddWithValue("@StudUsername", StudUsername);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string email = reader.GetString(0);
                        return email;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static string[] Subjects()
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.Subjects, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> subjects = new List<string>();
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                subjects.Add(reader.GetString(i));
                            }
                        }

                        return subjects.Count > 0 ? subjects.ToArray() : new string[0];
                    }
                }
            }
        }

        public static List<TutorDetails> TutorsDetailsFetcher(string Subject)
        {
            var TutorDetail = new List<TutorDetails>();

            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.Tutors, connection))
                {
                    command.Parameters.AddWithValue("@subject", Subject);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TutorDetail.Add(new TutorDetails
                            {
                                TutorName = reader.GetString(0),
                                Expertise = reader.GetString(1),
                                HourlyRate = reader.GetDecimal(2),
                                InTime = reader.GetTimeSpan(3),
                                OutTime = reader.GetTimeSpan(4)
                            });
                        }
                    }
                }
            }

            return TutorDetail;
        }
    }
}
