# BANDaid

**Listen. Rate. Discover.** – strona, na której użytkownicy oceniają albumy i dzielą się opiniami o muzyce.

Technologie: ASP.NET Core MVC (.NET 10), Entity Framework Core, SQLite, HTML/CSS/JavaScript.

## Wymagania

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Edytor: Visual Studio 2022/2026 (workload *ASP.NET and web development*), VS Code z C# Dev Kit lub Rider

## Jak uruchomić

Z terminala:

```bash
cd BANDaid
dotnet run
```

Następnie otwórz w przeglądarce **http://localhost:5168**.

Z Visual Studio: otwórz plik `BANDaid/BANDaid.csproj` i wciśnij **F5**.

Zatrzymanie strony: **Ctrl + C** w terminalu albo **Shift + F5** w Visual Studio.

Baza danych (`bandaid.db`) jest tworzona i aktualizowana automatycznie przy starcie aplikacji,
nie trzeba ręcznie wykonywać `dotnet ef database update`.

## Co już działa

- Strona główna: sekcja z hasłem, ranking albumów (Top charts) i najnowsze recenzje pobierane z bazy
- Rejestracja (email, nazwa użytkownika, hasło) i automatyczne logowanie po założeniu konta
- Logowanie przy użyciu emaila lub nazwy użytkownika, opcja „Remember me”
- Wylogowanie
- Walidacja formularzy po stronie przeglądarki i serwera
- Okna logowania i rejestracji jako modale (z wersją na osobnej stronie, gdy JavaScript jest wyłączony lub dane są błędne)

## Zasady dotyczące haseł

- minimum 8 znaków
- co najmniej jedna cyfra i jedna mała litera
- po 5 błędnych próbach logowania konto jest blokowane na 5 minut

(ustawienia znajdują się w `Program.cs`)

## Struktura projektu

| Ścieżka | Zawartość |
|---|---|
| `Controllers/AccountController.cs` | rejestracja, logowanie, wylogowanie |
| `Controllers/HomeController.cs` | dane strony głównej (ranking, recenzje) |
| `Data/ApplicationDbContext.cs` | kontekst bazy danych |
| `Models/` | modele bazy: `Artist`, `Album`, `Review`, `ApplicationUser` |
| `Models/ViewModels/` | modele formularzy i strony głównej |
| `Views/Home/Index.cshtml` | strona główna |
| `Views/Shared/_Layout.cshtml` | wspólny układ strony i menu |
| `Views/Shared/_LoginForm.cshtml`, `_RegisterForm.cshtml` | formularze używane w modalach i na osobnych stronach |
| `wwwroot/css/site.css` | cały wygląd strony |
| `wwwroot/js/site.js` | otwieranie i zamykanie modali |


## Do zrobienia

- Osobne strony rankingu i recenzji
- Dodawanie albumów i recenzji (skala 0–10 i opis)
- Profil użytkownika, ulubione pozycje, znajomi
- Opcjonalnie: integracja ze Spotify API, polubienia i komentarze
