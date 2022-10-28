namespace OrderShopApi.Services;

/// <summary>
/// Implementacja obsługi użytkowników.
/// </summary>
public class FlowService: IUserRepository
{
    /// <summary>
    /// Kontekst używanej bazy danych.
    /// </summary>
    readonly SQLiteContext context;

    /// <summary>
    /// Usługa wysyłania maili.
    /// </summary>
    readonly IMailRepository mailService;

    public FlowService(SQLiteContext _context, IMailRepository _mailService)
    {
        context = _context;
        mailService = _mailService;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Implementacja interfejsu.
    ///

    /// <summary>
    /// Rejestracja użytkownika.
    /// </summary>
    /// <param name="user">Dane użytkownika do rejestracji.</param>
    /// <returns>Dane użytkownika po zarejestrowaniu.</returns>
    public async Task<User> Register(User user)
    {
        try
        {
            user.ActivationToken = PrepareActivationToken(user.Surname, user.Email);
            await context.AddAsync(user);
            int result = await context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Błąd przy dodawaniu użytkownika");
            }
            if(SendActivationMail(user))
            {
                return null;
            }
            return user;
        } 
        catch (Exception e) 
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Zalogowanie użytkownika do platformy.
    /// </summary>
    /// <param name="user">Dane logowania użytkownika.</param>
    /// <returns>JWT logującego się użytkownika.</returns>
    public string Login(UserCreds creds)
    {
        try
        {
            User user = (User)(from u in context.Users
                               where u.Email == creds.Email
                               where u.Password == creds.Password
                               select u);
            if (user == null)
            {
                throw new Exception("Użytkownik niezarejestrowany.");
            }
            if (!user.IsActivated)
            {
                throw new Exception("Użytkownik nieaktywowany.");
            }
            return PrepareJWTToken(user);
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Zmiana danych użytkownika.
    /// </summary>
    /// <param name="user">Użytkownik, któremu trzeba podmienić dane.</param>
    /// <returns>Zaktualizowane dane o użytkowniku.</returns>
    public async Task<User> Update(User user)
    {
        try
        {
            User userToUpdate = (User) context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (userToUpdate == null)
            {
                throw new Exception("Użytkownik niezarejestrowany.");
            }
            context.Update(user);
            int result = await context.SaveChangesAsync();
            if(result == 0)
            {
                throw new Exception("Błąd przy edycji danych użytkownika.");
            }
            return user;
        } 
        catch (Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Aktywacja użytkownika z linku z maila.
    /// </summary>
    /// <param name="activationToken">Token użytkownika z maila.</param>
    /// <returns>True jeżeli akcja została wykonana poprawnie.</returns>
    public async Task<bool> Activate(string activationToken)
    {
        try
        {
            User user = (User)(from u in context.Users
                               where u.ActivationToken == activationToken
                               select u);
            if (user == null)
            {
                return false;
            }
            user.IsActivated = true;
            context.Update(user);
            int result = await context.SaveChangesAsync();
            return result > 0;
        } 
        catch(Exception e)
        {
            Debug.WriteLine(e.StackTrace);
            throw;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Metody pomocnicze.
    ///

    private bool SendActivationMail(User user)
    {
        try
        {
            return true;
        } 
        catch(Exception)
        {
            throw;
        }
    }

    private string PrepareActivationToken(string surname, string email)
    {
        return "site.pl/userActivation?activationToken=";
    }

    private string PrepareJWTToken(User user)
    {
        return String.Empty;
    }



}
