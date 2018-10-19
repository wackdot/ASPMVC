using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPMVC.Data
{
	public class EmployeeBusinessLayer
	{
		public IEnumerable<Employee> Employees
		{
			get
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DataManipulation"].ConnectionString;

				List<Employee> employees = new List<Employee>();

				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
					cmd.CommandType = CommandType.StoredProcedure;
					con.Open();

					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						Employee employee = new Employee();
						employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"].ToString());
						employee.Name = reader["Name"].ToString();
						employee.Gender = reader["DepartmentId"].ToString();
						employee.City = reader["DepartmentId"].ToString();
						employee.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());

						employees.Add(employee);
					}
				}
				return employees;
			}
		}

		public void AddEmployee(Employee employee)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DataManipulation"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("spAddEmployee", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlParameter parameterName = new SqlParameter();
				parameterName.ParameterName = "@Name";
				parameterName.Value = employee.Name;
				cmd.Parameters.Add(parameterName);

				SqlParameter parameterGender = new SqlParameter();
				parameterGender.ParameterName = "@Gender";
				parameterGender.Value = employee.Gender;
				cmd.Parameters.Add(parameterGender);

				SqlParameter parameterCity = new SqlParameter();
				parameterCity.ParameterName = "@City";
				parameterCity.Value = employee.City;
				cmd.Parameters.Add(parameterCity);

				SqlParameter parameterDepartmentId = new SqlParameter();
				parameterDepartmentId.ParameterName = "@DepartmentId";
				parameterDepartmentId.Value = employee.DepartmentId;
				cmd.Parameters.Add(parameterDepartmentId);

				con.Open();
				cmd.ExecuteNonQuery();
			}
		}
	}
}
