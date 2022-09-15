using QuizTALHAASIF.App_Code;
using QuizTALHAASIF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizTALHAASIF.Controllers
{
    public class DepartmentController : Controller
    {
        Cls_Connections connections = new Cls_Connections();
        public ActionResult Index()
        {
            List<DepartmentModel> data = new List<DepartmentModel>();
            DepartmentModel model = new DepartmentModel();
            DataTable dt = connections.GetDataTable("GetDepartment", CommandType.StoredProcedure);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new DepartmentModel();
                    model.DepartmentName = dr["DepartmentName"].ToString();
                    model.DepartmentLocation = dr["DepartmentLocation"].ToString();
                    model.DepartmentCellNumber = dr["DepartmentCellNumber"].ToString();

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
        public ActionResult Create(DepartmentModel model)
        {
            ParamCollection param = new ParamCollection();

            param.Add(new SqlParameter("@DepartmentName", model.DepartmentName));
            param.Add(new SqlParameter("@DepartmentLocation", model.DepartmentLocation));
            param.Add(new SqlParameter("@DepartmentCellNumber", model.DepartmentCellNumber));

            connections.ExecuteQuery("AddDepartment", CommandType.StoredProcedure, param);
            return RedirectToAction("Index", "Department");
        }
    }
}