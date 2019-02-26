using System;
using System.Data.SqlClient;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            try
            {
                var s = 434;
                var dsds = s + 1;
                var connection = new SqlConnection("Data Source=.;Database=Test;Persist Security Info=True;UID=sa;Pwd=123456");
                connection.Open();
                using (var scop2 = connection.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand("  insert into [User](Name,Age) values('ภ๏หน',23)", connection, scop2))
                    {
                        var o = command.ExecuteNonQuery();
                        scop2.Dispose();
                        //scop2.Commit();
                    }
                }
                connection.Close();


                connection.Dispose();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
