using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LinqIntro.Mappers
{
    public class AdminMapper : BaseMapper
    {
        public IEnumerable<User> Map(IEnumerable<XElement> elements)
        {
            int count = 0;
            
            var result = new List<User>();
            foreach (XElement element in elements)
            {
                if (count % 20 == 0)
                {
                    var user = new Admin();
                    user.Id = GetIntAttributeValue(element, "Id");
                    user.DisplayName = GetStringAttributeValue(element, "DisplayName");
                    user.Age = GetIntAttributeValue(element, "Age");
                    user.Reputation = GetIntAttributeValue(element, "Reputation");
                    user.LastAccessDate = GetDateAttributeValue(element, "LastAccessDate");
                    user.CreationDate = GetDateAttributeValue(element, "CreationDate");
                    user.WebsiteUrl = GetStringAttributeValue(element, "WebsiteUrl");
                    user.Views = GetIntAttributeValue(element, "Views");
                    user.Age = GetIntAttributeValue(element, "Age");
                    user.UpVotes = GetIntAttributeValue(element, "UpVotes");
                    user.DownVotes = GetIntAttributeValue(element, "DownVotes");
                    user.Location = GetStringAttributeValue(element, "Location");
                    user.AboutMe = GetStringAttributeValue(element, "AboutMe");
                    result.Add(user);
                }
                else
                {
                    var user = new User();
                    user.Id = GetIntAttributeValue(element, "Id");
                    user.DisplayName = GetStringAttributeValue(element, "DisplayName");
                    user.Age = GetIntAttributeValue(element, "Age");
                    user.Reputation = GetIntAttributeValue(element, "Reputation");
                    user.LastAccessDate = GetDateAttributeValue(element, "LastAccessDate");
                    user.CreationDate = GetDateAttributeValue(element, "CreationDate");
                    user.WebsiteUrl = GetStringAttributeValue(element, "WebsiteUrl");
                    user.Views = GetIntAttributeValue(element, "Views");
                    user.Age = GetIntAttributeValue(element, "Age");
                    user.UpVotes = GetIntAttributeValue(element, "UpVotes");
                    user.DownVotes = GetIntAttributeValue(element, "DownVotes");
                    user.Location = GetStringAttributeValue(element, "Location");
                    user.AboutMe = GetStringAttributeValue(element, "AboutMe");
                    result.Add(user);
                }
                count++;
            }
            return result;
        }
    }
}
