using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EMS_MVC_30121023.Models.Department
{
    public class DepartmentRepository
    {
        private string cs;
        public DepartmentRepository()
        {
          cs = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        }
        public List<DepartmentModel> GetDepartments
        {
            //string cs = string.Empty;

            get
            {
                //return new List<DepartmentModel>()
                //                {
                //                    new DepartmentModel()
                //                    {
                //                        DepartmentId = 1,
                //                        DepartmentCode = "HR",
                //                        DepartmentName = "Human Resource"
                //                    },
                //                    new DepartmentModel()
                //                    {
                //                        DepartmentId = 2,
                //                        DepartmentCode = "MR",
                //                        DepartmentName = "Manager"
                //                    },
                //                    new DepartmentModel()
                //                    {
                //                        DepartmentId = 3,
                //                        DepartmentCode = "DPTR",
                //                        DepartmentName = "Department Manager"
                //                    }
                //                };


                List<DepartmentModel> models = new List<DepartmentModel>();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("spGetAllDepartments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        models.Add(new DepartmentModel()
                        {
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                            DepartmentCode = Convert.ToString(dr["DepartmentCode"]),
                            DepartmentName = Convert.ToString(dr["DepartmentName"])
                        });
                    }
                }
                con.Close();

                return models;
            }
        }

        public bool Save(DepartmentModel model,out string Message)
        {
            try
            {
                Message = string.Empty;
                string statuscode = string.Empty;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("[spInsertDepartment]", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeptCode", model.DepartmentCode);
                    cmd.Parameters.AddWithValue("@DeptName", model.DepartmentName);

                    con.Open();
                    statuscode =  (string)cmd.ExecuteScalar();
                    con.Close();
                }

                if (statuscode == "S001")
                    return true;
                else if (statuscode == "RE01")
                    Message = "Record already exits";

                    return false;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool Remove(int DepartmentId, out string Message)
        {
            try
            {
                Message = string.Empty;
                string statuscode = string.Empty;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("[spRemoveDepartment]", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);

                    con.Open();
                    statuscode = (string)cmd.ExecuteScalar();
                    con.Close();
                }

                if (statuscode == "S001")
                    return true;
                else if (statuscode == "RN01")
                    Message = "Record Not Found!";

                return false;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }
    }
}