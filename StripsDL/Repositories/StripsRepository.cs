//using StripsBL.DTOs;
using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Reeks GetReeks(int id)
        {

            string SQLquery = "select Reeks.Naam, Strip.Id, Strip.Titel, Strip.Nr from Reeks left join Strip on Reeks.Id = Strip.Reeks where Reeks.Id = @id order by Strip.Nr;";

            try
            {
                using (SqlConnection connection = new(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = SQLquery;
                    Reeks reeks = null;

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);

                        IDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            if (reeks is null)
                            {
                                reeks = new(reader.GetString(0));
                            }

                            int? stripNR = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                            Strip strip = new(reader.GetInt32(1), reader.GetString(2),stripNR);

                            reeks.Strips.Add(strip);

                        }

                    }
                    catch (StripsRepositoryException ex)
                    {
                        throw new StripsRepositoryException("Something went worng when getting the reeks", ex);
                    }

                        return reeks;

                }
            }
            catch (StripsRepositoryException ex)
            {
                throw new StripsRepositoryException("Something went wrong with the DB", ex);
            }
        }
    }
}
