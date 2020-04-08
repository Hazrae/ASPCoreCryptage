using ASPCoreToDo.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ASPCoreToDo.Infrastructure
{
    internal class SessionManager : ISessionManager
    {
        private ISession Session { get; }

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }

        public int Id
        {
            get { return (Session.GetInt32(nameof(Id)).HasValue) ? Session.GetInt32(nameof(Id)).Value : -1; }
            set { Session.SetInt32(nameof(Id), value); }
        }

        public string Lastname
        {
            get { return (Session.GetString(nameof(Lastname)) is null) ? "" : Session.GetString(nameof(Lastname)); }
            set { Session.SetString(nameof(Lastname), value); }
        }
        public string Firstname
        {
            get { return (Session.GetString(nameof(Firstname)) is null) ? "" : Session.GetString(nameof(Firstname)); }
            set { Session.SetString(nameof(Firstname), value); }
        }
        public string Email
        {
            get { return (Session.GetString(nameof(Email)) is null) ? "" : Session.GetString(nameof(Email)); }
            set { Session.SetString(nameof(Email), value); }
        }

        // stockage d'un user dans une variable de session => serialiser en json pour le stocker comme un string
        public User User
        {            
            get
            {
                string json = Session.GetString(nameof(User));
                return (json is null) ? null : JsonConvert.DeserializeObject<User>(json);
            }
            set { Session.SetString(nameof(User), JsonConvert.SerializeObject(value)); }
        }

        public void Abandon()
        {
            Session.Clear();
        }
    }
}