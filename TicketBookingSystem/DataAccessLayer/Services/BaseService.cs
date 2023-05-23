using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary.ClientClasses;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using EntityLibrary.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MyTypes
{
    AgeLimit,
    EventType,
    Location,
    Organizer,
    Category,
    Status,
    Client,
    Purchase,
    User,
    Role
}

namespace DataAccessLayer.Services
{
    public class BaseService<T> { }
    //{
    //    IUnitOfWork unitOfWork;
    //    public BaseService(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }
    //    public async Task<T> AddAsync(T item)
    //    {
    //        string typeName = nameof(T);
    //        MyTypes type;
    //        Enum.TryParse<MyTypes>(typeName, out type);
    //        switch (type)
    //        {
    //            case MyTypes.EventType:
    //                await unitOfWork.EventTypeRepository.AddAsync(item as EventType);
    //                break;
    //            case MyTypes.AgeLimit:
    //                await unitOfWork.AgeLimitRepository.AddAsync(item as AgeLimit);
    //                break;
    //            case MyTypes.Location:
    //                await unitOfWork.LocationRepository.AddAsync(item as Location);
    //                break;
    //            case MyTypes.Organizer:
    //                await unitOfWork.OrganizerRepository.AddAsync(item as Organizer);
    //                break;
    //            case MyTypes.Category:
    //                await unitOfWork.CategoryRepository.AddAsync(item as Category);
    //                break;
    //            case MyTypes.Status:
    //                await unitOfWork.StatusRepository.AddAsync(item as Status);
    //                break;
    //            case MyTypes.Client:
    //                await unitOfWork.ClientRepository.AddAsync(item as Client);
    //                break;
    //            case MyTypes.Purchase:
    //                await unitOfWork.PurchaseRepository.AddAsync(item as Purchase);
    //                break;
    //            case MyTypes.User:
    //                await unitOfWork.UserRepository.AddAsync(item as User);
    //                break;
    //            case MyTypes.Role:
    //                await unitOfWork.RoleRepository.AddAsync(item as Role);
    //                break;
    //        }
    //        return item;
    //    }

    //    public async Task<T?> DeleteAsync(int id)
    //    {
    //        string typeName = nameof(T);
    //        MyTypes type;
    //        Enum.TryParse<MyTypes>(typeName, out type);

    //        switch (type)
    //        {
    //            case MyTypes.EventType:
    //                T? eventType = await GetByIdAsync(id);
    //                await unitOfWork.EventTypeRepository.DeleteAsync(eventType as EventType);
    //                return eventType;
    //            case MyTypes.AgeLimit:
    //                T? ageLimit = await GetByIdAsync(id);
    //                await unitOfWork.AgeLimitRepository.DeleteAsync(ageLimit as AgeLimit);
    //                return ageLimit;
    //            case MyTypes.Location:
    //                T? location = await GetByIdAsync(id);
    //                await unitOfWork.LocationRepository.DeleteAsync(location as Location);
    //                return location;
    //            case MyTypes.Organizer:
    //                T? organizer = await GetByIdAsync(id);
    //                await unitOfWork.OrganizerRepository.DeleteAsync(organizer as Organizer);
    //                return organizer;
    //            case MyTypes.Category:
    //                T? category = await GetByIdAsync(id);
    //                await unitOfWork.CategoryRepository.DeleteAsync(category as Category);
    //                return category;
    //            case MyTypes.Status:
    //                T? status = await GetByIdAsync(id);
    //                await unitOfWork.StatusRepository.DeleteAsync(status as Status);
    //                return status;
    //            case MyTypes.Client:
    //                T? client = await GetByIdAsync(id);
    //                await unitOfWork.ClientRepository.DeleteAsync(client as Client);
    //                return client;
    //            case MyTypes.Purchase:
    //                T? purchase = await GetByIdAsync(id);
    //                await unitOfWork.PurchaseRepository.DeleteAsync(purchase as Purchase);
    //                return purchase;
    //            case MyTypes.User:
    //                T? user = await GetByIdAsync(id);
    //                await unitOfWork.UserRepository.DeleteAsync(user as User);
    //                return user;
    //            case MyTypes.Role:
    //                T? role = await GetByIdAsync(id);
    //                await unitOfWork.RoleRepository.DeleteAsync(role as Role);
    //                return role;
    //            default: return null;
    //        }
    //    }

    //    //public async Task<IEnumerable<T>> GetAllAsync()
    //    //{
    //    //    string typeName = nameof(T);
    //    //    MyTypes type;
    //    //    Enum.TryParse<MyTypes>(typeName, out type);
    //    //    switch (type)
    //    //    {
    //    //        case MyTypes.Location:
    //    //            return (IEnumerable<T>)await unitOfWork.LocationRepository.ListAllAsync();
    //    //        case MyTypes.AgeLimit:
    //    //            return (IEnumerable<T>)await unitOfWork.AgeLimitRepository.ListAllAsync();
    //    //        case MyTypes.EventType:
    //    //            return (IEnumerable<T>)await unitOfWork.EventTypeRepository.ListAllAsync();
    //    //        //case MyTypes.Location:
    //    //        //    return (IEnumerable<T>)await unitOfWork.LocationRepository.ListAllAsync();
    //    //        case MyTypes.Organizer:
    //    //            return (IEnumerable<T>)await unitOfWork.OrganizerRepository.ListAllAsync();
    //    //        case MyTypes.Category:
    //    //            return (IEnumerable<T>)await unitOfWork.CategoryRepository.ListAllAsync();
    //    //        case MyTypes.Status:
    //    //            return (IEnumerable<T>)await unitOfWork.StatusRepository.ListAllAsync();
    //    //        case MyTypes.Client:
    //    //            return (IEnumerable<T>)await unitOfWork.ClientRepository.ListAllAsync();
    //    //        case MyTypes.Purchase:
    //    //            return (IEnumerable<T>)await unitOfWork.PurchaseRepository.ListAllAsync();
    //    //        case MyTypes.User:
    //    //            return (IEnumerable<T>)await unitOfWork.UserRepository.ListAllAsync();
    //    //        case MyTypes.Role:
    //    //            return (IEnumerable<T>)await unitOfWork.RoleRepository.ListAllAsync();
    //    //        default: return null;
    //    //    }
    //    //}

