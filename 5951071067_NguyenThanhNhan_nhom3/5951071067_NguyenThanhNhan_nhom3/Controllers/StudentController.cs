using _5951071067_NguyenThanhNhan_nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071067_NguyenThanhNhan_nhom3.Controllers
{
    public class StudentController : ApiController
    {
        [EnableCors(origins: "http://mywebclient.azurewebsite.net",headers: "*",methods: "*")]
        private SqlConnection _con;
        private SqlDataAdapter _adapter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            _con = new SqlConnection("Data Source=.;Initial Catalog=Nawab;Integrated Security=True");
            _con.Open();
            DataTable data = new DataTable();
            var query = "select * from student_";
            SqlCommand command = new SqlCommand(query, _con);
            _adapter = new SqlDataAdapter(command);
            _adapter.Fill(data);

            List<Student> students = new List<Student>(data.Rows.Count);
            if (data.Rows.Count> 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    students.Add(new ReadStudent(item));
                }
            }
            _con.Close();
            return students ;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            _con = new SqlConnection("Data Source=.;Initial Catalog=Nawab;Integrated Security=True");
            _con.Open();
            DataTable data = new DataTable();
            var query = "select * from student_ where id=" + id;
            SqlCommand command = new SqlCommand(query, _con);
            _adapter = new SqlDataAdapter(command);
            _adapter.Fill(data);

            List<Student> students = new List<Student>(data.Rows.Count);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    students.Add(new ReadStudent(item));
                }
            }
            _con.Close();
            return students;
        }

        // POST api/<controller>
        public String Post([FromBody] CreateStudent value)
        {
            _con = new SqlConnection("Data Source=.;Initial Catalog=Nawab;Integrated Security=True");
            _con.Open();
            String query = " INSERT dbo.Student_(f_name, m_name, l_name, address, birthDate, score)VALUES(N'"+value.f_name+"',N'"+value.m_name+"', N'"+value.l_name+"', N'"+value.address+"', N'"+value.birthDate+"', N'"+value.score+"')";
            SqlCommand command = new SqlCommand(query, _con);
             int result =command.ExecuteNonQuery();
            if (result> 0)
            {
                return "them thanh cong";
            }
            else
            {
                return "them that bai";
            }
        }

        // PUT api/<controller>/5
        public String Put(int id, [FromBody] CreateStudent value)
        {
            _con = new SqlConnection("Data Source=.;Initial Catalog=Nawab;Integrated Security=True");
            _con.Open();
            String query = " UPDATE dbo.Student_ SET f_name =N'" + value.f_name + "', m_name=N'" + value.m_name + "', l_name=N'" + value.l_name + "', address=N'" + value.address + "', birthDate=N'" + value.birthDate + "', score=N'" + value.score + "') where Id = " + value.id+")";
            SqlCommand command = new SqlCommand(query, _con);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                return "sua thanh cong";
            }
            else
            {
                return "sua that bai";
            }
        }

        // DELETE api/<controller>/5
        public String Delete(int id)
        {

            _con = new SqlConnection("Data Source=.;Initial Catalog=Nawab;Integrated Security=True");
            _con.Open();
            String query = "DELETE dbo.Student_ WHERE Id="+ id;
            SqlCommand command = new SqlCommand(query, _con);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                return "xoa thanh cong";
            }
            else
            {
                return "xoa that bai";
            }
        }
    }
}