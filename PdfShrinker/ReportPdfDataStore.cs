#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace PdfShrinker
{
    public class ReportPdfDataStore
    {
        private readonly Database _database;

        public ReportPdfDataStore(Database database)
        {
            _database = database;
        }

        public byte[] GetPdfBytes(long pkReportJob)
        {
            var sql = string.Format(
                "SELECT [ReportOutput] " +
                "FROM [ReportJob] " +
                "WHERE [pkReportJob] = {0}",
                pkReportJob);

            var ds = _database.ExecuteDataSet(new SqlCommand(sql));
            
            var row = ds.Tables[0].Rows[0];
            var bytes = (byte[])row["reportOutput"];

            return bytes;
        }
    }
}
