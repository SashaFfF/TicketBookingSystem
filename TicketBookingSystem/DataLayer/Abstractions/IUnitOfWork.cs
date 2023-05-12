using EntityLibrary.ClientClasses;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using EntityLibrary.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Event> EventRepository { get; }
        IRepository<EventType> EventTypeRepository { get; }
        IRepository<AgeLimit> AgeLimitRepository { get; }
        IRepository<Location> LocationRepository { get; }
        IRepository<Organizer> OrganizerRepository { get; }

        IRepository<Ticket> TicketRepository { get; }
        IRepository<Status> StatusRepository { get; }
        IRepository<Category> CategoryRepository { get; }

        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; }

        IRepository<Client> ClientRepository { get; }
        IRepository<Purchase> PurchaseRepository { get; }

        public Task CreateDatabaseAsync();
        public Task RemoveDatabaseAsync();
        public Task SaveAllAsync();
    }
}
