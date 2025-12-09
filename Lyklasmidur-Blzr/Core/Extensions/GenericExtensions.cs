namespace Lyklasmidur_Blzr.Core.Extensions
{
    public static class GenericExtensions
    {
        extension(string str)
        {
            public string Capitalize() =>
                char.ToUpper(str[0]) + str[1..];
        }
    }
}
