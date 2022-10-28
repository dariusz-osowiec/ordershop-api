using System.ComponentModel.DataAnnotations.Schema;

namespace OrderShopApi.Entities;

[Table("users")]
public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PostCode { get; set; }
    public string? City { get; set; }
    public bool IsActivated { get; set; }
    public string ActivationToken { get; set; }

    /////////////////////////////////////////////////////////////////////////////
    ///Konwersje encji.
    ///

    ///<summary>
    ///Konwersja do DTO.
    ///</summary>
    ///<param name="entity">Obiekt encji.</param>
    public static implicit operator User(UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            Name = entity.Name,
            Surname = entity.Surname,
            Phone = entity.Phone,
            Address = entity.Address,
            City = entity.City,
            PostCode = entity.PostCode,
            IsActivated = entity.IsActivated,
            ActivationToken = entity.ActivationToken,
        };
    }

    ///<summary>
    ///Konwersja do encji.
    ///</summary>
    ///<param name="entity">Obiekt DTO. </param>
    public static explicit operator UserEntity(User user)
    {
        return new UserEntity()
        {
            Id = user.Id,
            Email = user.Email,
            Password = user.Password,
            Name = user.Name,
            Surname = user.Surname,
            Phone = user.Phone,
            Address = user.Address,
            City = user.City,
            PostCode = user.PostCode,
            IsActivated = user.IsActivated,
            ActivationToken = user.ActivationToken,
        };
    }
}
