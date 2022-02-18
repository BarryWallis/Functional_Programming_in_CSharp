using System.Net.Mail;

using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace ExerciseSolutions.Chapter05;
public struct EMail
{
    /// <summary>
    /// The eMail address.
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Smart constructor to create a new eMail address. 
    /// </summary>
    /// <param name="address">The eMail address.</param>
    /// <returns>A new EMail with the given address.</returns>
    public static Option<EMail> Create(string address) => IsValid(address) ? Some(new EMail(address)) : None;

    /// <summary>
    /// Implicit conversion from EMail to string.
    /// </summary>
    /// <param name="eMail">The EMail to convert to a string.</param>
    public static implicit operator string(EMail eMail) => eMail.Address;

    private EMail(string address) => Address = address;

    private static bool IsValid(string address)
    {
        try
        {
            return new MailAddress(address).Address == address;
        }
        catch (Exception exception) when (exception is ArgumentNullException or ArgumentException or FormatException)
        {
            return false;
        }
    }
}
