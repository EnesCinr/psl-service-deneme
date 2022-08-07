﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Constants
{
    public class Messages
    {
        public const string AuthorizationDenied = "Yetkisiz giriş";

        public const string NameAlreadyExists = "Mükerrer kayıt olduğundan geçersiz";

        public const string UserNameAlreadyExist = "Bu kullanıcı adında farklı bir kullanıcı mevcuttur, lütfen yeni bir kullanıcı adı giriniz.";
        public const string EmailAlreadyExists = "Girilen email başka bir çalışanda kullanılmaktadır";
        public const string DataNotExists = "Kayıt bulunamadı";
        public const string UserNotFound = "Kullanıcı kaydı bulunamadı";
        public const string UserUnknownStatus = "Kullanıcı durumu bilinmiyor";
        public const string UserStatusPassive = "Kullanıcı pasif";
        public const string UserStatusBlocked = "Kullanıcı erişim engeli";
        public const string UserPasswordError = "Kullanıcı şifresi hatalı";
        public const string WrongUsernameOrPasswrod = "Kullanıcı adı veya şifre hatalı";
        public const string UserSuccessfulLogin = "Kullanıcı girişi başarılı";

        public const string Success = "İşleminiz başarılı";
        public const string Success_Added = "Kayıt ekleme işleminiz başarılı";
        public const string Success_Deleted = "Kayıt silme işleminiz başarılı";
        public const string Success_Updated = "Kayıt güncelleme işleminiz başarılı";

        public const string Failure = "İşleminiz başarısız";
        public const string Failure_Added = "Kayıt ekleme işleminiz başarısız";
        public const string Failure_Deleted = "Kayıt silme işleminiz başarısız";
        public const string Failure_Updated = "Kayıt güncelleme işleminiz başarısız";

        public const string UserPasswordRulesError = "Kullanıcı şifresi en az 8 karakterden oluşmalıdır.Ayrıca en az bir büyük harf ve bir küçük harf içermelidir!";

        public const string AccessTokenCreated = "Kullanıcı token bilgisi oluşturuldu";
        public const string DeviceNotExists = "Cihaz bulunamadı";
        public const string DeviceTypeCodeNotMatch = "Cihaz tip kodu eşleşmedi";
    }
}
