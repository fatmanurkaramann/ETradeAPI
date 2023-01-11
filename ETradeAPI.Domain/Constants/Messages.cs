using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Constants
{
    public class Messages
    {
        public static readonly string RegisteredSuccessfully = "Kayıt başarılı!";
        public static readonly string UserAlreadyExist = "Bu mail veya kullanıcı adı kullanımdadır!";
        public static readonly string UserStatusIsInactive = "Kullanıcı aktif durumda değil.";
        public static readonly string LoginError = "Giriş bilgileri hatalı.";
        public static readonly string SuccessfulLogin = "Giriş başarılı!";
        public static readonly string CategoryNameIsAlreadyExist = "Kategori zaten mevcut.";
        public static readonly string CategoryCreated = "Kategori başarıyla oluşturuldu.";
        public static readonly string CategoryUpdated = "Kategori başarıyla güncellendi.";
        public static readonly string CategoryDoesnotExist = "Böyle bir kategori bulunamadı.";
        public static readonly string CategoryDeleted = "Kategori başarıyla silindi.";
        public static readonly string CategoriesListed = "Kategoriler listelendi.";
        public static readonly string CategoryNotFound = "Kategori bulunamadı.";
        public static readonly string CreateProductError = "Ürün oluşturulurken bir hata oluştu.";
        public static readonly string CategoryIsInvalid = "Girilen kategori bilgisi geçersizdir!";
        public static readonly string ProductCreated = "Ürün başarıyla oluşturuldu.";
        public static readonly string ProductIsAlreadyExist = "Bu ürün daha önce eklenmiştir!";
        public static readonly string UpdateProductError = "Ürün güncellenirken bir hata oluştuı.";
        public static readonly string ProductUpdated = "Ürün başarıyla güncellendi.";
        public static readonly string ProductDeleted = "Ürün başarıyla silindi.";
        public static readonly string ProductNotFound = "Ürün bulunamadı!";
        public static readonly string ProductDetailsBrought = "Ürün detayları getirildi.";
        public static readonly string ProductsListed = "Ürünler listelendi.";
        public static readonly string OrderCreated = "Sipariş oluşturuldu.";
        public static readonly string OrderUpdated = "Sipariş güncellendi.";
        public static readonly string OrderIsNotFound = "Bu sipariş bulunamadı.";
        public static readonly string OrderIsOnWayCannotUpdate = "Sipariş yola çıktığı için güncelleme yapılamamaktadır.";
        public static readonly string OrderDeleted = "Sipariş silindi.";
        public static readonly string OrderDetailsBrought = "Sipariş detaylarıyla birlikte getirildi.";
        public static readonly string OrdersListed = "Siparişler listelendi.";
    }
}
