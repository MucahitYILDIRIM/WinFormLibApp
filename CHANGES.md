# CHANGES — Unit test altyapısı ve testler

## Özet
Repoda hiç test yoktu. `LibrarySoln/LibrarySoln.Tests` adında bir MSTest projesi eklendi,
DAL ve formlardaki UI'dan bağımsız kurallar için unit testler yazıldı. Test edilebilirlik için
davranışı korumaya dikkat edilerek küçük refactor'lar yapıldı.

> **Önemli:** Bu ortamda (macOS, `dotnet`/`msbuild`/`mono` yok) proje **derlenemedi ve testler
> çalıştırılamadı**. Kod dikkatlice incelenerek yazıldı; ilk iş olarak Windows'ta Visual Studio 2017+
> Test Explorer ile (veya `msbuild /restore LibrarySoln/LibrarySoln.sln` + `vstest.console`,
> ya da `dotnet test LibrarySoln/LibrarySoln.sln`) doğrulanmalıdır. Bu durum PR açıklamasında
> da belirtilmelidir.

## Kararlar
- **Test framework: MSTest 2.2.10** + `Microsoft.NET.Test.Sdk 16.11.0`. Proje .NET Framework 4.6.1;
  MSTest 3.x ve Test.Sdk 17.4+ net462 ve üstünü istediği için net461'i destekleyen son sürümler seçildi.
- **Test projesi SDK-style csproj** (`net461`, PackageReference). Mevcut projeler eski formatta
  kaldı; SDK-style proje eski formattaki projelere ProjectReference verebilir. Targeting pack'i
  olmayan makinelerde derlenebilmesi için `Microsoft.NETFramework.ReferenceAssemblies` eklendi.
- **Mock kütüphanesi kullanılmadı**; bağımlılık eklememek için elle yazılmış fake'ler
  (`Fakes/FakeDbExecutor.cs`) kullanıldı.
- Tek test projesi hem `LibraryDAL`'ı hem `LibraryUI`'ı (WinExe) referans ediyor.

## Refactor'lar (davranış korunarak)
1. **`IDbExecutor` / `SqlDbExecutor` (LibraryDAL):** `DAL` artık `SqlConnection`'ı doğrudan
   kullanmıyor. SQL kodu (`SqlCommand`, `AddWithValue`, `SqlDataAdapter.Fill`, open/close/dispose)
   birebir `SqlDbExecutor`'a taşındı. Tek bağlantı kullanılıp her çağrıdan sonra dispose edilmesi
   (DAL nesnesinin tek kullanımlık olması) korundu.
2. **`IMessageNotifier` / `MessageBoxNotifier` (LibraryDAL):** `PRC_DML_MEMBER` ve `PRC_DML_HIRE`
   içindeki `MessageBox.Show` çağrıları bu arayüze taşındı; testlerde pencere açılmıyor.
3. **`DAL` constructor'ları:** Parametresiz `DAL()` aynı şekilde çalışıyor (config'ten connection
   string + MessageBox). Testler için `DAL(IDbExecutor, IMessageNotifier)` eklendi. Formlarda
   değişiklik gerekmedi.
4. **Tekrarlanan okuma kodu** `FillSilently` yardımcı metoduna toplandı; hatalar önceki gibi
   yutuluyor ve (kısmen dolmuş olabilecek) tablo döndürülüyor.
5. **`FormRules` (LibraryUI):** Formlardaki saf mantık çıkarıldı:
   - `AreAllFilled` → `Signup` boş alan kontrolü (`String.IsNullOrEmpty` semantiği aynı).
   - `JoinCategories` → `UserScreen` kategori birleştirme döngüsü (kod birebir taşındı).
   - `GetResponseDate` / `HirePeriodDays = 7` → `UserScreen` kiralama iade tarihi.
   - `GetLoggedInUserName` / `LoginUserNameColumnIndex = 6` → `Login` ekranında `PRC_LOGIN`
     sonucundan kullanıcı adının okunması. İndeks SQL script'ine göre doğrulandı
     (`Person` 5 sütun + `Member.personId` → 6. indeks `Member.userName`). Satır yoksa `null`
     döner ve form eskisi gibi hata mesajı gösterir.
6. **`DAL.cs` UTF-8 BOM'u korundu**; diff yalnızca gerçek değişiklikleri içeriyor.

## Varsayımlar ve bilinen küçük farklar
- Hata durumunda eskiden `catch` bloğu (MessageBox) bağlantı kapatılmadan önce çalışıyordu; şimdi
  bağlantı önce kapatılıyor, sonra mesaj gösteriliyor. Kullanıcıya görünen sonuç aynı.
- Parametreler `Dictionary` ile taşınıyor; stored procedure parametreleri isimle bağlandığı için
  sıra önemli değil.
- Tarih dönüşümleri (`Convert.ToDateTime`) hâlâ geçerli kültüre bağlı; testler de tarih
  string'ini `ToShortDateString()` ile (UI ile aynı şekilde) üretiyor.
- Testler bazı mevcut (muhtemelen istenmeyen) davranışları **belgeliyor ama düzeltmiyor**:
  `PRC_DML_BOOK`'a `null` tarih verilince `DateTime.MinValue` gönderilmesi, okuma hatalarının
  sessizce yutulması, boşluk karakterinin "dolu" sayılması.

## Kapsam dışı bırakılanlar / not edilen sorunlar
- **Form event handler'ları** (WinForms kontrolleri, `Show/Hide`) unit test kapsamına alınmadı;
  bunlar için UI otomasyonu veya daha büyük bir refactor (MVP vb.) gerekir.
- **`SqlDbExecutor`** gerçek SQL Server gerektirdiği için unit test yok; entegrasyon testi
  olarak ayrıca ele alınabilir (`LibrarySolnScriptandData.sql` ile).
- Fark edilen ama davranış değişikliği olacağı için dokunulmayan hatalar:
  - `AddPrintery.btnAddPrintery_Click`: combobox seçimi yoksa `SelectedItem.ToString()`
    `NullReferenceException` fırlatır.
  - `Login` constructor'ında "silinecek" notlu sabit `admin/admin` bilgileri.
  - `Login`: kullanıcı adı hâlâ sabit indeksle (`ItemArray[6]`) okunuyor; sütun adıyla okumak
    daha sağlam olurdu ama davranışı korumak için değiştirilmedi (test ile belgelendi).
  - Repoda `bin/`, `obj/`, `.vs/` klasörleri commit'lenmiş; `.gitignore` eklenmesi önerilir
    (test projesinin build çıktıları da untracked olarak görünecektir).
