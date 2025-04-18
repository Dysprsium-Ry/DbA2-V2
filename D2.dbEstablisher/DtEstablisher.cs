﻿using BOTS.Database_Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BienvenidoOnlineTutorServices.D2.Objects.ObjectModels;
using System.Windows.Forms;
using _3_13_25.D2.QueryStorage;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace _3_13_25.D2.DbConn
{
    public class DtEstablisher
    {
        #region EnrollmentClass

        public static void ECDispTut(DataGridView dataGridView, string query, string param)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@item", param);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView.AutoGenerateColumns = true;
                        dataGridView.DataSource = table;
                    }
                }
            }
        }

        #endregion

        #region TutorClass

        public static void TCDispTut(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand("SELECT TutorName, Expertise, HourlyRate, InTime, OutTime FROM D2.Tutor", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView.AutoGenerateColumns = true;
                        dataGridView.DataSource = table;
                    }
                }
            }
        }

        #endregion

        #region SubjectClass

        #endregion

        #region TransactionList

        public static void TransactionList(DataGridView dataGridView)
        {
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.TransacListDisp, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dtTable = new DataTable();
                        adapter.Fill(dtTable);
                        dataGridView.AutoGenerateColumns = true;
                        dataGridView.DataSource = dtTable;
                    }
                }
            }
        }

        public static DataTable SearchTransactions(string searchTerm)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.SearchTransactionList, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static AutoCompleteStringCollection studentListFetcher()
        {
            List<string> data = new List<string>();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            using (SqlConnection connection = DatabaseConnection.Establish())
            {
                using (SqlCommand command = new SqlCommand(Queries.studentList, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(reader[0].ToString());
                        }
                    }
                }
            }

            foreach (string item in data)
            {
                collection.Add(item);
            }

            return collection;
        }
        #endregion
    }
}
