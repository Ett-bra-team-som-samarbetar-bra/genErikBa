namespace Core.Services;

public class DataService(Database DbContext) : IDataService
{
    private readonly Database _db = DbContext;

    public async Task<User?> GetUserByName(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> DoesUserExist(string username)
    {
        return await _db.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task AddUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveUser(User user)
    {   
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
    }

    public async Task<Event?> GetEventByName(string name)
    {
        return await _db.Events.FirstOrDefaultAsync(u => u.Name == name);
    }

    public async Task<Event?> DoesEventExist(string name)
    {
        return await _db.Events.FirstOrDefaultAsync(u => u.Name == name);
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _db.Events.ToListAsync();
    }

    public async Task AddEvent(Event ev)
    {
        _db.Events.Add(ev);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveEvent(Event ev)
    {
        _db.Events.Remove(ev);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Ticket>> GetAllTickets()
    {
        return await _db.Tickets.ToListAsync();
    }

    public async Task AddTicket(Ticket ticket)
    {
        _db.Tickets.Add(ticket);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveTicket(Ticket ticket)
    {
        _db.Tickets.Remove(ticket);
        await _db.SaveChangesAsync();
    }
}
