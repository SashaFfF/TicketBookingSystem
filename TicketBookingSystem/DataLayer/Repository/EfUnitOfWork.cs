using DataLayer.Abstractions;
using DataLayer.Data;
using EntityLibrary.ClientClasses;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using EntityLibrary.UserClasses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        private readonly Lazy<IRepository<Event>>? _eventRepository;
        private readonly Lazy<IRepository<EventType>>? _eventTypeRepository;
        private readonly Lazy<IRepository<AgeLimit>>? _ageLimitRepository;
        private readonly Lazy<IRepository<Location>>? _locationRepository;
        private readonly Lazy<IRepository<Organizer>>? _organizerRepository;

        private readonly Lazy<IRepository<Ticket>>? _ticketRepository;
        private readonly Lazy<IRepository<Status>>? _statusRepository;
        private readonly Lazy<IRepository<Category>>? _categoryRepository;

        private readonly Lazy<IRepository<Client>>? _clientRepository;
        private readonly Lazy<IRepository<Purchase>>? _purchaseRepository;

        private readonly Lazy<IRepository<User>>? _userRepository;
        private readonly Lazy<IRepository<Role>>? _roleRepository;

        public EfUnitOfWork(AppDbContext _context)
        {
            context = _context;

            _eventRepository = new Lazy<IRepository<Event>>(() => new EfRepository<Event>(_context));
            _eventTypeRepository = new Lazy<IRepository<EventType>>(() => new EfRepository<EventType>(_context));
            _ageLimitRepository = new Lazy<IRepository<AgeLimit>>(()=>new EfRepository<AgeLimit>(_context));
            _locationRepository = new Lazy<IRepository<Location>>(()=>new EfRepository<Location>(_context));
            _organizerRepository = new Lazy<IRepository<Organizer>>(()=>new EfRepository<Organizer>(_context));

            _ticketRepository = new Lazy<IRepository<Ticket>>(() => new EfRepository<Ticket>(_context));
            _statusRepository = new Lazy<IRepository<Status>>(() => new EfRepository<Status>(_context));
            _categoryRepository = new Lazy<IRepository<Category>>(() => new EfRepository<Category>(_context));

            _clientRepository = new Lazy<IRepository<Client>>(() => new EfRepository<Client>(_context));
            _purchaseRepository = new Lazy<IRepository<Purchase>>(() => new EfRepository<Purchase>(_context));

            _userRepository = new Lazy<IRepository<User>>(() => new EfRepository<User>(_context));
            _roleRepository = new Lazy<IRepository<Role>>(() => new EfRepository<Role>(_context));
        }

        IRepository<Event> IUnitOfWork.EventRepository => _eventRepository.Value;
        IRepository<EventType> IUnitOfWork.EventTypeRepository => _eventTypeRepository.Value;
        IRepository<AgeLimit> IUnitOfWork.AgeLimitRepository => _ageLimitRepository.Value;
        IRepository<Location> IUnitOfWork.LocationRepository => _locationRepository.Value;
        IRepository<Organizer> IUnitOfWork.OrganizerRepository => _organizerRepository.Value;

        IRepository<Ticket> IUnitOfWork.TicketRepository => _ticketRepository.Value;
        IRepository<Status> IUnitOfWork.StatusRepository => _statusRepository.Value;
        IRepository<Category> IUnitOfWork.CategoryRepository => _categoryRepository.Value;

        IRepository<Client> IUnitOfWork.ClientRepository => _clientRepository.Value;
        IRepository<Purchase> IUnitOfWork.PurchaseRepository => _purchaseRepository.Value;

        IRepository<User> IUnitOfWork.UserRepository => _userRepository.Value;
        IRepository<Role> IUnitOfWork.RoleRepository => _roleRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
