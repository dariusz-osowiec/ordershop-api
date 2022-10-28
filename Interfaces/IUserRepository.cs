namespace OrderShopApi.Interfaces
{
    /// <summary>
    /// Obsługa użytkowników.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Rejestracja użytkownika.
        /// </summary>
        /// <param name="user">Dane użytkownika do rejestracji.</param>
        /// <returns>Dane użytkownika po zarejestrowaniu.</returns>
        public Task<User> Register(User user);

        /// <summary>
        /// Zalogowanie użytkownika do platformy.
        /// </summary>
        /// <param name="user">Dane logowania użytkownika.</param>
        /// <returns>JWT logującego się użytkownika.</returns>
        public string Login(UserCreds creds);

        /// <summary>
        /// Zmiana danych użytkownika.
        /// </summary>
        /// <param name="user">Użytkownik, któremu trzeba podmienić dane.</param>
        /// <returns>Zaktualizowane dane o użytkowniku.</returns>
        public Task<User> Update(User user);

        /// <summary>
        /// Aktywacja użytkownika z linku z maila.
        /// </summary>
        /// <param name="activationToken">Token użytkownika z maila.</param>
        /// <returns>True jeżeli akcja została wykonana poprawnie.</returns>
        public Task<bool> Activate(string activationToken);
    }
}
