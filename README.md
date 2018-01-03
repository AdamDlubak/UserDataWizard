# User Data Wizard

Prosta aplikacja wykorzystująca technologię `WPF` (`Windows Presentation Foundation`) , której zadaniem jest zebranie od użytkownika podstawowych danych kontaktowych:

- Imię
- Nazwisko
- Adres - ulica i numer domu / mieszkania, kod pocztowy, miasto, kraj
- Numer telefonu

Użytkownikowi po uruchomieniu aplikacji pokazywany jest *Welcome Screen*, następnie za pomocą trzech przycisków nawigacji (*Cancel*, *Previous*, *Next*) steruje on całym procesem zbierania danych. 

Każda informacja wymieniona w kolejnych podpunktach powyżej, pobierana jest od użytkownika na osobnej *stronie* aplikacji. Klient ma możliwość w dowolnym momencie działania aplikacji powrócić do poprzednich widoków i edytować wcześniej wprowadzone informacje. Ostatni widok aplikacji to podsumowanie zebranych danych poprzez wylistowanie ich na ekranie.

![UserDataWizardScreen](https://github.com/AdamDlubak/UserDataWizard/blob/master/UserDataWizard/Images/UserDataWizardScreen.png)



## Struktura projektu - MVVM

Projekt został napisany w oparciu o wzorzec architektoniczny `MVVM` (`Model-View-ViewModel`).

Jest to najpopularniejszy i najczęściej wykorzystywany wzorzec wykorzystywany do budowania aplikacji w technologii `WPF`. 

Struktura folderów projektu przedstawia się następująco:

- **Helpers** - Pliki odpowiedzialne za implementację interfesjów technologii `WPF`: `ICommand` oraz `INotifyPropertyChanged` oraz abstrakcyjna klasa rozszerzana przez wszystkie *ViewModel'e* aplikacji: `PageViewModel`

- **Images** - obrazy wykorzystane do prezentacji treści aplikacji

- **Models** - model danych użytkownika aplikacji `User`

- **Styles** - zawiera plik typu *Resource Dictionary* odpowiedzialny za style graficzne widoku aplikacji

- **Views** -  pliki widoków aplikacji w postaci `.xaml` opisujących strutkurę *okna* i *stron*

- **ViewModels** - pliki logiki biznesowej aplikacji w postaci plików `.cs` (`C#`) - w relacji 1:1 do każdego widoku z folderu *Views*.

  ​

## Walidacja danych

W celu zabezpieczenia aplikacji przed wprowadzaniem niepoprawnych danych przez użytkowników - każde pole formularza zostało objęte dedykowaną walidacją poprawności, uwzględniając przy tym dodatkowe założenia, np. akceptowalność jedynie polskich numerów telefonów komórkowych, czy polskich kodów pocztowych. 

Użytkownik przed przejściem do kolejnego ekranu jest zobowiązany do poprawnego uzupełnienia koniecznych informacji z bieżącego ekranu. 

#### Sposób walidacji poszczególnych danych:

- **Imię**
  - Pole nie może być puste
  - Pole musi posiadać conajmniej 3 i maksymalnie 50 znaków
  - Przykład: `Adam`
- **Nazwisko**
  - Pole nie może być puste
  - Pole musi posiadać conajmniej 3 i maksymalnie 50 znaków
  - Przykład: `Dłubak`
- **Adres**
  - Ulica i numer domu / mieszkania
    - Pole musi spełniać wymagania poprawności *Regex'a*
      `^[\p{L}]{2,} [0-9]{1,}\s?(\/\s?[0-9]{1,})?$`
    - Akceptowalne są tylko nazwy ulic z numerem domu oraz ewentualnym numerem mieszkania po znaku /
    - Przykład: `Wittiga 8` lub `Wittiga 8/914` lub `Wittiga 8 / 914`
  - Kod pocztowy
    - Pole musi spełniać wymagania poprawności *Regex'a*
      `^[0-9]{2}-[0-9]{3}$`
    - Akceptowalne są jedynie polskie kody pocztowe których struktura to `dd-ddd`, gdzie `d` to dowolna cyfra.
    - Przykład `98-330`
  - Miasto
    - Pole nie może być puste
    - Pole musi posiadać conajmniej 3 i maksymalnie 100 znaków
    - Przykład: `Wrocław`
  - Kraj
    - Pole nie może być puste
    - Pole musi posiadać conajmniej 3 i maksymalnie 100 znaków
    - Przykład: `Polska`
- **Numer telefonu**
  - Pole musi spełniać wymagania poprawności *Regex'a* 
    `^(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)?`
  - Akceptowalne są wyłącznie polskie numery telefonów komórkowych: ze znakiem *+48* lub *0048* na początku numeru oraz wersje bez numeru kierunkowego
  - Akceptowalne są przerwy w numerach w postaci *spacji* lub *myślników*
  - Przykład: `+48 111 222 333` lub `0048 1112223333` lub `111-222-333`