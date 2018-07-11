using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using RestourantManagement.DAL.Model;

namespace RestorauntManagment.Controllers
{
    public class RestourantMenuController : Controller
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private Model1 db = new Model1();
        // GET: RestourantMenu
        public ActionResult Index(int id = 0, int State = -1, string Message = "")
        {
            ViewBag.State = State;
            ViewBag.Message = Message;
            List<SelectListItem> eats = new List<SelectListItem>();
            foreach (EatType item in db.EatTypes)
            {
                eats.Add(new SelectListItem() { Value = item.eatTypeId.ToString(), Text = item.typeName });
            }
            TempData.Add("Eats", eats);
            if (id == 0)
            {
                return View(new Menu());
            }
            else
            {
                Menu temp = db.Menu.FirstOrDefault(f => f.ItemId == id);
                return View(temp);
            }

        }

        public ActionResult SaveMenu(RestourantManagement.DAL.Model.Menu menu)
        {
            if (menu.ItemId == 0)
            {
                try

                {
                    db.Menu.Add(menu);
                    db.SaveChanges();
                    return RedirectToAction("ViewAndEditMenu", new { State = 0, Message = "Данные успешно сохранены" });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { State = 1, Message = ex.Message });

                }
            }

            else
            {

                Menu temp = db.Menu.FirstOrDefault(f => f.ItemId == menu.ItemId);
                db.Entry(temp).CurrentValues.SetValues(menu);
                db.SaveChanges();
                return RedirectToAction("ViewAndEditMenu", new { State = 0, Message = "Данные успешно сохранены" });
            }
        }


        public ActionResult DeleteMenu(int? id)
        {
            try

            {

                db.Menu.Remove(db.Menu.FirstOrDefault(f => f.ItemId == id));
                db.SaveChanges();
                return RedirectToAction("ListMenu", new { State = 0, Message = "Данные успешно сохранены" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { State = 1, Message = ex.Message });

            }
        }

        public ActionResult ListMenu(int State = -1, string Message = "")
        {
            ViewBag.State = State;
            ViewBag.Message = Message;
            List<Menu> menu = db.Menu.OrderBy(o => o.ItemEatTypeId).ToList();
            return View(menu);
        }

        public ActionResult ReservationTable()
        {
            return View();
        }

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult ViewAndEditEatTypes(int State = -1, string Message = "")
        {
            List<EatType> eats = db.EatTypes.ToList();
            ViewBag.State = State;
            ViewBag.Message = Message;
            return View(eats);
        }

        public ActionResult EatTypes(EatType eat, int id = 0)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        db.EatTypes.Add(eat);
                        db.SaveChanges();
                        return RedirectToAction("ViewAndEditEatTypes");
                    }
                    catch (Exception ex)
                    {
                        logger.Info(ex.Message);
                    }
                }
                else
                {

                    EatType temp = db.EatTypes.FirstOrDefault(f => f.eatTypeId == id);
                    eat.eatTypeId = id;
                    db.Entry(temp).CurrentValues.SetValues(eat);
                    db.SaveChanges();
                    return RedirectToAction("ViewAndEditEatTypes");
                }

            }
            if (id != 0)
            {

                EatType temp = db.EatTypes.FirstOrDefault(f => f.eatTypeId == id);
                return View(temp);
            }
            return View();
        }

        public ActionResult DeleteEatType(int id)
        {
            try
            {
                db.EatTypes.Remove(db.EatTypes.FirstOrDefault(f => f.eatTypeId == id));
                db.SaveChanges();
                return RedirectToAction("ViewAndEditEatTypes", new { State = 0, Message = "Объект успешно удален" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewAndEditEatTypes", new { State = 1, Message = ex.Message });
            }
        }

        public ActionResult ViewAndEditMenu(int id = 0)
        {
            List<Menu> menu = db.Menu.OrderBy(o => o.ItemEatTypeId).ToList();

            return View(menu);
        }

        public ActionResult AddRecruitment(Employee employee, int id = 0)
        {

            try
            {
                employee.jobId = id;
                employee.status = false;
                db.Employees.Add(employee);
                
                db.SaveChanges();
                return RedirectToAction("ViewAndApplyVacancy");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            return View();
        }


        public ActionResult ViewAndEditVacancy(int State = -1, string Message = "")
        {
            List<Job> jobs = db.Jobs.ToList();
            ViewBag.State = State;
            ViewBag.Message = Message;
            return View(jobs);
        }

        public ActionResult AddVacancy(Job job, int id = 0)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    try
                    {
                        db.Jobs.Add(job);
                        db.SaveChanges();
                        return RedirectToAction("ViewAndEditvacancy");
                    }
                    catch (Exception ex)
                    {
                        logger.Info(ex.Message);
                    }
                }
                else
                {

                    Job temp = db.Jobs.FirstOrDefault(f => f.JobId == id);
                    job.JobId = id;
                    db.Entry(temp).CurrentValues.SetValues(job);
                    db.SaveChanges();
                    return RedirectToAction("ViewAndEditVacancy");
                }

            }
            if (id != 0)
            {

                Job temp = db.Jobs.FirstOrDefault(f => f.JobId == id);
                return View(temp);
            }
            return View();
        }

        public ActionResult DeleteVacancy(int id)
        {
            try
            {
                db.Jobs.Remove(db.Jobs.FirstOrDefault(f => f.JobId == id));
                db.SaveChanges();
                return RedirectToAction("ViewAndEditVacancy", new { State = 0, Message = "Объект успешно удален" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewAndEditVacancy", new { State = 1, Message = ex.Message });
            }
        }

        public ActionResult ViewAndApplyVacancy()
        {
            List<Job> jobs = db.Jobs.ToList();
            return View(jobs);
        }

        public ActionResult ViewAndEditEmployees(int id = 0)
        {
            List<Employee> employees = db.Employees.Where(w=>w.status ==false).OrderBy(o => o.jobId).ToList();

            return View(employees);
        }

        public ActionResult AcceptorRejectEmloyee(int id = 0, string message = "")
        {
            Employee employee = db.Employees.FirstOrDefault(f => f.EmployeeId == id);

            try
            {
                if (message == "Вы приняты!")
                {
                    employee.status = true;
                    db.SaveChanges();
                }
                else
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                MailMessage mail = new MailMessage("you@yourcompany.com", employee.username);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = "Работа в нашем ресторане";
                mail.Body = message;
                client.Send(mail);
                
                return RedirectToAction("ViewAndEditEmployees");
            }

            catch(Exception ex)
            {
            return RedirectToAction("ViewAndEditEmployees");
                
            }
        }

       

        public ActionResult Reservation(Reservation reservation)
        {
            try
            {
                db.Reservatiosn.Add(reservation);
                db.SaveChanges();
               return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View();
            }
            
               
        }

        public ActionResult AcceptOrRejectReservation(int id = 0, string message = "")
        {
            Reservation res = db.Reservatiosn.FirstOrDefault(f => f.ReservationId == id);

            try
            {
                if (message == "Резерв подтвержден")
                {
                    res.Status = true;
                    db.SaveChanges();
                }
                else
                {
                    db.Reservatiosn.Remove(res);
                    db.SaveChanges();
                }
                MailMessage mail = new MailMessage("you@yourcompany.com", res.Email);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = "Резерв стола";
                mail.Body = message;
                client.Send(mail);
                
                return RedirectToAction("ViewAndEditReservation");
            }

            catch (Exception ex)
            {
                return RedirectToAction("ViewAndEditReservation");

            }
        }

        public ActionResult ViewAndEditReservation()
        {
            return View(db.Reservatiosn.Where(w=>w.Status==false).ToList());
        }
       
        }
    }
