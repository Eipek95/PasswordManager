using System.ComponentModel.DataAnnotations;

namespace Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ComplexCharacterCheckAttribute : ValidationAttribute
    {
        public ComplexCharacterCheckAttribute()
        {
            ErrorMessage = "Şifreniz en az 6 karekterli ve en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string password = value.ToString();


            if (password.Length < 6)
            {
                return false;
            }

            // En az bir büyük harf kontrolü
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // En az bir küçük harf kontrolü
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // En az bir rakam kontrolü
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // En az bir özel karakter kontrolü
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            return true;
        }
    }
}
