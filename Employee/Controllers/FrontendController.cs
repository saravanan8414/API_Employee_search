using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Models;
using System.Net.Http;

namespace Employee.Controllers
{
    public class FrontendController : Controller
    {        
        public ActionResult Index(string search)
        {            
            IEnumerable<send1> emp = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/Backend");
            var consumeapi = client.GetAsync("Backend");
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<IList<send1>>();
                display.Wait();
                emp = display.Result;
            }
            if (search != null && search != "")
            {
                return View(emp.Where(x => x.EmpNane.StartsWith(search)));
            }

            return View(emp);
        }
        public ActionResult Details(int id)
        {
            send1 emp = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/");
            var consumeapi = client.GetAsync("BackEnd/" + id.ToString());
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<send1>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(send1 emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/BackEnd");
            var consumeapi = client.PostAsJsonAsync<send1>("BackEnd", emp);
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        //Edit get
        public ActionResult Edit(int id)
        {
            send1 emp = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/");
            var consumeapi = client.GetAsync("BackEnd/" + id.ToString());
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<send1>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        //Edit set
        [HttpPost]
        public ActionResult Edit(int id, send1 emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/");
            var consumeapi = client.PutAsJsonAsync<send1>("BackEnd/" + id.ToString(), emp);
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        //Delete
        public ActionResult Delete(int? id)
        {
            send1 emp = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/api/");
            var consumeapi = client.GetAsync("BackEnd/" + id.ToString());
            consumeapi.Wait();
            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<send1>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(int id, send1 emp)
        {
            HttpClient clients = new HttpClient();
            clients.BaseAddress = new Uri("https://localhost:44381/api/BackEnd");
            var consumeapis = clients.DeleteAsync("BackEnd/" + id.ToString());
            consumeapis.Wait();
            var datas = consumeapis.Result;
            if (datas.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


