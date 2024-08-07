Base entity kullanıldı
BaseEntity miras alınarak Person entitysi oluşturuldu

Base oalrak kullanılan entityler abstract olarak işaretlendi,
Departman vb sınıflar BaseEntityden miras alındı
Personel vb sınıflar Baseentityden miras alan PersonBase den misas alındı

Sınırlandırma yapmak için her Controller için Repository klasörünün altına gerekli Interfaceler oluşturuldu.
Departman eklemek için DepartmanService Class ı oluşturuldu ve IDepartman Interfacesi Implement edeildi,
DepartmanService ye Dependency injection kullanılarak DbContext eklendi ve add metodu yazıldı.
DepartmanController e IDepartman Dependency injection yapılıp add metoduna DepartmanDTO gönderildi ancak çalışmadı :)
