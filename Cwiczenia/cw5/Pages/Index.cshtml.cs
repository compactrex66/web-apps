using cw5.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5.Pages
{
    public class IndexModel : PageModel
    {
        public List<Person> People { get; set; }
        public void OnGet()
        {
            People = GetPeople();
        }

        List<Person> GetPeople() {
            var list = new List<Person>();
            list.Add(new Person {FirstName = "Jan", LastName = "Kowalski", Age = 20});
            list.Add(new Person {FirstName = "Anna", LastName = "Kowalski", Age = 20});
            list.Add(new Person {FirstName = "Andrzej", LastName = "Kowalski", Age = 20});
            return list;
        }
    }
}
