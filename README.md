# Dokumetacja
Projekt zaliczeniowy
Dane administratora login: marcin@gmail.com hasło Marcin1!
W aplikacji są zaimplementowane 2 role (z możliwością dodawania następnych) – administrator i kucharz. Osobne uprawnienia są dla osób zalogowanych.
Opis zakładek:
Home
• Każdy ma dostęp
• Strona statyczna, znajduje się na niej przywitanie
Menu
• Dostęp tylko po zalogowaniu, możliwości zależne od roli
o Każdy zalogowany użytkownik:
▪ Może dodać swoją propozycje dania
▪ Może zobaczyć swoje propozycje dań
o Kucharz
▪ Uprawnienia jak każdy inny zalogowany użytkownik, tylko widzi wszystkie propozycje dań
• Dane są zapisywane i odczytywane z bazy danych z tablicy „dish”
Role
• Zakładkę tę widzi tylko administrator
• Zakładka ta dodatkowo jest zabezpieczona, że dostęp do niej ma tylko administrator (w przypadku gdyby inny użytkownik próbował wejść poprzez modyfikację url.
• W tej zakładce są widoczne role, jakie są dostępne w systemie, 2 role są specjalnie chronione
o Administrator dla pewności w ogóle nie jest w tym widoku wyświetlany
o Roli kucharz nie można usunąć
• Jest możliwość dodawania nowych roli – nie zmienia to działania systemu, ale administrator może tworzyć nowe role
• Nowo stworzone role mogą zostać usunięte
• Role odczytywane i zapisywane są z bazy danych za tabel Role i AspNetRoles. Tabela Role posłużyła do stworzenia widoku i z niej dane są wyświetlane, tabela AspNetRoles jest tabelą domyślą systemu i z niej program sprawdza jakie role istnieją
Role użytkownicy
• Zakładkę tę widzi tylko administrator
• Zakładka ta dodatkowo jest zabezpieczona, że dostęp do niej ma tylko administrator (w przypadku gdyby inny użytkownik próbował wejść poprzez modyfikację url.
• W tej zakładce jest widoczne, który użytkownik ma którą rolę
o Powiązanie administratora nie jest widoczne ze względów bezpieczeństwa
o Powiązanie z rolą kucharz może zostać usunięte – może być wakat na tym stanowisku
o Wielu użytkowników może mieć rolę kucharz
• Z tego poziomu administrator może dodawać jak i usuwać powiązania pomiędzy rolami jak i użytkownikami
• Powiązania pomiędzy rolami i użytkownikami są odczytywane i zapisywane są z bazy danych za tabel UsersRoles i AspNetUserRoles. Tabela UsersRoles posłużyła do stworzenia widoku i z niej dane są wyświetlane, tabela AspNetUserRoles jest tabelą domyślą systemu i z niej program sprawdza który użytkownik ma jaką role
Przed zalogowaniem są widoczne:
Registry – umożliwia stworzenie nowego konta, zaraz po stworzeniu nie ma przypisanej żadnej roli
Login – pozwala się zalogować
