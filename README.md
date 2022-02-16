# Narzędzia Typu RAD 21Z - Projekt

## Lab 4

### Wstęp

Do realizacji projektu jako serwera REST użyto technologii ASP.MVC i języka C# i jako aplikacji webowej użyto biblioteki React i języka TypeScript. Do trzymania danych użyo bazy danych MySQL.

Szkielet projektu wytworzono za pomocą następujących komend: `dotnet new react` i `npx create-react-app --template typescript`.

### Instrukcja uruchomienia

1. Sklonowanie repozytorium: `git clone https://github.com/MortonPL/dotnet-web-app.git`
2. Przejście do katalogu projektu: `cd ntr21z-moroz-bartlomiej && cd lab4`
3. Konfiguracja bazy danych:
    a. (zalecane) poprzez kontener Dockerowy - przygotowany jest plik konfiguracyjny `docker-compose.yaml`. Komenda `docker-compose up` automatycznie pobierze potrzebny obraz i zamontuje go. Baza jest gotowa do działania gdy w konsoli ostatnim logiem będzie `lab4-mysql-db-1  | Version: '5.7.37'  socket: '/var/run/mysqld/mysqld.sock'  port: 3306  MySQL Community Server (GPL)`.
    b. własna instancja bazy danych "bare metal" - MySQL 5.7 nasłuchująca na porcie 3306, posiadająca bazę danych `ntr` i użytkownika `app` (z prawami odczytu i zapisu) z hasłem `maslo`.
4. Zbudowanie projektu w trybie produkcyjnym: `dotnet publish`.
5. Przejście do katalogu plików wykonywalnych: `cd bin && cd Debug && cd "net6.0" && cd publish`.
6. Uruchomienie serwera poprzez: `./lab4.exe` (PowerShell i bash) lub `lab4.exe` (Wiersz Poleceń).
7. Po włączeniu serwera aplikacja internetowa będzie dostępna pod adresem: `https://localhost:5001/` lub `http://localhost:5000/`.

### Dane testowe

Istnieje czterech użytkowników: `Balbinka`, `John Fighter`, `Jacob Hoe` i `Jacob Birder`.

Istnieją trzy projekty:
    - `KOMPOT` (kategorie `Warzenie kompotu`, `Rozlewanie kompotu`, `Smakowanie kompotu` ),
    - `NTR` (kategorie `Kolokwium`, `Projekt`),
    -  `ARGUS`, zamknięty (jedna kategoria `Argusowanie`).

Użytkownik `Balbinka` posiada otwarte miesięczne raporty na miesiące 12.2021 i 01.2022, zaś użytkownik `John Fighter` na 01.2022. Reszta użytkowników nie posiada aktywności.

Użytkownik `Balbinka` posiada aktywności w następujące dni: 24.12.2021, 25.01.2022.

Użytkownik `John Fighter` posiada aktywności w następujące dni: 24.01.2022, 25.01.2022.

### Skrócony opis interfejsu

- Ekran główny: domyślnie działa jak zakładka `Activities`.
- Zakładka `Users`: ekran zarządzania profilem - można się zalogować/utworzyć nowe konto, lub wylogować.
- Zakładka `Activities`: ekran przeglądu i zarządzania aktywnościami, posiada nagłówek informujący o obecnie wybranej dacie, sumie czasu z danego dnia i status miesiąca. Poniżej posiada tabelę ze szczegółowym podglądem aktywności i możliwością zarządzania nimi.
- Zakładka `Projects`: ekran podglądu całkowitego czasu spełnionego na projekty, w których się uczestniczyło.

### Skrócony opis architektury systemu

* `/` - katalog główny serwera
* `/Controllers/` - katalog kontrolerów
* `/Entities/` - katalog modeli danych i innych używanych klas w projekcie
* `/Entities/DB/` - katalog klas odpowiedzialnych za komunikację z bazą danych
* `/Entities/Helper.cs` - statyczna klasa udostępniająca zbiór pomniejszych funkcji używanych w projekcie

* `ClientApp/` - katalog główny aplikacji webowej
* `ClientApp/src/` - katalog główny plików źródłowych aplikacji
* `ClientApp/routes/` - katalog komponentów funkcyjnych dotyczących określonej ścieżki
* `ClientApp/shared-components` - katalog komponentów funkcyjnych o ogólnym przeznaczeniu
* `ClientApp/entities/` - katalog modeli danych istniejących po stronie aplikacji webowej
* `ClientApp/Helpers.ts` - zbiór pomniejszych funkcji używanych w projekcie
* `Client/FetchWrapper.ts` - statyczna klasa funkcjonująca jako wrapper obsługi żądań REST


### Środowisko

Projekt przetestowano na następujących systemach operacyjnych / platformach:
* Windows 10

Projekt przetestowano ręcznie na następujących przeglądarkach internetowych:
* Opera (wersja 82... )
* Google Chrome (wersja 97... )
* Microsoft Edge (wersja 97... )
