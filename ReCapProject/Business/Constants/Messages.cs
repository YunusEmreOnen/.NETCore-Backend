using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarRented = "Araç kiralanmış.";
        public static string RentalAded = "Araç Kiralandı";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerDeleted = "Müşteri eklendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserDeleted = "Kullanıcı eklendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string CarAdded = "Araç eklendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdate = "Araç güncellendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdate = "Renk güncellendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdate = "Marka güncellendi.";
        public static string CarNameInvalid = "Araç ismi geçersiz.";
        public static string CarsDailyPriceInvalid = "Geçrsiz bir Araç fiyatı girildi.";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarImagelimitExceeded = "Araç resim sayısı sınırı aşıldı.";
        public static string GetDefaultCarImage = "Default araç resmi gönderildi.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıdı gerçekleşti.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