    //    public async Task<IEnumerable<T>> GetAllAsync()
    //    {
    //        string type = nameof(T);
    //        switch (type)
    //        {
    //            case "Location":
    //                return (IEnumerable<T>)await unitOfWork.LocationRepository.ListAllAsync();
    //            case "AgeLimit":
    //                return (IEnumerable<T>)await unitOfWork.AgeLimitRepository.ListAllAsync();
    //            case "EventType":
    //                return (IEnumerable<T>)await unitOfWork.EventTypeRepository.ListAllAsync();
    //            //case MyTypes.Location:
    //            //    return (IEnumerable<T>)await unitOfWork.LocationRepository.ListAllAsync();
    //            case "Organizer":
    //                return (IEnumerable<T>)await unitOfWork.OrganizerRepository.ListAllAsync();
    //            case "Category":
    //                return (IEnumerable<T>)await unitOfWork.CategoryRepository.ListAllAsync();
    //            case "Status":
    //                return (IEnumerable<T>)await unitOfWork.StatusRepository.ListAllAsync();
    //            case "Client":
    //                return (IEnumerable<T>)await unitOfWork.ClientRepository.ListAllAsync();
    //            case "Purchase":
    //                return (IEnumerable<T>)await unitOfWork.PurchaseRepository.ListAllAsync();
    //            case "User":
    //                return (IEnumerable<T>)await unitOfWork.UserRepository.ListAllAsync();
    //            case "Role":
    //                return (IEnumerable<T>)await unitOfWork.RoleRepository.ListAllAsync();
    //            default: return null;
    //        }
    //    }


    //    public async Task<T?> GetByIdAsync(int id)
    //    {
    //        string typeName = nameof(T);
    //        MyTypes type;
    //        Enum.TryParse<MyTypes>(typeName, out type);
    //        switch(type)
    //        {
    //            case MyTypes.EventType:
    //                return await unitOfWork.EventTypeRepository.GetByIdAsync(id) as T;
    //            case MyTypes.AgeLimit:
    //                return await unitOfWork.AgeLimitRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Location:
    //                return await unitOfWork.LocationRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Organizer:
    //                return await unitOfWork.OrganizerRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Category:
    //                return await unitOfWork.CategoryRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Status:
    //                return await unitOfWork.StatusRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Client:
    //                return await unitOfWork.ClientRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Purchase:
    //                return await unitOfWork.PurchaseRepository.GetByIdAsync(id) as T;
    //            case MyTypes.User:
    //                return await unitOfWork.UserRepository.GetByIdAsync(id) as T;
    //            case MyTypes.Role:
    //                return await unitOfWork.RoleRepository.GetByIdAsync(id) as T;
    //            default: return null;
    //        }
    //    }

    //    public async Task<T> UpdateAsync(T item)
    //    {
    //        string typeName = nameof(T);
    //        MyTypes type;
    //        Enum.TryParse<MyTypes>(typeName, out type);
    //        switch (type)
    //        {
    //            case MyTypes.EventType:
    //                await unitOfWork.EventTypeRepository.UpdateAsync(item as EventType);
    //                break;
    //            case MyTypes.AgeLimit:
    //                await unitOfWork.AgeLimitRepository.UpdateAsync(item as AgeLimit);
    //                break;
    //            case MyTypes.Location:
    //                await unitOfWork.LocationRepository.UpdateAsync(item as Location);
    //                break;
    //            case MyTypes.Organizer:
    //                await unitOfWork.OrganizerRepository.UpdateAsync(item as Organizer);
    //                break;
    //            case MyTypes.Category:
    //                await unitOfWork.CategoryRepository.UpdateAsync(item as Category);
    //                break;
    //            case MyTypes.Status:
    //                await unitOfWork.StatusRepository.UpdateAsync(item as Status);
    //                break;
    //            case MyTypes.Client:
    //                await unitOfWork.ClientRepository.UpdateAsync(item as Client);
    //                break;
    //            case MyTypes.Purchase:
    //                await unitOfWork.PurchaseRepository.UpdateAsync(item as Purchase);
    //                break;
    //            case MyTypes.User:
    //                await unitOfWork.UserRepository.UpdateAsync(item as User);
    //                break;
    //            case MyTypes.Role:
    //                await unitOfWork.RoleRepository.UpdateAsync(item as Role);
    //                break;
    //        }
    //        return item;
    //    }
}
