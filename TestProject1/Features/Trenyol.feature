Feature: Trendyol page
@mytag
Scenario:Trendyol sayfasında login işlemi
Given Trendyol ana sayfayı aç
When Giriş butonuna tıkla 
When Eposta ve şifre gir 
When Giriş yap butonuna tıkla
Then Başarılı girişi kontrol et 'Siparişlerim'