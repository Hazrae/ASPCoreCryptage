using Microsoft.AspNetCore.Http;

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

        public void Abandon()
        {
            Session.Clear();
        }
    }
}