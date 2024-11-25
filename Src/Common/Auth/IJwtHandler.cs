namespace Auth;

public interface IJwtHandler
{
    JsonWebToken Create(long userId);
}
