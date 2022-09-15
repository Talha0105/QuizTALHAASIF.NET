using QuizTALHAASIF.App_Code;
using QuizTALHAASIF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizTALHAASIF.Controllers
{
    public class StudentController : Controller
    {
        Cls_Connections connections = new Cls_Connections();

        // GET: Student
        public ActionResult Index()
        {
            List<StudentModel> data = new List<StudentModel>();
            StudentModel model = new StudentModel();
            DataTable dt = connections.GetDataTable("GetStudentList", CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new StudentModel();
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.CellNumber = dr["CellNumber"].ToString();
                    model.Address = dr["Address"].ToString();

                    data.Add(model);
                }
            }
            return View(data);


        }
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            ParamCollection param = new ParamCollection();

            param.Add(new SqlParameter("@FirstName", model.FirstName));
            param.Add(new SqlParameter("@LastName", model.LastName));
            param.Add(new SqlParameter("@CellNumber", model.CellNumber));
            param.Add(new SqlParameter("@Address", model.Address));

            connections.ExecuteQuery("AddStduent", CommandType.StoredProcedure, param);
            return RedirectToAction("Index", "Student");
        }
    }
}