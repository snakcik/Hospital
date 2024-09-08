Base entity kullanıldı
BaseEntity miras alınarak Person entitysi oluşturuldu

Base oalrak kullanılan entityler abstract olarak işaretlendi,
Departman vb sınıflar BaseEntityden miras alındı
Personel vb sınıflar Baseentityden miras alan PersonBase den miras alındı

Sınırlandırma yapmak için her Controller için Repository klasörünün altına gerekli Interfaceler oluşturuldu.
Departman eklemek için DepartmanService Class ı oluşturuldu ve IDepartman Interfacesi Implement edeildi,
DepartmanService ye Dependency injection kullanılarak DbContext eklendi ve add metodu yazıldı.
DepartmanController e IDepartman Dependency injection yapılıp add metoduna DepartmanDTO gönderildi ancak çalışmadı :)


__________________________________________________________________________________________________________________________

-----------------------------------------HATA VE EKSİKLER ----------------------------------------
			Validation işlemi = Update sayfaları için Validation tamamlanmadı Düzelt (Tamamlandı)
			Messages = hala normal mesajlar var kontrol et ve mesajları enum dan al (Düzeltildi)
			Patient = Çift kimlik no kaydı yapmıyor sayfa yeniden listeye dönüyor düzelt (Düzeltildi)
			Departman = ekledin mesajı listeye gelmiyor düzelt(Düzeltildi)
			Pattien = Sayfaya doktorun adı soyadı da gelsin. (Düzeltildi)
			Remove = kalıcı silme mesajlarını düzelt. (Düzeltildi)

----------------------------------------EKLENECEKLER -----------------------------------------
!!!!!!!!!!!!!!!!!!!!!!!! Basit bir arama eklenmeli Acil !!!!!!!!!!!!!!!!!!!!!!!!

Hastaya Reçete sayfası eklenecek
	Hasta Reçete tablosu yapılacak ve hastaya ilaç eklenecek
	tablo çoka çok olacak çünki bir ilacın birden fazala hastası bir hastanın birden fazla ilacı olacak.
	Reçete tablosu eklenecek Hasta abi, Reçeteyi yazan doktor, Reçeteye yazılan ilaçlar, reçete tarihi.

Fatura Eklenecek
	Inventory tablosu güncellenecek = inventory deki malzemeye tanımı gelmesi gerekli (Sarf Malzeme,ilaç vs(ilacı reçeteye eklerken gazlı bez yazmaya gerek yok))
									  inventory deki malzemenin birim fiyatı gelmesi gerekli (ilaç yazdığımızda faturaya ekleyebilelim
	Invoice detail tablosu eklenecek = hasta adı, işlem yapan doktoradı, verilen hizmetle

	___________________BUG___________________
	Departman ve personel update te sıkıntı var çalışmıyor  
	Düzeltilti 060924