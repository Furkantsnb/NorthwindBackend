using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static String ProductAdded = "Ürün başarıyla eklendi";
        public static String ProductDeleted = "Ürün başarıyla silindi";
        public static String ProductUpdated = "Ürün başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme Giriş Başarılı";
        public static string UserAlredyExits = "Sisteme Giriş Başarılı";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
