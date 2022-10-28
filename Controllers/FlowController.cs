namespace OrderShopApi.Controllers;

/// <summary>
/// Obsługa użytkowników.
/// </summary>
[ApiController]
[Route("flow")]
public class FlowController
{
    /// <summary>
    /// Rejestracja użytkownika.
    /// </summary>
    /// <param name="user">Dane użytkownika do rejestracji.</param>
    /// <returns>Dane użytkownika po zarejestrowaniu.</returns>
    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        return new OkResult();
    }

    /// <summary>
    /// Zalogowanie użytkownika do platformy.
    /// </summary>
    /// <param name="user">Dane logowania użytkownika.</param>
    /// <returns>JWT logującego się użytkownika.</returns>
    [HttpPost("login")]
    public IActionResult Login(UserCreds user)
    {
        return new OkObjectResult(string.Empty);
    }

    /// <summary>
    /// Zmiana danych użytkownika.
    /// </summary>
    /// <param name="user">Użytkownik, któremu trzeba podmienić dane.</param>
    /// <returns>Zaktualizowane dane o użytkowniku.</returns>
    [HttpPut("update")]
    public IActionResult Update(User user)
    {
        return new OkResult();
    }

    /// <summary>
    /// Aktywacja użytkownika z linku z maila.
    /// </summary>
    /// <param name="activationToken">Token użytkownika z maila.</param>
    /// <returns>200 jeżeli akcja została wykonana poprawnie.</returns>
    [HttpPost("activate")]
    public IActionResult ActivateUser([FromRoute] string activationToken)
    {
        return new OkResult();
    }

}
