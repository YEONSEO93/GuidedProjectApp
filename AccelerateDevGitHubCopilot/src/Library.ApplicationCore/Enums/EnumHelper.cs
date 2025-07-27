using System.ComponentModel;
using System.Reflection;

namespace Library.ApplicationCore.Enums;

public static class EnumHelper
{
    // Dictionary for LoanExtensionStatus descriptions
    private static readonly Dictionary<LoanExtensionStatus, string> LoanExtensionStatusDescriptions = new()
    {
        { LoanExtensionStatus.Success, "Book loan extension was successful." },
        { LoanExtensionStatus.LoanNotFound, "Loan not found." },
        { LoanExtensionStatus.LoanExpired, "Cannot extend book loan as it already has expired. Return the book instead." },
        { LoanExtensionStatus.MembershipExpired, "Cannot extend book loan due to expired patron's membership." },
        { LoanExtensionStatus.LoanReturned, "Cannot extend book loan as the book is already returned." },
        { LoanExtensionStatus.Error, "Cannot extend book loan due to an error." }
    };

    // Dictionary for LoanReturnStatus descriptions
    private static readonly Dictionary<LoanReturnStatus, string> LoanReturnStatusDescriptions = new()
    {
        { LoanReturnStatus.Success, "Book was successfully returned." },
        { LoanReturnStatus.LoanNotFound, "Loan not found." },
        { LoanReturnStatus.AlreadyReturned, "Cannot return book as the book is already returned." },
        { LoanReturnStatus.Error, "Cannot return book due to an error." }
    };

    // Dictionary for MembershipRenewalStatus descriptions
    private static readonly Dictionary<MembershipRenewalStatus, string> MembershipRenewalStatusDescriptions = new()
    {
        { MembershipRenewalStatus.Success, "Membership renewal was successful." },
        { MembershipRenewalStatus.PatronNotFound, "Patron not found." },
        { MembershipRenewalStatus.TooEarlyToRenew, "It is too early to renew the membership." },
        { MembershipRenewalStatus.LoanNotReturned, "Cannot renew membership due to an outstanding loan." },
        { MembershipRenewalStatus.Error, "Cannot renew membership due to an error." }
    };

    // Generic method with type-specific dictionary lookup
    public static string GetDescription(Enum value)
    {
        if (value == null)
            return string.Empty;

        return value switch
        {
            LoanExtensionStatus status => LoanExtensionStatusDescriptions.GetValueOrDefault(status, status.ToString()),
            LoanReturnStatus status => LoanReturnStatusDescriptions.GetValueOrDefault(status, status.ToString()),
            MembershipRenewalStatus status => MembershipRenewalStatusDescriptions.GetValueOrDefault(status, status.ToString()),
            _ => GetDescriptionUsingReflection(value) // Fallback for other enums
        };
    }

    // Fallback method using reflection for enums not in dictionaries
    private static string GetDescriptionUsingReflection(Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }
}