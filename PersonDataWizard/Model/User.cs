using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataWizard.Model
{
  public class User
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressStreet { get; set; }
    public string AddressPostCode { get; set; }
    public string AddressCity { get; set; }
    public string AddressCountry { get; set; }
    public string PhoneNumber { get; set; }
  }
}
