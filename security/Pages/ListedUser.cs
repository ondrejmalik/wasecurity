namespace security.Pages;

public class ListedUser
{
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public List<(int id,string message, bool isvisible)> Messages { get; set; }

    public override int GetHashCode()
    {
        if (Messages == null)
        {
            return Name.GetHashCode();
        }
        return Name.GetHashCode() ^ Messages.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is ListedUser user && user.Name == Name && user.Messages == Messages;
    }
}