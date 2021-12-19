using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskEdisun.Models;

namespace TaskEdisun.Controllers
{
    public class HomeController : Controller
    {
        static Dictionary<string, UserHistory> history = new Dictionary<string, UserHistory>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuessNumber()
        {
            Session["userName"] = Request.Form["userName"];

            if (!history.ContainsKey(Session["userName"].ToString()))
            {
                UserHistory item = new UserHistory
                {
                    Extrasence = new List<Extrasence>(),
                    RememberDigits = new List<int>()
                };

                Session["ShawList"] = new List<ShawList>();

                history.Add(
                    Session["userName"].ToString(),
                    item
                );
            }

            UserHistory user = AddOrUserHistory(history[Session["userName"].ToString()]);

            history[Session["userName"].ToString()] = user;

            return View();
        }

        public ActionResult SetUpdateHistory()
        {
            int number = Convert.ToInt32(Request.Form["number"]);
            string userName = Session["userName"].ToString();
            List<Extrasence> newRaw = new List<Extrasence>();

            if (history.ContainsKey(userName))
            {             

                foreach (var item in history[userName].Extrasence.ToList())
                {
                    if (number == item.Adjusting())
                    {
                        item.ExtrasenceReating++;
                        item.IsTrue = true;
                    }
                    else
                    {
                        item.ExtrasenceReating--;
                        item.IsTrue = false;
                    }

                    Extrasence ex = new Extrasence(item.ExtrasenceName, item.ExtrasenceReating, item.IsTrue);
                    newRaw.Add(ex);
                }                
            }

            new ShawList
            {
                RememberDigit = number,
                Extrasences = newRaw, 
                UserName = userName
            };

            return View(ShawList.GetShawList.Where(it => it.UserName == userName).ToList());
        }

        UserHistory AddOrUserHistory(UserHistory item)
        {
            UserHistory cur = new UserHistory()
            {
                RememberDigits = item.RememberDigits,
                Extrasence = item.Extrasence
            };

            var random = new Random();
            int extrasenceCount = random.Next(2, 5);

            for (int i = 0; i < extrasenceCount; i++)
            {
                Extrasence it = GenerateExtrasence();
                if (cur.Extrasence.Any(t => t.ExtrasenceName == it.ExtrasenceName))
                {
                    i--;
                }
                else
                {
                    cur.Extrasence.Add(it);
                }
            }

            return cur;
        }

        private Extrasence GenerateExtrasence()
        {
            var random = new Random();
            int index = random.Next(Extrasences.Count);
            string name = Extrasences[index];

            return new Extrasence(name, random.Next(0, 10), false);
        }

        private List<string> Extrasences = new List<string>
        {
            "extrasence1",
            "extrasence2",
            "extrasence3",
            "extrasence4",
            "extrasence5",
            "extrasence6",
            "extrasence7",
            "extrasence8",
            "extrasence9",
            "extrasence10",
        };
    }
}